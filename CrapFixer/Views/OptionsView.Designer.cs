namespace CrapFixer.Views;

partial class OptionsView
{
    private System.ComponentModel.IContainer components = null;
    private Panel pnlSubContent;
    private Panel pnlHeader;
    private Label lblPageSubtitle;
    private Label lblPageTitle;
    private Panel pnlSubNav;
    private Button btnNavAbout;
    private Button btnNavBasic;
    private Button btnNavAdvanced;
    private Button btnNavAi;
    private Panel pnlDonation;
    private Label lblDonationTitle;
    private Label lblDonationMessage;
    private ComboBox cboDonationAmount;
    private ComboBox cboDonationCurrency;
    private Button btnDonate;
    private Button btnDonationClose;

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
            this.btnNavAbout = new System.Windows.Forms.Button();
            this.btnNavAi = new System.Windows.Forms.Button();
            this.btnNavAdvanced = new System.Windows.Forms.Button();
            this.btnNavBasic = new System.Windows.Forms.Button();
            this.pnlDonation = new System.Windows.Forms.Panel();
            this.btnDonationClose = new System.Windows.Forms.Button();
            this.btnDonate = new System.Windows.Forms.Button();
            this.cboDonationCurrency = new System.Windows.Forms.ComboBox();
            this.cboDonationAmount = new System.Windows.Forms.ComboBox();
            this.lblDonationMessage = new System.Windows.Forms.Label();
            this.lblDonationTitle = new System.Windows.Forms.Label();
            this.pnlHeader.SuspendLayout();
            this.pnlSubNav.SuspendLayout();
            this.pnlDonation.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlSubContent
            // 
            this.pnlSubContent.BackColor = System.Drawing.Color.White;
            this.pnlSubContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSubContent.Location = new System.Drawing.Point(140, 125);
            this.pnlSubContent.Name = "pnlSubContent";
            this.pnlSubContent.Padding = new System.Windows.Forms.Padding(4);
            this.pnlSubContent.Size = new System.Drawing.Size(552, 387);
            this.pnlSubContent.TabIndex = 0;
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(103)))), ((int)(((byte)(103)))));
            this.pnlHeader.Controls.Add(this.lblPageSubtitle);
            this.pnlHeader.Controls.Add(this.lblPageTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(140, 76);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.pnlHeader.Size = new System.Drawing.Size(552, 49);
            this.pnlHeader.TabIndex = 1;
            // 
            // lblPageSubtitle
            // 
            this.lblPageSubtitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
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
            this.lblPageTitle.Size = new System.Drawing.Size(75, 22);
            this.lblPageTitle.TabIndex = 0;
            this.lblPageTitle.Text = "Settings";
            // 
            // pnlSubNav
            // 
            this.pnlSubNav.BackColor = System.Drawing.Color.White;
            this.pnlSubNav.Controls.Add(this.btnNavAbout);
            this.pnlSubNav.Controls.Add(this.btnNavAi);
            this.pnlSubNav.Controls.Add(this.btnNavAdvanced);
            this.pnlSubNav.Controls.Add(this.btnNavBasic);
            this.pnlSubNav.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSubNav.Location = new System.Drawing.Point(8, 76);
            this.pnlSubNav.Name = "pnlSubNav";
            this.pnlSubNav.Padding = new System.Windows.Forms.Padding(10);
            this.pnlSubNav.Size = new System.Drawing.Size(132, 436);
            this.pnlSubNav.TabIndex = 2;
            // 
            // btnNavAbout
            // 
            this.btnNavAbout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnNavAbout.AutoEllipsis = true;
            this.btnNavAbout.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(180)))), ((int)(((byte)(209)))));
            this.btnNavAbout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavAbout.Location = new System.Drawing.Point(13, 394);
            this.btnNavAbout.Name = "btnNavAbout";
            this.btnNavAbout.Size = new System.Drawing.Size(106, 32);
            this.btnNavAbout.TabIndex = 3;
            this.btnNavAbout.Text = "About";
            this.btnNavAbout.UseVisualStyleBackColor = true;
            this.btnNavAbout.Click += new System.EventHandler(this.NavAbout_Click);
            // 
            // btnNavAi
            // 
            this.btnNavAi.AutoEllipsis = true;
            this.btnNavAi.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(180)))), ((int)(((byte)(209)))));
            this.btnNavAi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavAi.Location = new System.Drawing.Point(13, 44);
            this.btnNavAi.Name = "btnNavAi";
            this.btnNavAi.Size = new System.Drawing.Size(106, 32);
            this.btnNavAi.TabIndex = 2;
            this.btnNavAi.Text = "AI";
            this.btnNavAi.UseVisualStyleBackColor = true;
            this.btnNavAi.Click += new System.EventHandler(this.NavAi_Click);
            // 
            // btnNavAdvanced
            // 
            this.btnNavAdvanced.AutoEllipsis = true;
            this.btnNavAdvanced.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(180)))), ((int)(((byte)(209)))));
            this.btnNavAdvanced.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavAdvanced.Location = new System.Drawing.Point(13, 82);
            this.btnNavAdvanced.Name = "btnNavAdvanced";
            this.btnNavAdvanced.Size = new System.Drawing.Size(106, 32);
            this.btnNavAdvanced.TabIndex = 1;
            this.btnNavAdvanced.Text = "Advanced";
            this.btnNavAdvanced.UseVisualStyleBackColor = true;
            this.btnNavAdvanced.Click += new System.EventHandler(this.NavAdvanced_Click);
            // 
            // btnNavBasic
            // 
            this.btnNavBasic.AutoEllipsis = true;
            this.btnNavBasic.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(180)))), ((int)(((byte)(209)))));
            this.btnNavBasic.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavBasic.Location = new System.Drawing.Point(13, 6);
            this.btnNavBasic.Name = "btnNavBasic";
            this.btnNavBasic.Size = new System.Drawing.Size(106, 32);
            this.btnNavBasic.TabIndex = 0;
            this.btnNavBasic.Text = "Basic Settings";
            this.btnNavBasic.UseVisualStyleBackColor = true;
            this.btnNavBasic.Click += new System.EventHandler(this.NavBasic_Click);
            // 
            // pnlDonation
            // 
            this.pnlDonation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(247)))), ((int)(((byte)(205)))));
            this.pnlDonation.Controls.Add(this.btnDonationClose);
            this.pnlDonation.Controls.Add(this.btnDonate);
            this.pnlDonation.Controls.Add(this.cboDonationCurrency);
            this.pnlDonation.Controls.Add(this.cboDonationAmount);
            this.pnlDonation.Controls.Add(this.lblDonationMessage);
            this.pnlDonation.Controls.Add(this.lblDonationTitle);
            this.pnlDonation.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlDonation.Location = new System.Drawing.Point(8, 8);
            this.pnlDonation.Name = "pnlDonation";
            this.pnlDonation.Size = new System.Drawing.Size(684, 68);
            this.pnlDonation.TabIndex = 3;
            // 
            // btnDonationClose
            // 
            this.btnDonationClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDonationClose.FlatAppearance.BorderSize = 0;
            this.btnDonationClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDonationClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.btnDonationClose.Location = new System.Drawing.Point(660, 0);
            this.btnDonationClose.Name = "btnDonationClose";
            this.btnDonationClose.Size = new System.Drawing.Size(20, 20);
            this.btnDonationClose.TabIndex = 6;
            this.btnDonationClose.TabStop = false;
            this.btnDonationClose.Text = "✕";
            this.btnDonationClose.UseVisualStyleBackColor = true;
            this.btnDonationClose.Click += new System.EventHandler(this.BtnDonationClose_Click);
            // 
            // btnDonate
            // 
            this.btnDonate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDonate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(38)))), ((int)(((byte)(131)))));
            this.btnDonate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDonate.FlatAppearance.BorderSize = 0;
            this.btnDonate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDonate.ForeColor = System.Drawing.Color.White;
            this.btnDonate.Location = new System.Drawing.Point(564, 25);
            this.btnDonate.Name = "btnDonate";
            this.btnDonate.Size = new System.Drawing.Size(90, 26);
            this.btnDonate.TabIndex = 5;
            this.btnDonate.Text = "Donate";
            this.btnDonate.UseVisualStyleBackColor = false;
            this.btnDonate.Click += new System.EventHandler(this.BtnDonate_Click);
            // 
            // cboDonationCurrency
            // 
            this.cboDonationCurrency.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboDonationCurrency.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDonationCurrency.FormattingEnabled = true;
            this.cboDonationCurrency.Items.AddRange(new object[] {
            "EUR",
            "USD",
            "GBP",
            "CAD",
            "AUD",
            "CHF"});
            this.cboDonationCurrency.Location = new System.Drawing.Point(493, 27);
            this.cboDonationCurrency.Name = "cboDonationCurrency";
            this.cboDonationCurrency.Size = new System.Drawing.Size(65, 21);
            this.cboDonationCurrency.TabIndex = 4;
            // 
            // cboDonationAmount
            // 
            this.cboDonationAmount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboDonationAmount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDonationAmount.FormattingEnabled = true;
            this.cboDonationAmount.Items.AddRange(new object[] {
            "3.50",
            "5",
            "10",
            "12",
            "15",
            "16",
            "17",
            "18",
            "20",
            "25",
            "30",
            "35",
            "40",
            "50",
            "60",
            "70",
            "80",
            "100"});
            this.cboDonationAmount.Location = new System.Drawing.Point(412, 27);
            this.cboDonationAmount.Name = "cboDonationAmount";
            this.cboDonationAmount.Size = new System.Drawing.Size(75, 21);
            this.cboDonationAmount.TabIndex = 3;
            // 
            // lblDonationMessage
            // 
            this.lblDonationMessage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDonationMessage.AutoEllipsis = true;
            this.lblDonationMessage.Location = new System.Drawing.Point(14, 29);
            this.lblDonationMessage.Name = "lblDonationMessage";
            this.lblDonationMessage.Size = new System.Drawing.Size(380, 27);
            this.lblDonationMessage.TabIndex = 1;
            this.lblDonationMessage.Text = "Independent, ad-free and built without telemetry — your support keeps CrapFixer m" +
    "oving.";
            // 
            // lblDonationTitle
            // 
            this.lblDonationTitle.AutoSize = true;
            this.lblDonationTitle.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lblDonationTitle.Location = new System.Drawing.Point(14, 8);
            this.lblDonationTitle.Name = "lblDonationTitle";
            this.lblDonationTitle.Size = new System.Drawing.Size(135, 17);
            this.lblDonationTitle.TabIndex = 0;
            this.lblDonationTitle.Text = "Support CrapFixer";
            // 
            // OptionsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.pnlSubContent);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.pnlSubNav);
            this.Controls.Add(this.pnlDonation);
            this.Name = "OptionsView";
            this.Padding = new System.Windows.Forms.Padding(8);
            this.Size = new System.Drawing.Size(700, 520);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlSubNav.ResumeLayout(false);
            this.pnlDonation.ResumeLayout(false);
            this.pnlDonation.PerformLayout();
            this.ResumeLayout(false);

    }

    #endregion
}
