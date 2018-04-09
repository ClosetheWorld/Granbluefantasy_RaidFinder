namespace Granbluefantasy_RaidFinder
{
    partial class MainWindow
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.SearchStart = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.RandomCopy = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.Menubar_Menu = new System.Windows.Forms.ToolStripMenuItem();
            this.Menubar_Setting = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.Menubar_Close = new System.Windows.Forms.ToolStripMenuItem();
            this.Menubar_Edit = new System.Windows.Forms.ToolStripMenuItem();
            this.Menubar_ClearResult = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.Menubar_ReAuthorize = new System.Windows.Forms.ToolStripMenuItem();
            this.Menubar_Help = new System.Windows.Forms.ToolStripMenuItem();
            this.Menubar_WhatthisApp = new System.Windows.Forms.ToolStripMenuItem();
            this.Menubar_Verinfo = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.lv_enemy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.multi_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "検索対象";
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.checkedListBox1.CheckOnClick = true;
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Location = new System.Drawing.Point(14, 52);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.ScrollAlwaysVisible = true;
            this.checkedListBox1.Size = new System.Drawing.Size(200, 634);
            this.checkedListBox1.TabIndex = 1;
            // 
            // SearchStart
            // 
            this.SearchStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.SearchStart.Location = new System.Drawing.Point(14, 695);
            this.SearchStart.Name = "SearchStart";
            this.SearchStart.Size = new System.Drawing.Size(97, 25);
            this.SearchStart.TabIndex = 2;
            this.SearchStart.Text = "検索開始";
            this.SearchStart.UseVisualStyleBackColor = true;
            this.SearchStart.Click += new System.EventHandler(this.button1_Click);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // RandomCopy
            // 
            this.RandomCopy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.RandomCopy.Location = new System.Drawing.Point(117, 695);
            this.RandomCopy.Name = "RandomCopy";
            this.RandomCopy.Size = new System.Drawing.Size(97, 25);
            this.RandomCopy.TabIndex = 3;
            this.RandomCopy.Text = "ランダムにコピー";
            this.RandomCopy.UseVisualStyleBackColor = true;
            this.RandomCopy.Click += new System.EventHandler(this.RandomCopy_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Menubar_Menu,
            this.Menubar_Edit,
            this.Menubar_Help});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1008, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // Menubar_Menu
            // 
            this.Menubar_Menu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Menubar_Setting,
            this.toolStripSeparator2,
            this.Menubar_Close});
            this.Menubar_Menu.Name = "Menubar_Menu";
            this.Menubar_Menu.Size = new System.Drawing.Size(52, 20);
            this.Menubar_Menu.Text = "メニュー";
            // 
            // Menubar_Setting
            // 
            this.Menubar_Setting.Name = "Menubar_Setting";
            this.Menubar_Setting.Size = new System.Drawing.Size(98, 22);
            this.Menubar_Setting.Text = "設定";
            this.Menubar_Setting.Click += new System.EventHandler(this.Menubar_Setting_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(95, 6);
            // 
            // Menubar_Close
            // 
            this.Menubar_Close.Name = "Menubar_Close";
            this.Menubar_Close.Size = new System.Drawing.Size(98, 22);
            this.Menubar_Close.Text = "終了";
            this.Menubar_Close.Click += new System.EventHandler(this.Menubar_Close_Click);
            // 
            // Menubar_Edit
            // 
            this.Menubar_Edit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Menubar_ClearResult,
            this.toolStripSeparator1,
            this.Menubar_ReAuthorize});
            this.Menubar_Edit.Name = "Menubar_Edit";
            this.Menubar_Edit.Size = new System.Drawing.Size(43, 20);
            this.Menubar_Edit.Text = "編集";
            // 
            // Menubar_ClearResult
            // 
            this.Menubar_ClearResult.Name = "Menubar_ClearResult";
            this.Menubar_ClearResult.Size = new System.Drawing.Size(139, 22);
            this.Menubar_ClearResult.Text = "結果をクリア";
            this.Menubar_ClearResult.Click += new System.EventHandler(this.Menubar_ClearResult_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(136, 6);
            // 
            // Menubar_ReAuthorize
            // 
            this.Menubar_ReAuthorize.Name = "Menubar_ReAuthorize";
            this.Menubar_ReAuthorize.Size = new System.Drawing.Size(139, 22);
            this.Menubar_ReAuthorize.Text = "再認証を行う";
            this.Menubar_ReAuthorize.Click += new System.EventHandler(this.Menubar_ReAuthorize_Click);
            // 
            // Menubar_Help
            // 
            this.Menubar_Help.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Menubar_WhatthisApp,
            this.Menubar_Verinfo});
            this.Menubar_Help.Name = "Menubar_Help";
            this.Menubar_Help.Size = new System.Drawing.Size(48, 20);
            this.Menubar_Help.Text = "ヘルプ";
            // 
            // Menubar_WhatthisApp
            // 
            this.Menubar_WhatthisApp.Name = "Menubar_WhatthisApp";
            this.Menubar_WhatthisApp.Size = new System.Drawing.Size(155, 22);
            this.Menubar_WhatthisApp.Text = "このアプリについて";
            this.Menubar_WhatthisApp.Click += new System.EventHandler(this.Menubar_WhatthisApp_Click);
            // 
            // Menubar_Verinfo
            // 
            this.Menubar_Verinfo.Name = "Menubar_Verinfo";
            this.Menubar_Verinfo.Size = new System.Drawing.Size(155, 22);
            this.Menubar_Verinfo.Text = "バージョン情報";
            this.Menubar_Verinfo.Click += new System.EventHandler(this.Menubar_Verinfo_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.lv_enemy,
            this.multi_id,
            this.comment});
            this.dataGridView1.Location = new System.Drawing.Point(220, 52);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 21;
            this.dataGridView1.Size = new System.Drawing.Size(776, 665);
            this.dataGridView1.TabIndex = 5;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // lv_enemy
            // 
            this.lv_enemy.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.lv_enemy.FillWeight = 30F;
            this.lv_enemy.HeaderText = "エネミー名";
            this.lv_enemy.Name = "lv_enemy";
            this.lv_enemy.ReadOnly = true;
            this.lv_enemy.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.lv_enemy.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // multi_id
            // 
            this.multi_id.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.multi_id.FillWeight = 25F;
            this.multi_id.HeaderText = "ID";
            this.multi_id.Name = "multi_id";
            this.multi_id.ReadOnly = true;
            this.multi_id.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.multi_id.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // comment
            // 
            this.comment.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.comment.FillWeight = 25F;
            this.comment.HeaderText = "コメント";
            this.comment.Name = "comment";
            this.comment.ReadOnly = true;
            this.comment.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.comment.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 729);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.RandomCopy);
            this.Controls.Add(this.SearchStart);
            this.Controls.Add(this.checkedListBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MaximumSize = new System.Drawing.Size(1024, 1080);
            this.MinimumSize = new System.Drawing.Size(640, 480);
            this.Name = "MainWindow";
            this.Text = "Granbluefantasy RaidFinder";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.Button SearchStart;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button RandomCopy;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem Menubar_Menu;
        private System.Windows.Forms.ToolStripMenuItem Menubar_Help;
        private System.Windows.Forms.ToolStripMenuItem Menubar_Close;
        private System.Windows.Forms.ToolStripMenuItem Menubar_WhatthisApp;
        private System.Windows.Forms.ToolStripMenuItem Menubar_Verinfo;
        private System.Windows.Forms.ToolStripMenuItem Menubar_Edit;
        private System.Windows.Forms.ToolStripMenuItem Menubar_ReAuthorize;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ToolStripMenuItem Menubar_ClearResult;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem Menubar_Setting;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.DataGridViewTextBoxColumn lv_enemy;
        private System.Windows.Forms.DataGridViewTextBoxColumn multi_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn comment;
    }
}

