namespace Ticari_Otomasyon
{
    partial class FrmNotDetay
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
            this.RchNotDetay = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // RchNotDetay
            // 
            this.RchNotDetay.BackColor = System.Drawing.Color.LemonChiffon;
            this.RchNotDetay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RchNotDetay.Location = new System.Drawing.Point(0, 0);
            this.RchNotDetay.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.RchNotDetay.Name = "RchNotDetay";
            this.RchNotDetay.ReadOnly = true;
            this.RchNotDetay.Size = new System.Drawing.Size(804, 407);
            this.RchNotDetay.TabIndex = 0;
            this.RchNotDetay.Text = "";
            // 
            // FrmNotDetay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(804, 407);
            this.Controls.Add(this.RchNotDetay);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmNotDetay";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NOT DETAY";
            this.Load += new System.EventHandler(this.FrmNotDetay_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox RchNotDetay;
    }
}