namespace GameBrowser.UI
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
            this.serverListGrid = new System.Windows.Forms.DataGridView();
            this.colServerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colServerIP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colServerPort = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colServerPing = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colServerPlayerCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colServerMod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colServerMap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.spcPlayersAndInfo = new System.Windows.Forms.SplitContainer();
            this.playerListGrid = new System.Windows.Forms.DataGridView();
            this.colPlyInf_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPlyInf_Points = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPlyInf_Ping = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.serverInfoGrid = new System.Windows.Forms.DataGridView();
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
            ((System.ComponentModel.ISupportInitialize)(this.spcWindowSplitter)).BeginInit();
            this.spcWindowSplitter.Panel1.SuspendLayout();
            this.spcWindowSplitter.Panel2.SuspendLayout();
            this.spcWindowSplitter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.serverListGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spcPlayersAndInfo)).BeginInit();
            this.spcPlayersAndInfo.Panel1.SuspendLayout();
            this.spcPlayersAndInfo.Panel2.SuspendLayout();
            this.spcPlayersAndInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.playerListGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.serverInfoGrid)).BeginInit();
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
            this.spcWindowSplitter.Panel1.Controls.Add(this.serverListGrid);
            // 
            // spcWindowSplitter.Panel2
            // 
            this.spcWindowSplitter.Panel2.Controls.Add(this.spcPlayersAndInfo);
            this.spcWindowSplitter.Size = new System.Drawing.Size(663, 352);
            this.spcWindowSplitter.SplitterDistance = 144;
            this.spcWindowSplitter.TabIndex = 2;
            // 
            // serverListGrid
            // 
            this.serverListGrid.AllowUserToAddRows = false;
            this.serverListGrid.AllowUserToDeleteRows = false;
            this.serverListGrid.AllowUserToResizeColumns = false;
            this.serverListGrid.AllowUserToResizeRows = false;
            this.serverListGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.serverListGrid.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            this.serverListGrid.ColumnHeadersHeight = 20;
            this.serverListGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.serverListGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colServerName,
            this.colServerIP,
            this.colServerPort,
            this.colServerPing,
            this.colServerPlayerCount,
            this.colServerMod,
            this.colServerMap});
            this.serverListGrid.Location = new System.Drawing.Point(0, 0);
            this.serverListGrid.Name = "serverListGrid";
            this.serverListGrid.ReadOnly = true;
            this.serverListGrid.RowHeadersVisible = false;
            this.serverListGrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.serverListGrid.RowTemplate.Height = 20;
            this.serverListGrid.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.serverListGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.serverListGrid.Size = new System.Drawing.Size(663, 144);
            this.serverListGrid.TabIndex = 3;
            this.serverListGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdServerList_CellClick);
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
            this.spcPlayersAndInfo.Panel1.Controls.Add(this.playerListGrid);
            // 
            // spcPlayersAndInfo.Panel2
            // 
            this.spcPlayersAndInfo.Panel2.Controls.Add(this.serverInfoGrid);
            this.spcPlayersAndInfo.Size = new System.Drawing.Size(663, 204);
            this.spcPlayersAndInfo.SplitterDistance = 422;
            this.spcPlayersAndInfo.TabIndex = 3;
            // 
            // playerListGrid
            // 
            this.playerListGrid.AllowUserToAddRows = false;
            this.playerListGrid.AllowUserToDeleteRows = false;
            this.playerListGrid.ColumnHeadersHeight = 20;
            this.playerListGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.playerListGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colPlyInf_Name,
            this.colPlyInf_Points,
            this.colPlyInf_Ping});
            this.playerListGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.playerListGrid.Location = new System.Drawing.Point(0, 0);
            this.playerListGrid.Name = "playerListGrid";
            this.playerListGrid.ReadOnly = true;
            this.playerListGrid.RowHeadersVisible = false;
            this.playerListGrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.playerListGrid.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.playerListGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.playerListGrid.Size = new System.Drawing.Size(422, 204);
            this.playerListGrid.TabIndex = 0;
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
            // serverInfoGrid
            // 
            this.serverInfoGrid.AllowUserToAddRows = false;
            this.serverInfoGrid.AllowUserToDeleteRows = false;
            this.serverInfoGrid.AllowUserToResizeColumns = false;
            this.serverInfoGrid.AllowUserToResizeRows = false;
            this.serverInfoGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.serverInfoGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.serverInfoGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSvrInf_Name,
            this.colSvrInf_Value});
            this.serverInfoGrid.Location = new System.Drawing.Point(0, 0);
            this.serverInfoGrid.Name = "serverInfoGrid";
            this.serverInfoGrid.ReadOnly = true;
            this.serverInfoGrid.RowHeadersVisible = false;
            this.serverInfoGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.serverInfoGrid.Size = new System.Drawing.Size(237, 204);
            this.serverInfoGrid.TabIndex = 0;
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
            this.mnuFile.Size = new System.Drawing.Size(37, 20);
            this.mnuFile.Text = "&File";
            // 
            // mnuFileExit
            // 
            this.mnuFileExit.Name = "mnuFileExit";
            this.mnuFileExit.Size = new System.Drawing.Size(93, 22);
            this.mnuFileExit.Text = "E&xit";
            this.mnuFileExit.Click += new System.EventHandler(this.mnuFileExit_Click);
            // 
            // mnuServer
            // 
            this.mnuServer.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuServerManage,
            this.mnuServerSelected});
            this.mnuServer.Name = "mnuServer";
            this.mnuServer.Size = new System.Drawing.Size(51, 20);
            this.mnuServer.Text = "&Server";
            // 
            // mnuServerManage
            // 
            this.mnuServerManage.Enabled = false;
            this.mnuServerManage.Name = "mnuServerManage";
            this.mnuServerManage.Size = new System.Drawing.Size(118, 22);
            this.mnuServerManage.Text = "&Manage";
            // 
            // mnuServerSelected
            // 
            this.mnuServerSelected.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuServerSelectedRefresh});
            this.mnuServerSelected.Enabled = false;
            this.mnuServerSelected.Name = "mnuServerSelected";
            this.mnuServerSelected.Size = new System.Drawing.Size(118, 22);
            this.mnuServerSelected.Text = "&Selected";
            // 
            // mnuServerSelectedRefresh
            // 
            this.mnuServerSelectedRefresh.Enabled = false;
            this.mnuServerSelectedRefresh.Name = "mnuServerSelectedRefresh";
            this.mnuServerSelectedRefresh.Size = new System.Drawing.Size(113, 22);
            this.mnuServerSelectedRefresh.Text = "&Refresh";
            this.mnuServerSelectedRefresh.Click += new System.EventHandler(this.mnuServerSelectedRefresh_Click);
            // 
            // mnuTools
            // 
            this.mnuTools.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuToolsOptions});
            this.mnuTools.Name = "mnuTools";
            this.mnuTools.Size = new System.Drawing.Size(46, 20);
            this.mnuTools.Text = "&Tools";
            // 
            // mnuToolsOptions
            // 
            this.mnuToolsOptions.Enabled = false;
            this.mnuToolsOptions.Name = "mnuToolsOptions";
            this.mnuToolsOptions.Size = new System.Drawing.Size(116, 22);
            this.mnuToolsOptions.Text = "&Options";
            // 
            // mnuHelp
            // 
            this.mnuHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuHelpAbout});
            this.mnuHelp.Name = "mnuHelp";
            this.mnuHelp.Size = new System.Drawing.Size(44, 20);
            this.mnuHelp.Text = "&Help";
            // 
            // mnuHelpAbout
            // 
            this.mnuHelpAbout.Name = "mnuHelpAbout";
            this.mnuHelpAbout.Size = new System.Drawing.Size(107, 22);
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
            ((System.ComponentModel.ISupportInitialize)(this.spcWindowSplitter)).EndInit();
            this.spcWindowSplitter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.serverListGrid)).EndInit();
            this.spcPlayersAndInfo.Panel1.ResumeLayout(false);
            this.spcPlayersAndInfo.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spcPlayersAndInfo)).EndInit();
            this.spcPlayersAndInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.playerListGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.serverInfoGrid)).EndInit();
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
        private System.Windows.Forms.DataGridView serverListGrid;
        private System.Windows.Forms.SplitContainer spcPlayersAndInfo;
        private System.Windows.Forms.DataGridView playerListGrid;
        private System.Windows.Forms.DataGridView serverInfoGrid;
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

