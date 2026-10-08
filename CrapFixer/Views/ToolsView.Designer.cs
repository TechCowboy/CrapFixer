namespace CrapFixer.Views;

partial class ToolsView
{
    private System.ComponentModel.IContainer components = null;
    private Panel pnlSubContent;
    private Panel pnlHeader;
    private Label lblPageSubtitle;
    private Label lblPageTitle;
    private Panel pnlSubNav;
    private Button btnNavExtensions;
    private Button btnNavAppRemover;
    private Button btnNavCustom;

    protected override void Dispose(bool disposing)
    {
        if (disposing && components != null) components.Dispose();
        base.Dispose(disposing);
    }

    #region Component Designer generated code

    private void InitializeComponent()
    {
        this.pnlSubContent = new System.Windows.Forms.Panel();
        this.pnlHeader = new System.Windows.Forms.Panel();
        this.lblPageSubtitle = new System.Windows.Forms.Label();
        this.lblPageTitle = new System.Windows.Forms.Label();
        this.pnlSubNav = new System.Windows.Forms.Panel();
        this.btnNavExtensions = new System.Windows.Forms.Button();
        this.btnNavAppRemover = new System.Windows.Forms.Button();
        this.btnNavCustom = new System.Windows.Forms.Button();
        this.pnlHeader.SuspendLayout();
        this.pnlSubNav.SuspendLayout();
        this.SuspendLayout();
        // 
        // pnlSubContent
        // 
        this.pnlSubContent.BackColor = System.Drawing.Color.White;
        this.pnlSubContent.Dock = System.Windows.Forms.DockStyle.Fill;
        this.pnlSubContent.Location = new System.Drawing.Point(140, 57);
        this.pnlSubContent.Name = "pnlSubContent";
        this.pnlSubContent.Padding = new System.Windows.Forms.Padding(4);
        this.pnlSubContent.Size = new System.Drawing.Size(552, 455);
        this.pnlSubContent.TabIndex = 0;
        // 
        // pnlHeader
        // 
        this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(103, 103, 103);
        this.pnlHeader.Controls.Add(this.lblPageSubtitle);
        this.pnlHeader.Controls.Add(this.lblPageTitle);
        this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
        this.pnlHeader.Location = new System.Drawing.Point(140, 8);
        this.pnlHeader.Name = "pnlHeader";
        this.pnlHeader.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
        this.pnlHeader.Size = new System.Drawing.Size(552, 49);
        this.pnlHeader.TabIndex = 1;
        // 
        // lblPageSubtitle
        // 
        this.lblPageSubtitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
        this.lblPageSubtitle.AutoEllipsis = true;
        this.lblPageSubtitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
        this.lblPageSubtitle.ForeColor = System.Drawing.Color.White;
        this.lblPageSubtitle.Location = new System.Drawing.Point(4, 30);
        this.lblPageSubtitle.Name = "lblPageSubtitle";
        this.lblPageSubtitle.Size = new System.Drawing.Size(524, 15);
        this.lblPageSubtitle.TabIndex = 1;
        // 
        // lblPageTitle
        // 
        this.lblPageTitle.AutoSize = true;
        this.lblPageTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
        this.lblPageTitle.ForeColor = System.Drawing.Color.White;
        this.lblPageTitle.Location = new System.Drawing.Point(2, 5);
        this.lblPageTitle.Name = "lblPageTitle";
        this.lblPageTitle.Size = new System.Drawing.Size(54, 22);
        this.lblPageTitle.TabIndex = 0;
        this.lblPageTitle.Text = "Tools";
        // 
        // pnlSubNav
        // 
        this.pnlSubNav.BackColor = System.Drawing.Color.White;
        this.pnlSubNav.Controls.Add(this.btnNavExtensions);
        this.pnlSubNav.Controls.Add(this.btnNavAppRemover);
        this.pnlSubNav.Controls.Add(this.btnNavCustom);
        this.pnlSubNav.Dock = System.Windows.Forms.DockStyle.Left;
        this.pnlSubNav.Location = new System.Drawing.Point(8, 8);
        this.pnlSubNav.Name = "pnlSubNav";
        this.pnlSubNav.Padding = new System.Windows.Forms.Padding(10);
        this.pnlSubNav.Size = new System.Drawing.Size(132, 504);
        this.pnlSubNav.TabIndex = 2;
        // 
        // btnNavExtensions
        // 
        this.btnNavExtensions.AutoEllipsis = true;
        this.btnNavExtensions.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(153, 180, 209);
        this.btnNavExtensions.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.btnNavExtensions.Location = new System.Drawing.Point(13, 82);
        this.btnNavExtensions.Name = "btnNavExtensions";
        this.btnNavExtensions.Size = new System.Drawing.Size(106, 32);
        this.btnNavExtensions.TabIndex = 2;
        this.btnNavExtensions.Text = "Extensions";
        this.btnNavExtensions.UseVisualStyleBackColor = true;
        this.btnNavExtensions.Click += new System.EventHandler(this.NavExtensions_Click);
        // 
        // btnNavAppRemover
        // 
        this.btnNavAppRemover.AutoEllipsis = true;
        this.btnNavAppRemover.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(153, 180, 209);
        this.btnNavAppRemover.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.btnNavAppRemover.Location = new System.Drawing.Point(13, 44);
        this.btnNavAppRemover.Name = "btnNavAppRemover";
        this.btnNavAppRemover.Size = new System.Drawing.Size(106, 32);
        this.btnNavAppRemover.TabIndex = 1;
        this.btnNavAppRemover.Text = "App Remover";
        this.btnNavAppRemover.UseVisualStyleBackColor = true;
        this.btnNavAppRemover.Click += new System.EventHandler(this.NavAppRemover_Click);
        // 
        // btnNavCustom
        // 
        this.btnNavCustom.AutoEllipsis = true;
        this.btnNavCustom.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(153, 180, 209);
        this.btnNavCustom.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.btnNavCustom.Location = new System.Drawing.Point(13, 6);
        this.btnNavCustom.Name = "btnNavCustom";
        this.btnNavCustom.Size = new System.Drawing.Size(106, 32);
        this.btnNavCustom.TabIndex = 0;
        this.btnNavCustom.Text = "Custom Tweaks";
        this.btnNavCustom.UseVisualStyleBackColor = true;
        this.btnNavCustom.Click += new System.EventHandler(this.NavCustom_Click);
        // 
        // ToolsView
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.BackColor = System.Drawing.Color.White;
        this.Controls.Add(this.pnlSubContent);
        this.Controls.Add(this.pnlHeader);
        this.Controls.Add(this.pnlSubNav);
        this.Name = "ToolsView";
        this.Padding = new System.Windows.Forms.Padding(8);
        this.Size = new System.Drawing.Size(700, 520);
        this.pnlHeader.ResumeLayout(false);
        this.pnlHeader.PerformLayout();
        this.pnlSubNav.ResumeLayout(false);
        this.ResumeLayout(false);
    }

    #endregion
}
