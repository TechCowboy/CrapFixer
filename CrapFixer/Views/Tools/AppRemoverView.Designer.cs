namespace CrapFixer.Views.Tools;

partial class AppRemoverView
{
    private System.ComponentModel.IContainer components = null;
    private Label lblStatus;
    private ListView lvApps;
    private ColumnHeader colName;
    private ColumnHeader colCategory;
    private ColumnHeader colPackage;
    private Panel pnlBottom;
    private Button btnScan;
    private Button btnRemove;
    private ProgressBar progressBar;

    protected override void Dispose(bool disposing)
    {
        if (disposing && components != null) components.Dispose();
        base.Dispose(disposing);
    }

    #region Component Designer generated code

    private void InitializeComponent()
    {
        this.lblStatus = new System.Windows.Forms.Label();
        this.lvApps = new System.Windows.Forms.ListView();
        this.colName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
        this.colCategory = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
        this.colPackage = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
        this.pnlBottom = new System.Windows.Forms.Panel();
        this.btnRemove = new System.Windows.Forms.Button();
        this.btnScan = new System.Windows.Forms.Button();
        this.progressBar = new System.Windows.Forms.ProgressBar();
        this.pnlBottom.SuspendLayout();
        this.SuspendLayout();
        // 
        // lblStatus
        // 
        this.lblStatus.AutoEllipsis = true;
        this.lblStatus.Dock = System.Windows.Forms.DockStyle.Top;
        this.lblStatus.ForeColor = System.Drawing.Color.DimGray;
        this.lblStatus.Location = new System.Drawing.Point(4, 4);
        this.lblStatus.Name = "lblStatus";
        this.lblStatus.Padding = new System.Windows.Forms.Padding(2, 5, 0, 0);
        this.lblStatus.Size = new System.Drawing.Size(536, 34);
        this.lblStatus.TabIndex = 0;
        this.lblStatus.Text = "Click Scan to check the Winappx.ini entries against installed packages.";
        // 
        // lvApps
        // 
        this.lvApps.CheckBoxes = true;
        this.lvApps.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { this.colName, this.colCategory, this.colPackage });
        this.lvApps.Dock = System.Windows.Forms.DockStyle.Fill;
        this.lvApps.FullRowSelect = true;
        this.lvApps.HideSelection = false;
        this.lvApps.Location = new System.Drawing.Point(4, 41);
        this.lvApps.Name = "lvApps";
        this.lvApps.Size = new System.Drawing.Size(536, 358);
        this.lvApps.TabIndex = 2;
        this.lvApps.UseCompatibleStateImageBehavior = false;
        this.lvApps.View = System.Windows.Forms.View.Details;
        this.lvApps.Resize += new System.EventHandler(this.LvApps_Resize);
        // 
        // colName
        // 
        this.colName.Text = "App";
        this.colName.Width = 170;
        // 
        // colCategory
        // 
        this.colCategory.Text = "Category";
        this.colCategory.Width = 95;
        // 
        // colPackage
        // 
        this.colPackage.Text = "Package";
        this.colPackage.Width = 260;
        // 
        // pnlBottom
        // 
        this.pnlBottom.Controls.Add(this.btnRemove);
        this.pnlBottom.Controls.Add(this.btnScan);
        this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
        this.pnlBottom.Location = new System.Drawing.Point(4, 399);
        this.pnlBottom.Name = "pnlBottom";
        this.pnlBottom.Size = new System.Drawing.Size(536, 40);
        this.pnlBottom.TabIndex = 3;
        // 
        // btnRemove
        // 
        this.btnRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
        this.btnRemove.Location = new System.Drawing.Point(411, 8);
        this.btnRemove.Name = "btnRemove";
        this.btnRemove.Enabled = false;
        this.btnRemove.Size = new System.Drawing.Size(125, 28);
        this.btnRemove.TabIndex = 1;
        this.btnRemove.Text = "Remove selected";
        this.btnRemove.UseVisualStyleBackColor = true;
        this.btnRemove.Click += new System.EventHandler(this.BtnRemove_Click);
        // 
        // btnScan
        // 
        this.btnScan.Location = new System.Drawing.Point(0, 8);
        this.btnScan.Name = "btnScan";
        this.btnScan.Size = new System.Drawing.Size(110, 28);
        this.btnScan.TabIndex = 0;
        this.btnScan.Text = "Scan";
        this.btnScan.UseVisualStyleBackColor = true;
        this.btnScan.Click += new System.EventHandler(this.BtnScan_Click);
        // 
        // progressBar
        // 
        this.progressBar.Dock = System.Windows.Forms.DockStyle.Top;
        this.progressBar.Location = new System.Drawing.Point(4, 38);
        this.progressBar.MarqueeAnimationSpeed = 25;
        this.progressBar.Name = "progressBar";
        this.progressBar.Size = new System.Drawing.Size(536, 3);
        this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
        this.progressBar.TabIndex = 1;
        this.progressBar.Visible = false;
        // 
        // AppRemoverView
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.BackColor = System.Drawing.Color.White;
        this.Controls.Add(this.lvApps);
        this.Controls.Add(this.progressBar);
        this.Controls.Add(this.lblStatus);
        this.Controls.Add(this.pnlBottom);
        this.Name = "AppRemoverView";
        this.Padding = new System.Windows.Forms.Padding(4);
        this.Size = new System.Drawing.Size(544, 443);
        this.pnlBottom.ResumeLayout(false);
        this.ResumeLayout(false);
    }

    #endregion
}
