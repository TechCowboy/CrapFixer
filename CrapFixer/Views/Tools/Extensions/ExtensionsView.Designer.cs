namespace CrapFixer.Views.Tools.Extensions;

partial class ExtensionsView
{
    private System.ComponentModel.IContainer components = null;
    private Label lblInfo;
    private ProgressBar progressBar;
    private ListView lvExtensions;
    private ColumnHeader colName;
    private ColumnHeader colStatus;
    private ColumnHeader colVersion;
    private Panel pnlDetails;
    private Label lblDescription;
    private TextBox txtOutput;
    private Panel pnlButtons;
    private Button btnRefresh;
    private Button btnInstall;
    private Button btnRemove;
    private Button btnRun;

    protected override void Dispose(bool disposing)
    {
        if (disposing && components != null) components.Dispose();
        base.Dispose(disposing);
    }

    #region Component Designer generated code

    private void InitializeComponent()
    {
        this.lblInfo = new System.Windows.Forms.Label();
        this.progressBar = new System.Windows.Forms.ProgressBar();
        this.lvExtensions = new System.Windows.Forms.ListView();
        this.colName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
        this.colStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
        this.colVersion = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
        this.pnlDetails = new System.Windows.Forms.Panel();
        this.txtOutput = new System.Windows.Forms.TextBox();
        this.lblDescription = new System.Windows.Forms.Label();
        this.pnlButtons = new System.Windows.Forms.Panel();
        this.btnRun = new System.Windows.Forms.Button();
        this.btnRemove = new System.Windows.Forms.Button();
        this.btnInstall = new System.Windows.Forms.Button();
        this.btnRefresh = new System.Windows.Forms.Button();
        this.pnlDetails.SuspendLayout();
        this.pnlButtons.SuspendLayout();
        this.SuspendLayout();
        // 
        // lblInfo
        // 
        this.lblInfo.AutoEllipsis = true;
        this.lblInfo.Dock = System.Windows.Forms.DockStyle.Top;
        this.lblInfo.ForeColor = System.Drawing.Color.DimGray;
        this.lblInfo.Location = new System.Drawing.Point(4, 4);
        this.lblInfo.Name = "lblInfo";
        this.lblInfo.Padding = new System.Windows.Forms.Padding(2, 5, 0, 0);
        this.lblInfo.Size = new System.Drawing.Size(536, 31);
        this.lblInfo.TabIndex = 0;
        this.lblInfo.Text = "Open this page to load the extension catalog.";
        // 
        // progressBar
        // 
        this.progressBar.Dock = System.Windows.Forms.DockStyle.Top;
        this.progressBar.Location = new System.Drawing.Point(4, 35);
        this.progressBar.MarqueeAnimationSpeed = 25;
        this.progressBar.Name = "progressBar";
        this.progressBar.Size = new System.Drawing.Size(536, 3);
        this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
        this.progressBar.TabIndex = 1;
        this.progressBar.Visible = false;
        // 
        // lvExtensions
        // 
        this.lvExtensions.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { this.colName, this.colStatus, this.colVersion });
        this.lvExtensions.Dock = System.Windows.Forms.DockStyle.Fill;
        this.lvExtensions.FullRowSelect = true;
        this.lvExtensions.HideSelection = false;
        this.lvExtensions.Location = new System.Drawing.Point(4, 38);
        this.lvExtensions.MultiSelect = false;
        this.lvExtensions.Name = "lvExtensions";
        this.lvExtensions.Size = new System.Drawing.Size(536, 237);
        this.lvExtensions.TabIndex = 2;
        this.lvExtensions.UseCompatibleStateImageBehavior = false;
        this.lvExtensions.View = System.Windows.Forms.View.Details;
        this.lvExtensions.SelectedIndexChanged += new System.EventHandler(this.LvExtensions_SelectedIndexChanged);
        // 
        // colName
        // 
        this.colName.Text = "Extension";
        this.colName.Width = 270;
        // 
        // colStatus
        // 
        this.colStatus.Text = "Status";
        this.colStatus.Width = 145;
        // 
        // colVersion
        // 
        this.colVersion.Text = "Version";
        this.colVersion.Width = 80;
        // 
        // pnlDetails
        // 
        this.pnlDetails.Controls.Add(this.txtOutput);
        this.pnlDetails.Controls.Add(this.lblDescription);
        this.pnlDetails.Controls.Add(this.pnlButtons);
        this.pnlDetails.Dock = System.Windows.Forms.DockStyle.Bottom;
        this.pnlDetails.Location = new System.Drawing.Point(4, 275);
        this.pnlDetails.Name = "pnlDetails";
        this.pnlDetails.Size = new System.Drawing.Size(536, 164);
        this.pnlDetails.TabIndex = 3;
        // 
        // txtOutput
        // 
        this.txtOutput.BackColor = System.Drawing.Color.White;
        this.txtOutput.Dock = System.Windows.Forms.DockStyle.Fill;
        this.txtOutput.Location = new System.Drawing.Point(0, 48);
        this.txtOutput.Multiline = true;
        this.txtOutput.Name = "txtOutput";
        this.txtOutput.ReadOnly = true;
        this.txtOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
        this.txtOutput.Size = new System.Drawing.Size(536, 76);
        this.txtOutput.TabIndex = 1;
        // 
        // lblDescription
        // 
        this.lblDescription.AutoEllipsis = true;
        this.lblDescription.Dock = System.Windows.Forms.DockStyle.Top;
        this.lblDescription.Location = new System.Drawing.Point(0, 0);
        this.lblDescription.Name = "lblDescription";
        this.lblDescription.Padding = new System.Windows.Forms.Padding(2, 5, 2, 2);
        this.lblDescription.Size = new System.Drawing.Size(536, 48);
        this.lblDescription.TabIndex = 0;
        this.lblDescription.Text = "Select an extension to see its description.";
        // 
        // pnlButtons
        // 
        this.pnlButtons.Controls.Add(this.btnRun);
        this.pnlButtons.Controls.Add(this.btnRemove);
        this.pnlButtons.Controls.Add(this.btnInstall);
        this.pnlButtons.Controls.Add(this.btnRefresh);
        this.pnlButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
        this.pnlButtons.Location = new System.Drawing.Point(0, 124);
        this.pnlButtons.Name = "pnlButtons";
        this.pnlButtons.Size = new System.Drawing.Size(536, 40);
        this.pnlButtons.TabIndex = 2;
        // 
        // btnRun
        // 
        this.btnRun.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
        this.btnRun.Enabled = false;
        this.btnRun.Location = new System.Drawing.Point(446, 8);
        this.btnRun.Name = "btnRun";
        this.btnRun.Size = new System.Drawing.Size(90, 28);
        this.btnRun.TabIndex = 3;
        this.btnRun.Text = "Run";
        this.btnRun.UseVisualStyleBackColor = true;
        this.btnRun.Click += new System.EventHandler(this.BtnRun_Click);
        // 
        // btnRemove
        // 
        this.btnRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
        this.btnRemove.Enabled = false;
        this.btnRemove.Location = new System.Drawing.Point(350, 8);
        this.btnRemove.Name = "btnRemove";
        this.btnRemove.Size = new System.Drawing.Size(90, 28);
        this.btnRemove.TabIndex = 2;
        this.btnRemove.Text = "Remove";
        this.btnRemove.UseVisualStyleBackColor = true;
        this.btnRemove.Click += new System.EventHandler(this.BtnRemove_Click);
        // 
        // btnInstall
        // 
        this.btnInstall.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
        this.btnInstall.Enabled = false;
        this.btnInstall.Location = new System.Drawing.Point(254, 8);
        this.btnInstall.Name = "btnInstall";
        this.btnInstall.Size = new System.Drawing.Size(90, 28);
        this.btnInstall.TabIndex = 1;
        this.btnInstall.Text = "Install";
        this.btnInstall.UseVisualStyleBackColor = true;
        this.btnInstall.Click += new System.EventHandler(this.BtnInstall_Click);
        // 
        // btnRefresh
        // 
        this.btnRefresh.Location = new System.Drawing.Point(0, 8);
        this.btnRefresh.Name = "btnRefresh";
        this.btnRefresh.Size = new System.Drawing.Size(90, 28);
        this.btnRefresh.TabIndex = 0;
        this.btnRefresh.Text = "Refresh";
        this.btnRefresh.UseVisualStyleBackColor = true;
        this.btnRefresh.Click += new System.EventHandler(this.BtnRefresh_Click);
        // 
        // ExtensionsView
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.BackColor = System.Drawing.Color.White;
        this.Controls.Add(this.lvExtensions);
        this.Controls.Add(this.progressBar);
        this.Controls.Add(this.lblInfo);
        this.Controls.Add(this.pnlDetails);
        this.Name = "ExtensionsView";
        this.Padding = new System.Windows.Forms.Padding(4);
        this.Size = new System.Drawing.Size(544, 443);
        this.pnlDetails.ResumeLayout(false);
        this.pnlDetails.PerformLayout();
        this.pnlButtons.ResumeLayout(false);
        this.ResumeLayout(false);
    }

    #endregion
}
