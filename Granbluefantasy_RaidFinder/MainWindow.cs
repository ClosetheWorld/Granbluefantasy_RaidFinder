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
        public int itemcount;
        public string id, level, enemy, twicomment;
        public Enemy.Model.EnemyCollection master;

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

            //GitHubからエネミーデータマスターをDL -> リストへ追加            
            var xmluri = "https://raw.githubusercontent.com/ClosetheWorld/GBFEnemyXml/master/gbfrf.xml";
            System.Net.WebClient wc = new System.Net.WebClient();
            wc.Encoding = System.Text.Encoding.GetEncoding("utf-8");
            var downloadedfile = wc.OpenRead(xmluri);            
            var ser = new System.Xml.Serialization.XmlSerializer(typeof(Enemy.Model.EnemyCollection));
            master = (Enemy.Model.EnemyCollection)ser.Deserialize(downloadedfile);
            wc.Dispose(); //リソース開放
            for (int i = 0; master.Array.Count() > i; i++)
            {
                checkedListBox1.Items.Add("Lv." + master.Array[i].Level +" "+ master.Array[i].Name_ja);
            }
            checkedListBox1.Items.Add("Lv.50 イベントエネミー");
            checkedListBox1.Items.Add("Lv.60 イベントエネミー");
            itemcount = (checkedListBox1.Items.Count);
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
            var ReceivedEnemy = new Enemy.Model.Enemy();
            if (twitext.Contains("参加者募集！") == true && twitext.Contains("ムID") == false && twitext.Contains("ルーム") == false)
            {
                parsecnt = twitext.IndexOf("参戦ID");
                parsecnt -= 2;
                ReceivedEnemy.ID = twitext.Remove(parsecnt);
                if(ReceivedEnemy.ID.Count() > 8)
                {
                    ReceivedEnemy.Comment = ReceivedEnemy.ID.Remove(ReceivedEnemy.ID.Count() - 8);                    
                    ReceivedEnemy.ID = ReceivedEnemy.ID.Substring(ReceivedEnemy.ID.Count() - 8);
                }
                else
                {
                    ReceivedEnemy.Comment = null;
                }
                parsecnt = twitext.IndexOf("参加者募集！");
                ReceivedEnemy.Level = twitext.Substring(parsecnt + 9, 2);
              
                if (Convert.ToInt32(ReceivedEnemy.Level) >= 10 &&
                    Convert.ToInt32(ReceivedEnemy.Level) <= 20)
                {
                    ReceivedEnemy.Level += "0";
                }                
                
                if (Convert.ToInt32(ReceivedEnemy.Level) > 99)
                {
                    ReceivedEnemy.Name_ja = twitext.Substring(parsecnt + 13);
                }
                else
                {
                    ReceivedEnemy.Name_ja = twitext.Substring(parsecnt + 12);
                }

               if((twitext.IndexOf("https://")) > 1)
                {
                    parsecnt = ReceivedEnemy.Name_ja.Count();
                    ReceivedEnemy.Name_ja = ReceivedEnemy.Name_ja.Remove(parsecnt - 24);
                }                
                
                var Tolist = new Enemy.Model.Enemy();
                level = ReceivedEnemy.Level;
                enemy = ReceivedEnemy.Name_ja;
                id = ReceivedEnemy.ID;

                //テストコード
                //Console.WriteLine(id + " " + level + " " + enemy);
                
                //チェック入りアイテムの絞り込み処理
                foreach (int indexchecked in checkedListBox1.CheckedIndices)
                {
                    if (indexchecked == itemcount - 1 || indexchecked == itemcount - 2)
                    {
                        var temp_e = Enemy.Model.IndexFilter.EventFiltering(ReceivedEnemy, master);
                        if (temp_e.Name_ja != "undefined" && temp_e.ID != "FFFFFFFF" || temp_e.Level != "999")
                        {
                            AddList(temp_e);
                            ReceivedEnemy = Enemy.Model.IndexFilter.Tonull(ReceivedEnemy);
                            Ring();
                            break;
                        }
                    }
                    else
                    {
                        var temp_e = Enemy.Model.IndexFilter.GenerateRequireEnemy(indexchecked, master);
                        Tolist = Enemy.Model.IndexFilter.Filtering(ReceivedEnemy, temp_e);

                        if (Tolist.Name_ja != "undefined" && Tolist.ID != "FFFFFFFF" || Tolist.Level != "999")
                        {
                            AddList(Tolist);
                            Ring();
                            break;
                        }
                    }
                    ReceivedEnemy.Level = level;
                    ReceivedEnemy.Name_ja = enemy;
                    ReceivedEnemy.ID = id;
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
            MessageBox.Show("Version: 1.5.1.1\nAuthor:@Close_the_World","バージョン情報",MessageBoxButtons.OK,MessageBoxIcon.Information);
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
        public void AddList(Enemy.Model.Enemy e)
        {
            if (dataGridView1.IsDisposed) return;
            if (dataGridView1.InvokeRequired)
            {
                this.Invoke((MethodInvoker) delegate
                {
                    //上から追加
                    dataGridView1.Rows.Insert(0);
                    dataGridView1.Rows[0].Cells[0].Value = "Lv." + e.Level + " " + e.Name_ja;
                    dataGridView1.Rows[0].Cells[1].Value = e.ID;
                    if (twicomment != null)
                    {
                        dataGridView1.Rows[0].Cells[2].Value = twicomment;
                    }

                    if (dataGridView1.Rows.Count > 200)
                    {
                        dataGridView1.Rows.Clear();
                    }
                });
            }
            
        }        
    }

}
