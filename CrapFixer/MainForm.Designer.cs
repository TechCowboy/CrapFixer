namespace CrapFixer;

partial class MainForm
{
    private System.ComponentModel.IContainer components = null;
    private Panel pnlNav;
    private Button btnNavOptions;
    private Button btnNavTools;
    private Button btnNavTweaker;
    private Panel pnlContent;
    private Panel pnlViewHost;
    private StatusStrip statusStrip;
    private ToolStripStatusLabel lnkOnlineHelp;
    private ToolStripStatusLabel lblStatusSpring;
    private ToolStripStatusLabel lnkCheckUpdates;
    private Panel pnlHeader;
    private Label lblHeaderInfo;
    private Label lblHeaderHardware;
    private Label lblHeaderVersion;
    private Label lblHeaderTitle;
    private PictureBox picHeaderIcon;

    protected override void Dispose(bool disposing)
    {
        if (disposing && components != null) components.Dispose();
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    private void InitializeComponent()
    {
            this.pnlNav = new System.Windows.Forms.Panel();
            this.btnNavOptions = new System.Windows.Forms.Button();
            this.btnNavTools = new System.Windows.Forms.Button();
            this.btnNavTweaker = new System.Windows.Forms.Button();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.pnlViewHost = new System.Windows.Forms.Panel();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.lnkOnlineHelp = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblStatusSpring = new System.Windows.Forms.ToolStripStatusLabel();
            this.lnkCheckUpdates = new System.Windows.Forms.ToolStripStatusLabel();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblHeaderInfo = new System.Windows.Forms.Label();
            this.lblHeaderHardware = new System.Windows.Forms.Label();
            this.lblHeaderVersion = new System.Windows.Forms.Label();
            this.lblHeaderTitle = new System.Windows.Forms.Label();
            this.picHeaderIcon = new System.Windows.Forms.PictureBox();
            this.pnlNav.SuspendLayout();
            this.pnlContent.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picHeaderIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlNav
            // 
            this.pnlNav.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(103)))), ((int)(((byte)(103)))));
            this.pnlNav.Controls.Add(this.btnNavOptions);
            this.pnlNav.Controls.Add(this.btnNavTools);
            this.pnlNav.Controls.Add(this.btnNavTweaker);
            this.pnlNav.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlNav.Location = new System.Drawing.Point(0, 73);
            this.pnlNav.Name = "pnlNav";
            this.pnlNav.Padding = new System.Windows.Forms.Padding(6);
            this.pnlNav.Size = new System.Drawing.Size(96, 452);
            this.pnlNav.TabIndex = 0;
            // 
            // btnNavOptions
            // 
            this.btnNavOptions.FlatAppearance.BorderSize = 0;
            this.btnNavOptions.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavOptions.ForeColor = System.Drawing.Color.White;
            this.btnNavOptions.Location = new System.Drawing.Point(12, 174);
            this.btnNavOptions.Name = "btnNavOptions";
            this.btnNavOptions.Padding = new System.Windows.Forms.Padding(0, 8, 0, 8);
            this.btnNavOptions.Size = new System.Drawing.Size(84, 78);
            this.btnNavOptions.TabIndex = 2;
            this.btnNavOptions.Text = "Options";
            this.btnNavOptions.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnNavOptions.UseVisualStyleBackColor = false;
            this.btnNavOptions.Click += new System.EventHandler(this.Navigation_Click);
            // 
            // btnNavTools
            // 
            this.btnNavTools.FlatAppearance.BorderSize = 0;
            this.btnNavTools.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavTools.ForeColor = System.Drawing.Color.White;
            this.btnNavTools.Location = new System.Drawing.Point(12, 96);
            this.btnNavTools.Name = "btnNavTools";
            this.btnNavTools.Padding = new System.Windows.Forms.Padding(0, 8, 0, 8);
            this.btnNavTools.Size = new System.Drawing.Size(84, 78);
            this.btnNavTools.TabIndex = 1;
            this.btnNavTools.Text = "Tools";
            this.btnNavTools.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnNavTools.UseVisualStyleBackColor = false;
            this.btnNavTools.Click += new System.EventHandler(this.Navigation_Click);
            // 
            // btnNavTweaker
            // 
            this.btnNavTweaker.FlatAppearance.BorderSize = 0;
            this.btnNavTweaker.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavTweaker.ForeColor = System.Drawing.Color.White;
            this.btnNavTweaker.Location = new System.Drawing.Point(12, 18);
            this.btnNavTweaker.Name = "btnNavTweaker";
            this.btnNavTweaker.Padding = new System.Windows.Forms.Padding(0, 8, 0, 8);
            this.btnNavTweaker.Size = new System.Drawing.Size(84, 78);
            this.btnNavTweaker.TabIndex = 0;
            this.btnNavTweaker.Text = "Fixer";
            this.btnNavTweaker.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnNavTweaker.UseVisualStyleBackColor = false;
            this.btnNavTweaker.Click += new System.EventHandler(this.Navigation_Click);
            // 
            // pnlContent
            // 
            this.pnlContent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(103)))), ((int)(((byte)(103)))));
            this.pnlContent.Controls.Add(this.pnlViewHost);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(96, 73);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Padding = new System.Windows.Forms.Padding(0, 10, 6, 6);
            this.pnlContent.Size = new System.Drawing.Size(793, 452);
            this.pnlContent.TabIndex = 1;
            // 
            // pnlViewHost
            // 
            this.pnlViewHost.BackColor = System.Drawing.Color.White;
            this.pnlViewHost.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlViewHost.Location = new System.Drawing.Point(0, 10);
            this.pnlViewHost.Name = "pnlViewHost";
            this.pnlViewHost.Size = new System.Drawing.Size(787, 436);
            this.pnlViewHost.TabIndex = 0;
            // 
            // statusStrip
            // 
            this.statusStrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(103)))), ((int)(((byte)(103)))));
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lnkOnlineHelp,
            this.lblStatusSpring,
            this.lnkCheckUpdates});
            this.statusStrip.Location = new System.Drawing.Point(0, 525);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(889, 22);
            this.statusStrip.TabIndex = 2;
            // 
            // lnkOnlineHelp
            // 
            this.lnkOnlineHelp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lnkOnlineHelp.IsLink = true;
            this.lnkOnlineHelp.LinkColor = System.Drawing.Color.White;
            this.lnkOnlineHelp.Margin = new System.Windows.Forms.Padding(5, 0, 0, 5);
            this.lnkOnlineHelp.Name = "lnkOnlineHelp";
            this.lnkOnlineHelp.Size = new System.Drawing.Size(60, 17);
            this.lnkOnlineHelp.Text = "Online help";
            this.lnkOnlineHelp.Click += new System.EventHandler(this.LnkOnlineHelp_Click);
            // 
            // lblStatusSpring
            // 
            this.lblStatusSpring.Name = "lblStatusSpring";
            this.lblStatusSpring.Size = new System.Drawing.Size(701, 17);
            this.lblStatusSpring.Spring = true;
            // 
            // lnkCheckUpdates
            // 
            this.lnkCheckUpdates.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lnkCheckUpdates.IsLink = true;
            this.lnkCheckUpdates.LinkColor = System.Drawing.Color.White;
            this.lnkCheckUpdates.Margin = new System.Windows.Forms.Padding(0, 0, 5, 5);
            this.lnkCheckUpdates.Name = "lnkCheckUpdates";
            this.lnkCheckUpdates.Size = new System.Drawing.Size(103, 17);
            this.lnkCheckUpdates.Text = "Check for updates...";
            this.lnkCheckUpdates.Click += new System.EventHandler(this.LnkCheckUpdates_Click);
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(77)))), ((int)(((byte)(77)))));
            this.pnlHeader.Controls.Add(this.lblHeaderInfo);
            this.pnlHeader.Controls.Add(this.lblHeaderHardware);
            this.pnlHeader.Controls.Add(this.lblHeaderVersion);
            this.pnlHeader.Controls.Add(this.lblHeaderTitle);
            this.pnlHeader.Controls.Add(this.picHeaderIcon);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(889, 73);
            this.pnlHeader.TabIndex = 3;
            this.pnlHeader.Paint += new System.Windows.Forms.PaintEventHandler(this.PnlHeader_Paint);
            // 
            // lblHeaderInfo
            // 
            this.lblHeaderInfo.AutoSize = true;
            this.lblHeaderInfo.Font = new System.Drawing.Font("Tahoma", 7.6F);
            this.lblHeaderInfo.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblHeaderInfo.Location = new System.Drawing.Point(91, 38);
            this.lblHeaderInfo.Name = "lblHeaderInfo";
            this.lblHeaderInfo.Size = new System.Drawing.Size(160, 13);
            this.lblHeaderInfo.TabIndex = 0;
            this.lblHeaderInfo.Text = "Gathering system information...";
            // 
            // lblHeaderHardware
            // 
            this.lblHeaderHardware.AutoSize = true;
            this.lblHeaderHardware.Font = new System.Drawing.Font("Tahoma", 7.6F);
            this.lblHeaderHardware.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblHeaderHardware.Location = new System.Drawing.Point(91, 53);
            this.lblHeaderHardware.Name = "lblHeaderHardware";
            this.lblHeaderHardware.Size = new System.Drawing.Size(0, 13);
            this.lblHeaderHardware.TabIndex = 1;
            // 
            // lblHeaderVersion
            // 
            this.lblHeaderVersion.AutoSize = true;
            this.lblHeaderVersion.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblHeaderVersion.Location = new System.Drawing.Point(198, 20);
            this.lblHeaderVersion.Name = "lblHeaderVersion";
            this.lblHeaderVersion.Size = new System.Drawing.Size(39, 13);
            this.lblHeaderVersion.TabIndex = 2;
            this.lblHeaderVersion.Text = "v1.0.0";
            // 
            // lblHeaderTitle
            // 
            this.lblHeaderTitle.AutoSize = true;
            this.lblHeaderTitle.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.lblHeaderTitle.ForeColor = System.Drawing.Color.White;
            this.lblHeaderTitle.Location = new System.Drawing.Point(90, 12);
            this.lblHeaderTitle.Name = "lblHeaderTitle";
            this.lblHeaderTitle.Size = new System.Drawing.Size(101, 23);
            this.lblHeaderTitle.TabIndex = 3;
            this.lblHeaderTitle.Text = "CrapFixer";
            // 
            // picHeaderIcon
            // 
            this.picHeaderIcon.Location = new System.Drawing.Point(20, 10);
            this.picHeaderIcon.Name = "picHeaderIcon";
            this.picHeaderIcon.Size = new System.Drawing.Size(54, 54);
            this.picHeaderIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picHeaderIcon.TabIndex = 4;
            this.picHeaderIcon.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(889, 547);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pnlNav);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.pnlHeader);
            this.Font = new System.Drawing.Font("Tahoma", 8F);
            this.MinimumSize = new System.Drawing.Size(600, 420);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CrapFixer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.pnlNav.ResumeLayout(false);
            this.pnlContent.ResumeLayout(false);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picHeaderIcon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion
}
