namespace CrapFixer.Views;

partial class TweakerView
{
    private System.ComponentModel.IContainer components = null;
    private SplitContainer splitMain;
    private TabControl tabCategories;
    private TabPage tabWindows;
    private TreeView treeWindows;
    private TabPage tabCustom;
    private TreeView treeCustom;
    private GroupBox grpResults;
    private Panel pnlDetail;
    private ListView lvDetail;
    private ColumnHeader colDetailType;
    private ColumnHeader colDetailValue;
    private Panel pnlDetailHeader;
    private Label lblDetailTitle;
    private Button btnBack;
    private Panel pnlSummary;
    private Panel pnlResultActions;
    private Panel pnlTop;
    private TextBox txtSummary;
    private ProgressBar progressBar;
    private Label lblProgressPercent;
    private ListView lvResults;
    private ColumnHeader colEntry;
    private ColumnHeader colStatus;
    private ColumnHeader colCurrent;
    private Panel pnlBottom;
    private ComboBox cboResultActions;
    private Button btnAnalyze;
    private Button btnRun;
    private ContextMenuStrip cmTree;
    private ToolStripMenuItem miCheckAll;
    private ToolStripMenuItem miUncheckAll;
    private ToolStripSeparator sepTree1;
    private ToolStripMenuItem miAnalyze;
    private ToolStripMenuItem miApply;
    private ToolStripMenuItem miDetails;
    private ToolStripMenuItem miExplain;
    private ToolStripSeparator sepTree2;
    private ToolStripMenuItem miRestore;

    protected override void Dispose(bool disposing)
    {
        if (disposing && components != null) components.Dispose();
        base.Dispose(disposing);
    }

    #region Component Designer generated code

    private void InitializeComponent()
    {
            this.components = new System.ComponentModel.Container();
            this.splitMain = new System.Windows.Forms.SplitContainer();
            this.tabCategories = new System.Windows.Forms.TabControl();
            this.tabWindows = new System.Windows.Forms.TabPage();
            this.treeWindows = new System.Windows.Forms.TreeView();
            this.cmTree = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.miCheckAll = new System.Windows.Forms.ToolStripMenuItem();
            this.miUncheckAll = new System.Windows.Forms.ToolStripMenuItem();
            this.sepTree1 = new System.Windows.Forms.ToolStripSeparator();
            this.miAnalyze = new System.Windows.Forms.ToolStripMenuItem();
            this.miApply = new System.Windows.Forms.ToolStripMenuItem();
            this.miDetails = new System.Windows.Forms.ToolStripMenuItem();
            this.miExplain = new System.Windows.Forms.ToolStripMenuItem();
            this.sepTree2 = new System.Windows.Forms.ToolStripSeparator();
            this.miRestore = new System.Windows.Forms.ToolStripMenuItem();
            this.tabCustom = new System.Windows.Forms.TabPage();
            this.treeCustom = new System.Windows.Forms.TreeView();
            this.grpResults = new System.Windows.Forms.GroupBox();
            this.pnlDetail = new System.Windows.Forms.Panel();
            this.lvDetail = new System.Windows.Forms.ListView();
            this.colDetailType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDetailValue = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pnlDetailHeader = new System.Windows.Forms.Panel();
            this.lblDetailTitle = new System.Windows.Forms.Label();
            this.btnBack = new System.Windows.Forms.Button();
            this.pnlSummary = new System.Windows.Forms.Panel();
            this.lvResults = new System.Windows.Forms.ListView();
            this.colEntry = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCurrent = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pnlResultActions = new System.Windows.Forms.Panel();
            this.cboResultActions = new System.Windows.Forms.ComboBox();
            this.txtSummary = new System.Windows.Forms.TextBox();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.btnRun = new System.Windows.Forms.Button();
            this.btnAnalyze = new System.Windows.Forms.Button();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.lblProgressPercent = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitMain)).BeginInit();
            this.splitMain.Panel1.SuspendLayout();
            this.splitMain.Panel2.SuspendLayout();
            this.splitMain.SuspendLayout();
            this.tabCategories.SuspendLayout();
            this.tabWindows.SuspendLayout();
            this.cmTree.SuspendLayout();
            this.tabCustom.SuspendLayout();
            this.grpResults.SuspendLayout();
            this.pnlDetail.SuspendLayout();
            this.pnlDetailHeader.SuspendLayout();
            this.pnlSummary.SuspendLayout();
            this.pnlResultActions.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitMain
            // 
            this.splitMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitMain.Location = new System.Drawing.Point(6, 6);
            this.splitMain.Name = "splitMain";
            // 
            // splitMain.Panel1
            // 
            this.splitMain.Panel1.Controls.Add(this.tabCategories);
            // 
            // splitMain.Panel2
            // 
            this.splitMain.Panel2.Controls.Add(this.grpResults);
            this.splitMain.Panel2.Controls.Add(this.pnlBottom);
            this.splitMain.Panel2.Controls.Add(this.pnlTop);
            this.splitMain.Size = new System.Drawing.Size(688, 508);
            this.splitMain.SplitterDistance = 300;
            this.splitMain.TabIndex = 0;
            // 
            // tabCategories
            // 
            this.tabCategories.Controls.Add(this.tabWindows);
            this.tabCategories.Controls.Add(this.tabCustom);
            this.tabCategories.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabCategories.Location = new System.Drawing.Point(0, 0);
            this.tabCategories.Name = "tabCategories";
            this.tabCategories.SelectedIndex = 0;
            this.tabCategories.Size = new System.Drawing.Size(300, 508);
            this.tabCategories.TabIndex = 0;
            this.tabCategories.SelectedIndexChanged += new System.EventHandler(this.TabCategories_SelectedIndexChanged);
            // 
            // tabWindows
            // 
            this.tabWindows.Controls.Add(this.treeWindows);
            this.tabWindows.Location = new System.Drawing.Point(4, 22);
            this.tabWindows.Name = "tabWindows";
            this.tabWindows.Padding = new System.Windows.Forms.Padding(3);
            this.tabWindows.Size = new System.Drawing.Size(292, 482);
            this.tabWindows.TabIndex = 0;
            this.tabWindows.Text = "Windows";
            this.tabWindows.UseVisualStyleBackColor = true;
            // 
            // treeWindows
            // 
            this.treeWindows.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.treeWindows.CheckBoxes = true;
            this.treeWindows.ContextMenuStrip = this.cmTree;
            this.treeWindows.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeWindows.HideSelection = false;
            this.treeWindows.Location = new System.Drawing.Point(3, 3);
            this.treeWindows.Name = "treeWindows";
            this.treeWindows.ShowLines = false;
            this.treeWindows.ShowNodeToolTips = true;
            this.treeWindows.ShowPlusMinus = false;
            this.treeWindows.ShowRootLines = false;
            this.treeWindows.Size = new System.Drawing.Size(286, 476);
            this.treeWindows.TabIndex = 0;
            this.treeWindows.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.Tree_AfterCheck);
            this.treeWindows.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.Tree_NodeMouseClick);
            this.treeWindows.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.Tree_NodeMouseDoubleClick);
            // 
            // cmTree
            // 
            this.cmTree.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miCheckAll,
            this.miUncheckAll,
            this.sepTree1,
            this.miAnalyze,
            this.miApply,
            this.miDetails,
            this.miExplain,
            this.sepTree2,
            this.miRestore});
            this.cmTree.Name = "cmTree";
            this.cmTree.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.cmTree.Size = new System.Drawing.Size(182, 170);
            this.cmTree.Opening += new System.ComponentModel.CancelEventHandler(this.CmTree_Opening);
            // 
            // miCheckAll
            // 
            this.miCheckAll.Name = "miCheckAll";
            this.miCheckAll.Size = new System.Drawing.Size(181, 22);
            this.miCheckAll.Text = "Check all";
            this.miCheckAll.Click += new System.EventHandler(this.MiCheckAll_Click);
            // 
            // miUncheckAll
            // 
            this.miUncheckAll.Name = "miUncheckAll";
            this.miUncheckAll.Size = new System.Drawing.Size(181, 22);
            this.miUncheckAll.Text = "Uncheck all";
            this.miUncheckAll.Click += new System.EventHandler(this.MiUncheckAll_Click);
            // 
            // sepTree1
            // 
            this.sepTree1.Name = "sepTree1";
            this.sepTree1.Size = new System.Drawing.Size(178, 6);
            // 
            // miAnalyze
            // 
            this.miAnalyze.Name = "miAnalyze";
            this.miAnalyze.Size = new System.Drawing.Size(181, 22);
            this.miAnalyze.Text = "Analyze";
            this.miAnalyze.Click += new System.EventHandler(this.MiAnalyzeContext_Click);
            // 
            // miApply
            // 
            this.miApply.Name = "miApply";
            this.miApply.Size = new System.Drawing.Size(181, 22);
            this.miApply.Text = "Apply / remove";
            this.miApply.Click += new System.EventHandler(this.MiApplyContext_Click);
            // 
            // miDetails
            // 
            this.miDetails.Name = "miDetails";
            this.miDetails.Size = new System.Drawing.Size(181, 22);
            this.miDetails.Text = "Show details";
            this.miDetails.Click += new System.EventHandler(this.MiDetails_Click);
            // 
            // miExplain
            // 
            this.miExplain.Name = "miExplain";
            this.miExplain.Size = new System.Drawing.Size(181, 22);
            this.miExplain.Text = "Explain with AI";
            this.miExplain.Click += new System.EventHandler(this.MiExplain_Click);
            // 
            // sepTree2
            // 
            this.sepTree2.Name = "sepTree2";
            this.sepTree2.Size = new System.Drawing.Size(178, 6);
            // 
            // miRestore
            // 
            this.miRestore.Name = "miRestore";
            this.miRestore.Size = new System.Drawing.Size(181, 22);
            this.miRestore.Text = "Restore default state";
            this.miRestore.Click += new System.EventHandler(this.RestoreItem_Click);
            // 
            // tabCustom
            // 
            this.tabCustom.Controls.Add(this.treeCustom);
            this.tabCustom.Location = new System.Drawing.Point(4, 22);
            this.tabCustom.Name = "tabCustom";
            this.tabCustom.Padding = new System.Windows.Forms.Padding(3);
            this.tabCustom.Size = new System.Drawing.Size(292, 482);
            this.tabCustom.TabIndex = 1;
            this.tabCustom.Text = "Custom";
            this.tabCustom.UseVisualStyleBackColor = true;
            // 
            // treeCustom
            // 
            this.treeCustom.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.treeCustom.CheckBoxes = true;
            this.treeCustom.ContextMenuStrip = this.cmTree;
            this.treeCustom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeCustom.HideSelection = false;
            this.treeCustom.Location = new System.Drawing.Point(3, 3);
            this.treeCustom.Name = "treeCustom";
            this.treeCustom.ShowLines = false;
            this.treeCustom.ShowNodeToolTips = true;
            this.treeCustom.ShowPlusMinus = false;
            this.treeCustom.ShowRootLines = false;
            this.treeCustom.Size = new System.Drawing.Size(286, 476);
            this.treeCustom.TabIndex = 0;
            this.treeCustom.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.Tree_AfterCheck);
            this.treeCustom.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.Tree_NodeMouseClick);
            this.treeCustom.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.Tree_NodeMouseDoubleClick);
            // 
            // grpResults
            // 
            this.grpResults.Controls.Add(this.pnlDetail);
            this.grpResults.Controls.Add(this.pnlSummary);
            this.grpResults.Controls.Add(this.txtSummary);
            this.grpResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpResults.Location = new System.Drawing.Point(0, 14);
            this.grpResults.Name = "grpResults";
            this.grpResults.Size = new System.Drawing.Size(384, 454);
            this.grpResults.TabIndex = 0;
            this.grpResults.TabStop = false;
            // 
            // pnlDetail
            // 
            this.pnlDetail.Controls.Add(this.lvDetail);
            this.pnlDetail.Controls.Add(this.pnlDetailHeader);
            this.pnlDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDetail.Location = new System.Drawing.Point(3, 112);
            this.pnlDetail.Name = "pnlDetail";
            this.pnlDetail.Size = new System.Drawing.Size(378, 339);
            this.pnlDetail.TabIndex = 1;
            this.pnlDetail.Visible = false;
            // 
            // lvDetail
            // 
            this.lvDetail.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lvDetail.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colDetailType,
            this.colDetailValue});
            this.lvDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvDetail.FullRowSelect = true;
            this.lvDetail.HideSelection = false;
            this.lvDetail.Location = new System.Drawing.Point(0, 28);
            this.lvDetail.Name = "lvDetail";
            this.lvDetail.Size = new System.Drawing.Size(378, 311);
            this.lvDetail.TabIndex = 1;
            this.lvDetail.UseCompatibleStateImageBehavior = false;
            this.lvDetail.View = System.Windows.Forms.View.Details;
            // 
            // colDetailType
            // 
            this.colDetailType.Text = "Type";
            this.colDetailType.Width = 95;
            // 
            // colDetailValue
            // 
            this.colDetailValue.Text = "Details";
            this.colDetailValue.Width = 275;
            // 
            // pnlDetailHeader
            // 
            this.pnlDetailHeader.Controls.Add(this.lblDetailTitle);
            this.pnlDetailHeader.Controls.Add(this.btnBack);
            this.pnlDetailHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlDetailHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlDetailHeader.Name = "pnlDetailHeader";
            this.pnlDetailHeader.Size = new System.Drawing.Size(378, 28);
            this.pnlDetailHeader.TabIndex = 0;
            // 
            // lblDetailTitle
            // 
            this.lblDetailTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDetailTitle.AutoEllipsis = true;
            this.lblDetailTitle.Location = new System.Drawing.Point(152, 7);
            this.lblDetailTitle.Name = "lblDetailTitle";
            this.lblDetailTitle.Size = new System.Drawing.Size(222, 17);
            this.lblDetailTitle.TabIndex = 1;
            // 
            // btnBack
            // 
            this.btnBack.FlatAppearance.BorderColor = System.Drawing.Color.LightSteelBlue;
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Location = new System.Drawing.Point(3, 3);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(143, 22);
            this.btnBack.TabIndex = 0;
            this.btnBack.Text = "< View summary results";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.BtnBack_Click);
            // 
            // pnlSummary
            // 
            this.pnlSummary.Controls.Add(this.lvResults);
            this.pnlSummary.Controls.Add(this.pnlResultActions);
            this.pnlSummary.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSummary.Location = new System.Drawing.Point(3, 112);
            this.pnlSummary.Name = "pnlSummary";
            this.pnlSummary.Size = new System.Drawing.Size(378, 339);
            this.pnlSummary.TabIndex = 0;
            this.pnlSummary.Visible = false;
            // 
            // lvResults
            // 
            this.lvResults.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lvResults.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colEntry,
            this.colStatus,
            this.colCurrent});
            this.lvResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvResults.FullRowSelect = true;
            this.lvResults.HideSelection = false;
            this.lvResults.Location = new System.Drawing.Point(0, 0);
            this.lvResults.Name = "lvResults";
            this.lvResults.Size = new System.Drawing.Size(378, 308);
            this.lvResults.TabIndex = 1;
            this.lvResults.UseCompatibleStateImageBehavior = false;
            this.lvResults.View = System.Windows.Forms.View.Details;
            this.lvResults.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.Results_ColumnClick);
            this.lvResults.DoubleClick += new System.EventHandler(this.Results_DoubleClick);
            // 
            // colEntry
            // 
            this.colEntry.Text = "Entry";
            this.colEntry.Width = 155;
            // 
            // colStatus
            // 
            this.colStatus.Text = "Status";
            this.colStatus.Width = 85;
            // 
            // colCurrent
            // 
            this.colCurrent.Text = "Current";
            this.colCurrent.Width = 130;
            // 
            // pnlResultActions
            // 
            this.pnlResultActions.Controls.Add(this.cboResultActions);
            this.pnlResultActions.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlResultActions.Location = new System.Drawing.Point(0, 308);
            this.pnlResultActions.Name = "pnlResultActions";
            this.pnlResultActions.Padding = new System.Windows.Forms.Padding(0, 4, 0, 4);
            this.pnlResultActions.Size = new System.Drawing.Size(378, 31);
            this.pnlResultActions.TabIndex = 0;
            this.pnlResultActions.Visible = false;
            // 
            // cboResultActions
            // 
            this.cboResultActions.Dock = System.Windows.Forms.DockStyle.Top;
            this.cboResultActions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboResultActions.DropDownWidth = 378;
            this.cboResultActions.Enabled = false;
            this.cboResultActions.FormattingEnabled = true;
            this.cboResultActions.Items.AddRange(new object[] {
            "Result actions...",
            "Analyze results online",
            "Copy results to clipboard"});
            this.cboResultActions.Location = new System.Drawing.Point(0, 4);
            this.cboResultActions.Name = "cboResultActions";
            this.cboResultActions.Size = new System.Drawing.Size(378, 21);
            this.cboResultActions.TabIndex = 0;
            this.cboResultActions.SelectedIndexChanged += new System.EventHandler(this.ResultActions_SelectedIndexChanged);
            // 
            // txtSummary
            // 
            this.txtSummary.BackColor = System.Drawing.Color.White;
            this.txtSummary.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSummary.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtSummary.ForeColor = System.Drawing.Color.DimGray;
            this.txtSummary.Location = new System.Drawing.Point(3, 16);
            this.txtSummary.Margin = new System.Windows.Forms.Padding(5, 3, 3, 3);
            this.txtSummary.Multiline = true;
            this.txtSummary.Name = "txtSummary";
            this.txtSummary.ReadOnly = true;
            this.txtSummary.Size = new System.Drawing.Size(378, 96);
            this.txtSummary.TabIndex = 2;
            this.txtSummary.TabStop = false;
            this.txtSummary.Text = "Loading databases...";
            this.txtSummary.WordWrap = false;
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.btnRun);
            this.pnlBottom.Controls.Add(this.btnAnalyze);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 468);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(384, 40);
            this.pnlBottom.TabIndex = 2;
            // 
            // btnRun
            // 
            this.btnRun.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRun.Location = new System.Drawing.Point(261, 7);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(120, 30);
            this.btnRun.TabIndex = 2;
            this.btnRun.Text = "Run Fixer";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.Run_Click);
            // 
            // btnAnalyze
            // 
            this.btnAnalyze.Location = new System.Drawing.Point(0, 7);
            this.btnAnalyze.Name = "btnAnalyze";
            this.btnAnalyze.Size = new System.Drawing.Size(130, 30);
            this.btnAnalyze.TabIndex = 0;
            this.btnAnalyze.Text = "Analyze";
            this.btnAnalyze.UseVisualStyleBackColor = true;
            this.btnAnalyze.Click += new System.EventHandler(this.Analyze_Click);
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.progressBar);
            this.pnlTop.Controls.Add(this.lblProgressPercent);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(384, 14);
            this.pnlTop.TabIndex = 1;
            // 
            // progressBar
            // 
            this.progressBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.progressBar.Location = new System.Drawing.Point(0, 0);
            this.progressBar.MarqueeAnimationSpeed = 25;
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(333, 14);
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar.TabIndex = 1;
            this.progressBar.Visible = false;
            // 
            // lblProgressPercent
            // 
            this.lblProgressPercent.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblProgressPercent.Location = new System.Drawing.Point(333, 0);
            this.lblProgressPercent.Name = "lblProgressPercent";
            this.lblProgressPercent.Size = new System.Drawing.Size(51, 14);
            this.lblProgressPercent.TabIndex = 0;
            this.lblProgressPercent.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblProgressPercent.Visible = false;
            // 
            // TweakerView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.splitMain);
            this.Name = "TweakerView";
            this.Padding = new System.Windows.Forms.Padding(6);
            this.Size = new System.Drawing.Size(700, 520);
            this.splitMain.Panel1.ResumeLayout(false);
            this.splitMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitMain)).EndInit();
            this.splitMain.ResumeLayout(false);
            this.tabCategories.ResumeLayout(false);
            this.tabWindows.ResumeLayout(false);
            this.cmTree.ResumeLayout(false);
            this.tabCustom.ResumeLayout(false);
            this.grpResults.ResumeLayout(false);
            this.grpResults.PerformLayout();
            this.pnlDetail.ResumeLayout(false);
            this.pnlDetailHeader.ResumeLayout(false);
            this.pnlSummary.ResumeLayout(false);
            this.pnlResultActions.ResumeLayout(false);
            this.pnlBottom.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.ResumeLayout(false);

    }

    #endregion
}
