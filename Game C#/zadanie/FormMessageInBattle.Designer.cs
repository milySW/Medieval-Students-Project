namespace zadanie
{
    partial class FormMessageInBattle
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMessageInBattle));
            this.labelMessageInBattle = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelMessageInBattle
            // 
            this.labelMessageInBattle.BackColor = System.Drawing.Color.Transparent;
            this.labelMessageInBattle.Location = new System.Drawing.Point(23, 28);
            this.labelMessageInBattle.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.labelMessageInBattle.Name = "labelMessageInBattle";
            this.labelMessageInBattle.Size = new System.Drawing.Size(380, 56);
            this.labelMessageInBattle.TabIndex = 0;
            this.labelMessageInBattle.Text = "Message";
            this.labelMessageInBattle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // FormMessageInBattle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(24F, 56F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(408, 108);
            this.Controls.Add(this.labelMessageInBattle);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Font = new System.Drawing.Font("Monotype Corsiva", 28F, System.Drawing.FontStyle.Italic);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(10, 11, 10, 11);
            this.MaximizeBox = false;
            this.Name = "FormMessageInBattle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Message";
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Label labelMessageInBattle;
    }
}