namespace GameBrowser
{
    partial class frmBrowser
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.sbrlbl_Status = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.spcWindowSplitter = new System.Windows.Forms.SplitContainer();
            this.grdServerList = new System.Windows.Forms.DataGridView();
            this.colServerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colServerIP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colServerPort = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colServerPing = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colServerPlayerCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colServerMod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colServerMap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.spcPlayersAndInfo = new System.Windows.Forms.SplitContainer();
            this.grdPlayerInfo = new System.Windows.Forms.DataGridView();
            this.colPlyInf_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPlyInf_Points = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPlyInf_Ping = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grdServerInfo = new System.Windows.Forms.DataGridView();
            this.colSvrInf_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSvrInf_Value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mnuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFileExit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuServer = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuServerManage = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuServerSelected = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuServerSelectedRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTools = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuToolsOptions = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHelpAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1.SuspendLayout();
            this.spcWindowSplitter.Panel1.SuspendLayout();
            this.spcWindowSplitter.Panel2.SuspendLayout();
            this.spcWindowSplitter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdServerList)).BeginInit();
            this.spcPlayersAndInfo.Panel1.SuspendLayout();
            this.spcPlayersAndInfo.Panel2.SuspendLayout();
            this.spcPlayersAndInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdPlayerInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdServerInfo)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sbrlbl_Status,
            this.toolStripProgressBar1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 376);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(663, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // sbrlbl_Status
            // 
            this.sbrlbl_Status.AutoSize = false;
            this.sbrlbl_Status.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.sbrlbl_Status.Name = "sbrlbl_Status";
            this.sbrlbl_Status.Size = new System.Drawing.Size(300, 17);
            this.sbrlbl_Status.Text = "Ready";
            this.sbrlbl_Status.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.AutoSize = false;
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(200, 16);
            // 
            // spcWindowSplitter
            // 
            this.spcWindowSplitter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spcWindowSplitter.Location = new System.Drawing.Point(0, 24);
            this.spcWindowSplitter.Name = "spcWindowSplitter";
            this.spcWindowSplitter.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // spcWindowSplitter.Panel1
            // 
            this.spcWindowSplitter.Panel1.Controls.Add(this.grdServerList);
            // 
            // spcWindowSplitter.Panel2
            // 
            this.spcWindowSplitter.Panel2.Controls.Add(this.spcPlayersAndInfo);
            this.spcWindowSplitter.Size = new System.Drawing.Size(663, 352);
            this.spcWindowSplitter.SplitterDistance = 144;
            this.spcWindowSplitter.TabIndex = 2;
            // 
            // grdServerList
            // 
            this.grdServerList.AllowUserToAddRows = false;
            this.grdServerList.AllowUserToDeleteRows = false;
            this.grdServerList.AllowUserToResizeColumns = false;
            this.grdServerList.AllowUserToResizeRows = false;
            this.grdServerList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grdServerList.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            this.grdServerList.ColumnHeadersHeight = 20;
            this.grdServerList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.grdServerList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colServerName,
            this.colServerIP,
            this.colServerPort,
            this.colServerPing,
            this.colServerPlayerCount,
            this.colServerMod,
            this.colServerMap});
            this.grdServerList.Location = new System.Drawing.Point(0, 0);
            this.grdServerList.Name = "grdServerList";
            this.grdServerList.ReadOnly = true;
            this.grdServerList.RowHeadersVisible = false;
            this.grdServerList.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.grdServerList.RowTemplate.Height = 20;
            this.grdServerList.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.grdServerList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdServerList.Size = new System.Drawing.Size(663, 144);
            this.grdServerList.TabIndex = 3;
            this.grdServerList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdServerList_CellClick);
            // 
            // colServerName
            // 
            this.colServerName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colServerName.HeaderText = "Name";
            this.colServerName.Name = "colServerName";
            this.colServerName.ReadOnly = true;
            // 
            // colServerIP
            // 
            this.colServerIP.HeaderText = "IP Address";
            this.colServerIP.MaxInputLength = 15;
            this.colServerIP.MinimumWidth = 120;
            this.colServerIP.Name = "colServerIP";
            this.colServerIP.ReadOnly = true;
            this.colServerIP.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colServerIP.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colServerIP.Width = 120;
            // 
            // colServerPort
            // 
            this.colServerPort.HeaderText = "Port";
            this.colServerPort.MaxInputLength = 5;
            this.colServerPort.MinimumWidth = 80;
            this.colServerPort.Name = "colServerPort";
            this.colServerPort.ReadOnly = true;
            this.colServerPort.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colServerPort.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colServerPort.Width = 80;
            // 
            // colServerPing
            // 
            this.colServerPing.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colServerPing.HeaderText = "Ping (ms)";
            this.colServerPing.MaxInputLength = 6;
            this.colServerPing.MinimumWidth = 60;
            this.colServerPing.Name = "colServerPing";
            this.colServerPing.ReadOnly = true;
            this.colServerPing.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colServerPing.Width = 60;
            // 
            // colServerPlayerCount
            // 
            this.colServerPlayerCount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colServerPlayerCount.HeaderText = "Players";
            this.colServerPlayerCount.MaxInputLength = 10;
            this.colServerPlayerCount.MinimumWidth = 80;
            this.colServerPlayerCount.Name = "colServerPlayerCount";
            this.colServerPlayerCount.ReadOnly = true;
            this.colServerPlayerCount.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colServerPlayerCount.Width = 80;
            // 
            // colServerMod
            // 
            this.colServerMod.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colServerMod.HeaderText = "Mod";
            this.colServerMod.MaxInputLength = 30;
            this.colServerMod.MinimumWidth = 90;
            this.colServerMod.Name = "colServerMod";
            this.colServerMod.ReadOnly = true;
            this.colServerMod.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colServerMod.Width = 90;
            // 
            // colServerMap
            // 
            this.colServerMap.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colServerMap.HeaderText = "Map";
            this.colServerMap.MaxInputLength = 20;
            this.colServerMap.MinimumWidth = 80;
            this.colServerMap.Name = "colServerMap";
            this.colServerMap.ReadOnly = true;
            this.colServerMap.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colServerMap.Width = 80;
            // 
            // spcPlayersAndInfo
            // 
            this.spcPlayersAndInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spcPlayersAndInfo.Location = new System.Drawing.Point(0, 0);
            this.spcPlayersAndInfo.Name = "spcPlayersAndInfo";
            // 
            // spcPlayersAndInfo.Panel1
            // 
            this.spcPlayersAndInfo.Panel1.Controls.Add(this.grdPlayerInfo);
            // 
            // spcPlayersAndInfo.Panel2
            // 
            this.spcPlayersAndInfo.Panel2.Controls.Add(this.grdServerInfo);
            this.spcPlayersAndInfo.Size = new System.Drawing.Size(663, 204);
            this.spcPlayersAndInfo.SplitterDistance = 422;
            this.spcPlayersAndInfo.TabIndex = 3;
            // 
            // grdPlayerInfo
            // 
            this.grdPlayerInfo.AllowUserToAddRows = false;
            this.grdPlayerInfo.AllowUserToDeleteRows = false;
            this.grdPlayerInfo.ColumnHeadersHeight = 20;
            this.grdPlayerInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.grdPlayerInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colPlyInf_Name,
            this.colPlyInf_Points,
            this.colPlyInf_Ping});
            this.grdPlayerInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdPlayerInfo.Location = new System.Drawing.Point(0, 0);
            this.grdPlayerInfo.Name = "grdPlayerInfo";
            this.grdPlayerInfo.ReadOnly = true;
            this.grdPlayerInfo.RowHeadersVisible = false;
            this.grdPlayerInfo.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.grdPlayerInfo.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.grdPlayerInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdPlayerInfo.Size = new System.Drawing.Size(422, 204);
            this.grdPlayerInfo.TabIndex = 0;
            // 
            // colPlyInf_Name
            // 
            this.colPlyInf_Name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colPlyInf_Name.HeaderText = "Player Name";
            this.colPlyInf_Name.Name = "colPlyInf_Name";
            this.colPlyInf_Name.ReadOnly = true;
            this.colPlyInf_Name.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // colPlyInf_Points
            // 
            this.colPlyInf_Points.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colPlyInf_Points.HeaderText = "Points";
            this.colPlyInf_Points.MinimumWidth = 100;
            this.colPlyInf_Points.Name = "colPlyInf_Points";
            this.colPlyInf_Points.ReadOnly = true;
            this.colPlyInf_Points.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // colPlyInf_Ping
            // 
            this.colPlyInf_Ping.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colPlyInf_Ping.HeaderText = "Ping";
            this.colPlyInf_Ping.MinimumWidth = 100;
            this.colPlyInf_Ping.Name = "colPlyInf_Ping";
            this.colPlyInf_Ping.ReadOnly = true;
            this.colPlyInf_Ping.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // grdServerInfo
            // 
            this.grdServerInfo.AllowUserToAddRows = false;
            this.grdServerInfo.AllowUserToDeleteRows = false;
            this.grdServerInfo.AllowUserToResizeColumns = false;
            this.grdServerInfo.AllowUserToResizeRows = false;
            this.grdServerInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grdServerInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdServerInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSvrInf_Name,
            this.colSvrInf_Value});
            this.grdServerInfo.Location = new System.Drawing.Point(0, 0);
            this.grdServerInfo.Name = "grdServerInfo";
            this.grdServerInfo.ReadOnly = true;
            this.grdServerInfo.RowHeadersVisible = false;
            this.grdServerInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdServerInfo.Size = new System.Drawing.Size(237, 204);
            this.grdServerInfo.TabIndex = 0;
            // 
            // colSvrInf_Name
            // 
            this.colSvrInf_Name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colSvrInf_Name.HeaderText = "Name";
            this.colSvrInf_Name.MinimumWidth = 110;
            this.colSvrInf_Name.Name = "colSvrInf_Name";
            this.colSvrInf_Name.ReadOnly = true;
            this.colSvrInf_Name.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colSvrInf_Name.Width = 110;
            // 
            // colSvrInf_Value
            // 
            this.colSvrInf_Value.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colSvrInf_Value.HeaderText = "Value";
            this.colSvrInf_Value.Name = "colSvrInf_Value";
            this.colSvrInf_Value.ReadOnly = true;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFile,
            this.mnuServer,
            this.mnuTools,
            this.mnuHelp});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.menuStrip1.Size = new System.Drawing.Size(663, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mnuFile
            // 
            this.mnuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFileExit});
            this.mnuFile.Name = "mnuFile";
            this.mnuFile.Size = new System.Drawing.Size(36, 20);
            this.mnuFile.Text = "&File";
            // 
            // mnuFileExit
            // 
            this.mnuFileExit.Name = "mnuFileExit";
            this.mnuFileExit.Size = new System.Drawing.Size(97, 22);
            this.mnuFileExit.Text = "E&xit";
            this.mnuFileExit.Click += new System.EventHandler(this.mnuFileExit_Click);
            // 
            // mnuServer
            // 
            this.mnuServer.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuServerManage,
            this.mnuServerSelected});
            this.mnuServer.Name = "mnuServer";
            this.mnuServer.Size = new System.Drawing.Size(49, 20);
            this.mnuServer.Text = "&Server";
            // 
            // mnuServerManage
            // 
            this.mnuServerManage.Enabled = false;
            this.mnuServerManage.Name = "mnuServerManage";
            this.mnuServerManage.Size = new System.Drawing.Size(121, 22);
            this.mnuServerManage.Text = "&Manage";
            // 
            // mnuServerSelected
            // 
            this.mnuServerSelected.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuServerSelectedRefresh});
            this.mnuServerSelected.Enabled = false;
            this.mnuServerSelected.Name = "mnuServerSelected";
            this.mnuServerSelected.Size = new System.Drawing.Size(121, 22);
            this.mnuServerSelected.Text = "&Selected";
            // 
            // mnuServerSelectedRefresh
            // 
            this.mnuServerSelectedRefresh.Enabled = false;
            this.mnuServerSelectedRefresh.Name = "mnuServerSelectedRefresh";
            this.mnuServerSelectedRefresh.Size = new System.Drawing.Size(116, 22);
            this.mnuServerSelectedRefresh.Text = "&Refresh";
            this.mnuServerSelectedRefresh.Click += new System.EventHandler(this.mnuServerSelectedRefresh_Click);
            // 
            // mnuTools
            // 
            this.mnuTools.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuToolsOptions});
            this.mnuTools.Name = "mnuTools";
            this.mnuTools.Size = new System.Drawing.Size(44, 20);
            this.mnuTools.Text = "&Tools";
            // 
            // mnuToolsOptions
            // 
            this.mnuToolsOptions.Enabled = false;
            this.mnuToolsOptions.Name = "mnuToolsOptions";
            this.mnuToolsOptions.Size = new System.Drawing.Size(117, 22);
            this.mnuToolsOptions.Text = "&Options";
            // 
            // mnuHelp
            // 
            this.mnuHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuHelpAbout});
            this.mnuHelp.Name = "mnuHelp";
            this.mnuHelp.Size = new System.Drawing.Size(41, 20);
            this.mnuHelp.Text = "&Help";
            // 
            // mnuHelpAbout
            // 
            this.mnuHelpAbout.Name = "mnuHelpAbout";
            this.mnuHelpAbout.Size = new System.Drawing.Size(108, 22);
            this.mnuHelpAbout.Text = "&About";
            this.mnuHelpAbout.Click += new System.EventHandler(this.mnuHelpAbout_Click);
            // 
            // frmBrowser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(663, 398);
            this.Controls.Add(this.spcWindowSplitter);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmBrowser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GameBrowser";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.spcWindowSplitter.Panel1.ResumeLayout(false);
            this.spcWindowSplitter.Panel2.ResumeLayout(false);
            this.spcWindowSplitter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdServerList)).EndInit();
            this.spcPlayersAndInfo.Panel1.ResumeLayout(false);
            this.spcPlayersAndInfo.Panel2.ResumeLayout(false);
            this.spcPlayersAndInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdPlayerInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdServerInfo)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel sbrlbl_Status;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.SplitContainer spcWindowSplitter;
        private System.Windows.Forms.DataGridView grdServerList;
        private System.Windows.Forms.SplitContainer spcPlayersAndInfo;
        private System.Windows.Forms.DataGridView grdPlayerInfo;
        private System.Windows.Forms.DataGridView grdServerInfo;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnuFile;
        private System.Windows.Forms.ToolStripMenuItem mnuFileExit;
        private System.Windows.Forms.ToolStripMenuItem mnuServer;
        private System.Windows.Forms.ToolStripMenuItem mnuServerManage;
        private System.Windows.Forms.ToolStripMenuItem mnuTools;
        private System.Windows.Forms.ToolStripMenuItem mnuToolsOptions;
        private System.Windows.Forms.ToolStripMenuItem mnuHelp;
        private System.Windows.Forms.ToolStripMenuItem mnuHelpAbout;
        private System.Windows.Forms.ToolStripMenuItem mnuServerSelected;
        private System.Windows.Forms.ToolStripMenuItem mnuServerSelectedRefresh;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSvrInf_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSvrInf_Value;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPlyInf_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPlyInf_Points;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPlyInf_Ping;
        private System.Windows.Forms.DataGridViewTextBoxColumn colServerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colServerIP;
        private System.Windows.Forms.DataGridViewTextBoxColumn colServerPort;
        private System.Windows.Forms.DataGridViewTextBoxColumn colServerPing;
        private System.Windows.Forms.DataGridViewTextBoxColumn colServerPlayerCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colServerMod;
        private System.Windows.Forms.DataGridViewTextBoxColumn colServerMap;

    }
}

