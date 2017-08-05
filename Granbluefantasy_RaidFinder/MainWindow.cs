using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using CoreTweet;
using CoreTweet.Streaming;
using System.Reactive.Linq;
using System.Reactive.Subjects;

namespace Granbluefantasy_RaidFinder
{

    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        //見ないで        
        public Tokens tokens;
        public OAuth.OAuthSession session;
        public string id, level, enemy;
        public string[] enemyfile;

        //初期化処理
        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                session = CoreTweet.OAuth.Authorize(Properties.Settings.Default.APIKey, Properties.Settings.Default.APISecret);
                tokens = Tokens.Create(Properties.Settings.Default.APIKey,
                    Properties.Settings.Default.APISecret,
                    Properties.Settings.Default.AccessToken,
                    Properties.Settings.Default.AccessTokenSecret);
                tokens.Account.VerifyCredentials();
                MessageBox.Show("起動時初期化完了", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                RandomCopy.Enabled = false;
            }
            catch (Exception ex)
            {
                Authorize();
            }

            //dataGridView1へボタンの配置
            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            btn.Name = "コピー";
            btn.UseColumnTextForButtonValue = true;
            btn.Text = "コピー";
            btn.Width = 160;
            btn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            btn.FillWeight = 20;
            dataGridView1.Columns.Add(btn);

            //自鯖からエネミーリスト生成
            string downloadedfile, sourcelevel, sourcename;
            System.Net.WebClient wc = new System.Net.WebClient();
            wc.Encoding = System.Text.Encoding.GetEncoding("shift_jis");
            downloadedfile = wc.DownloadString("http://closetheworld.softether.net:1717/Enemys.txt");
            enemyfile = downloadedfile.Split(new string[] { "\r\n" }, StringSplitOptions.None);
            for (int i = 0; enemyfile.Count() > i; i++)
            {
                sourcelevel = enemyfile[i].Substring(1, 2);
                if (Convert.ToInt32(sourcelevel) < 50)
                {
                    sourcelevel += "0";
                    sourcename = enemyfile[i].Substring(5);
                }
                else
                {
                    sourcename = enemyfile[i].Substring(4);
                }
                checkedListBox1.Items.Add("Lv." + sourcelevel + " " + sourcename);
            }
        }

        //検索開始
        public void button1_Click(object sender, EventArgs e)
        {
            backgroundWorker1.RunWorkerAsync();
            RandomCopy.Enabled = true;
            SearchStart.Enabled = false;
        }

        //ランダムにコピー
        private void RandomCopy_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(id);
        }

        //閉じる
        private void Menubar_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Userstream接続,検索
        public void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            backgroundWorker1.WorkerSupportsCancellation = true;

            //切断された時3s待機後再接続試行
            var observable = tokens.Streaming.FilterAsObservable(track: "ID");
            observable.Catch(observable.DelaySubscription(TimeSpan.FromSeconds(3)).Retry())
            .Repeat()
            .Where((StreamingMessage m) => m.Type == MessageType.Create)
            .Cast<StatusMessage>()
            .Select((StatusMessage m) => m.Status.Text)
            .Subscribe(TweetReceive);
        }

        //再認証
        private void Menubar_ReAuthorize_Click(object sender, EventArgs e)
        {
            Authorize();
        }

        //ツイート受信時に発生するイベント
        public void TweetReceive(string twitext)
        {
            int parsecnt = 0;

            if (twitext.Contains("参加者募集！参戦ID") == true)
            {
                parsecnt = twitext.IndexOf("参戦ID");
                id = twitext.Substring(parsecnt + 5, 8);
                level = twitext.Substring(parsecnt + 16, 2);

                //正規表現での探索に置き換え検討
                if (level == "10")
                {
                    level = "100";
                }
                else if (level == "11")
                {
                    level = "110";
                }
                else if (level == "12")
                {
                    level = "120";
                }
                else if (level == "15")
                {
                    level = "150";
                }
                else if (level == "20")
                {
                    level = "200";
                }

                if (Convert.ToInt32(level) > 99)
                {
                    enemy = twitext.Substring(parsecnt + 20);
                }
                else
                {
                    enemy = twitext.Substring(parsecnt + 19);
                }

                parsecnt = enemy.IndexOf("https://");

                if (parsecnt < 0)
                {

                }
                else
                {
                    enemy = enemy.Remove(parsecnt - 1);
                }


                Enemy e = new Enemy();
                Enemy Tolist = new Enemy();
                e.Level = level;
                e.Name = enemy;
                e.ID = id;

                //チェック入りアイテムの絞り込み処理
                foreach (int indexchecked in checkedListBox1.CheckedIndices)
                {
                    Enemy temp_e = IndexFilter.GenerateRequireEnemy(indexchecked, enemyfile);
                    Tolist = IndexFilter.Filtering(e, temp_e);

                    if (Tolist.Name != "undefined" && Tolist.ID != "FFFFFFFF" || Tolist.Level != "999")
                    {
                        AddList(Tolist);
                        Ring();
                    }
                    e.Level = level;
                    e.Name = enemy;
                    e.ID = id;
                }

            }
        }
    



        //IDコピー処理
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            if(dgv.Columns[e.ColumnIndex].Name == "コピー")
            {
                Clipboard.SetText(dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString());
            }
        }

        //検索結果削除
        private void Menubar_ClearResult_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
        }

        //バージョン情報
        private void Menubar_Verinfo_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Version: 1.3.0.0\nAuthor:@Close_the_World","バージョン情報",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        //このアプリについて
        private void Menubar_WhatthisApp_Click(object sender, EventArgs e)
        {
            string wta = "このアプリについて\n" +
                "俗に言われているグラブルレーダーのパクリアプリです\n" +
                "Webサービスでは落ちていたり使えないことが多いので自分のアカウントから検索を行うものとして作成しました\n" +
                "初回起動時/トークンが切れた時にはTwitter Webでの再認証が必要です\n" +
                "抽出したいマルチバトルにチェックを入れて検索開始を押すと検索が開始されます\n" +
                "わからない点、バグなどあれば作者までどうぞ\n" +
                "Copylight 🄫 2017 Close_the_World All Rights Reserved.";
            MessageBox.Show(wta, "このアプリについて", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //OAuth認証
        public void Authorize()
        {
            session = OAuth.Authorize(Properties.Settings.Default.APIKey, Properties.Settings.Default.APISecret);
            System.Diagnostics.Process.Start(session.AuthorizeUri.AbsoluteUri);

            Form n = new StartUp();
            n.ShowDialog();

            try
            {
                tokens = OAuth.GetTokens(session, Properties.Settings.Default.PIN);
                Properties.Settings.Default.PIN = "";
                Properties.Settings.Default.AccessToken = tokens.AccessToken;
                Properties.Settings.Default.AccessTokenSecret = tokens.AccessTokenSecret;
                Properties.Settings.Default.Save();
                MessageBox.Show("認証完了", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        //設定窓呼び出し
        private void Menubar_Setting_Click(object sender, EventArgs e)
        {
            Setting s = new Setting();
            s.ShowDialog();
        }

        //通知音(システム音)を鳴らす
        private void Ring()
        {
            if (Properties.Settings.Default.RingState == true)
            {
                System.Media.SystemSounds.Beep.Play();
            }
        }

        //DataGridViewに追加
        public void AddList(Enemy e)
        {
            if (dataGridView1.IsDisposed) return;
            if (dataGridView1.InvokeRequired)
            {
                this.Invoke((MethodInvoker) delegate
                {
                    //上から追加
                    dataGridView1.Rows.Insert(0);
                    dataGridView1.Rows[0].Cells[0].Value = "Lv." + e.Level + " " + e.Name;
                    dataGridView1.Rows[0].Cells[1].Value = e.ID;

                    if (dataGridView1.Rows.Count > 200)
                    {
                        dataGridView1.Rows.Clear();
                    }
                });
            }
            
        }        
    }

}
