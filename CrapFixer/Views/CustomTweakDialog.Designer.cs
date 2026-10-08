namespace CrapFixer.Views;

partial class CustomTweakDialog
{
    private System.ComponentModel.IContainer components = null;
    private Label lblName;
    private TextBox txtName;
    private Button btnTemplate;
    private TextBox txtBody;
    private Button btnSave;
    private Button btnCancel;

    protected override void Dispose(bool disposing)
    {
        if (disposing && components != null) components.Dispose();
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    private void InitializeComponent()
    {
        this.lblName = new System.Windows.Forms.Label();
        this.txtName = new System.Windows.Forms.TextBox();
        this.btnTemplate = new System.Windows.Forms.Button();
        this.txtBody = new System.Windows.Forms.TextBox();
        this.btnSave = new System.Windows.Forms.Button();
        this.btnCancel = new System.Windows.Forms.Button();
        this.SuspendLayout();
        // 
        // lblName
        // 
        this.lblName.AutoSize = true;
        this.lblName.Location = new System.Drawing.Point(12, 15);
        this.lblName.Name = "lblName";
        this.lblName.Size = new System.Drawing.Size(39, 13);
        this.lblName.TabIndex = 0;
        this.lblName.Text = "Name:";
        // 
        // txtName
        // 
        this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
        this.txtName.Location = new System.Drawing.Point(57, 12);
        this.txtName.Name = "txtName";
        this.txtName.Size = new System.Drawing.Size(371, 20);
        this.txtName.TabIndex = 1;
        // 
        // btnTemplate
        // 
        this.btnTemplate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
        this.btnTemplate.Location = new System.Drawing.Point(434, 10);
        this.btnTemplate.Name = "btnTemplate";
        this.btnTemplate.Size = new System.Drawing.Size(94, 24);
        this.btnTemplate.TabIndex = 2;
        this.btnTemplate.Text = "Load template";
        this.btnTemplate.UseVisualStyleBackColor = true;
        this.btnTemplate.Click += new System.EventHandler(this.BtnTemplate_Click);
        // 
        // txtBody
        // 
        this.txtBody.AcceptsReturn = true;
        this.txtBody.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
        this.txtBody.Font = new System.Drawing.Font("Consolas", 9F);
        this.txtBody.Location = new System.Drawing.Point(12, 42);
        this.txtBody.Multiline = true;
        this.txtBody.Name = "txtBody";
        this.txtBody.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
        this.txtBody.Size = new System.Drawing.Size(516, 294);
        this.txtBody.TabIndex = 3;
        this.txtBody.WordWrap = false;
        // 
        // btnSave
        // 
        this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
        this.btnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
        this.btnSave.Location = new System.Drawing.Point(372, 346);
        this.btnSave.Name = "btnSave";
        this.btnSave.Size = new System.Drawing.Size(75, 26);
        this.btnSave.TabIndex = 4;
        this.btnSave.Text = "Save";
        this.btnSave.UseVisualStyleBackColor = true;
        this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
        // 
        // btnCancel
        // 
        this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
        this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        this.btnCancel.Location = new System.Drawing.Point(453, 346);
        this.btnCancel.Name = "btnCancel";
        this.btnCancel.Size = new System.Drawing.Size(75, 26);
        this.btnCancel.TabIndex = 5;
        this.btnCancel.Text = "Cancel";
        this.btnCancel.UseVisualStyleBackColor = true;
        // 
        // CustomTweakDialog
        // 
        this.AcceptButton = this.btnSave;
        this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
        this.CancelButton = this.btnCancel;
        this.ClientSize = new System.Drawing.Size(540, 384);
        this.Controls.Add(this.btnCancel);
        this.Controls.Add(this.btnSave);
        this.Controls.Add(this.txtBody);
        this.Controls.Add(this.btnTemplate);
        this.Controls.Add(this.txtName);
        this.Controls.Add(this.lblName);
        this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.MinimumSize = new System.Drawing.Size(420, 300);
        this.Name = "CustomTweakDialog";
        this.ShowIcon = false;
        this.ShowInTaskbar = false;
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        this.Text = "Custom tweak";
        this.ResumeLayout(false);
        this.PerformLayout();
    }

    #endregion
}
