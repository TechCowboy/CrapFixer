namespace CrapFixer.Views;

partial class ExplainDialog
{
    private System.ComponentModel.IContainer components = null;
    private Button btnClose;
    private TextBox txtBody;

    protected override void Dispose(bool disposing)
    {
        if (disposing && components != null) components.Dispose();
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    private void InitializeComponent()
    {
        this.btnClose = new System.Windows.Forms.Button();
        this.txtBody = new System.Windows.Forms.TextBox();
        this.SuspendLayout();
        // 
        // btnClose
        // 
        this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
        this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        this.btnClose.Location = new System.Drawing.Point(453, 294);
        this.btnClose.Name = "btnClose";
        this.btnClose.Size = new System.Drawing.Size(85, 26);
        this.btnClose.TabIndex = 1;
        this.btnClose.Text = "Close";
        this.btnClose.UseVisualStyleBackColor = true;
        // 
        // txtBody
        // 
        this.txtBody.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
        this.txtBody.BackColor = System.Drawing.Color.White;
        this.txtBody.Location = new System.Drawing.Point(12, 12);
        this.txtBody.Multiline = true;
        this.txtBody.Name = "txtBody";
        this.txtBody.ReadOnly = true;
        this.txtBody.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
        this.txtBody.Size = new System.Drawing.Size(526, 267);
        this.txtBody.TabIndex = 0;
        this.txtBody.Text = "Thinking...";
        // 
        // ExplainDialog
        // 
        this.AcceptButton = this.btnClose;
        this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
        this.CancelButton = this.btnClose;
        this.ClientSize = new System.Drawing.Size(550, 332);
        this.Controls.Add(this.txtBody);
        this.Controls.Add(this.btnClose);
        this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.MaximizeBox = false;
        this.MinimizeBox = false;
        this.MinimumSize = new System.Drawing.Size(450, 280);
        this.Name = "ExplainDialog";
        this.ShowIcon = false;
        this.ShowInTaskbar = false;
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        this.Text = "Explain with AI";
        this.ResumeLayout(false);
        this.PerformLayout();
    }

    #endregion
}
