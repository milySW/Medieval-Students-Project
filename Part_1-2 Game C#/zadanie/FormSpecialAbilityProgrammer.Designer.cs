namespace zadanie
{
    partial class FormSpecialAbilityProgrammer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSpecialAbilityProgrammer));
            this.labelTask = new System.Windows.Forms.Label();
            this.textBoxResult = new System.Windows.Forms.TextBox();
            this.labelCaptcha = new System.Windows.Forms.Label();
            this.buttonOK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelTask
            // 
            this.labelTask.AutoSize = true;
            this.labelTask.BackColor = System.Drawing.Color.Transparent;
            this.labelTask.Font = new System.Drawing.Font("Monotype Corsiva", 16.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelTask.ForeColor = System.Drawing.SystemColors.WindowText;
            this.labelTask.Location = new System.Drawing.Point(32, 21);
            this.labelTask.Name = "labelTask";
            this.labelTask.Size = new System.Drawing.Size(425, 34);
            this.labelTask.TabIndex = 0;
            this.labelTask.Text = "Type the characters you see in the picture.";
            // 
            // textBoxResult
            // 
            this.textBoxResult.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.textBoxResult.Font = new System.Drawing.Font("Monotype Corsiva", 16F, System.Drawing.FontStyle.Italic);
            this.textBoxResult.Location = new System.Drawing.Point(245, 73);
            this.textBoxResult.Name = "textBoxResult";
            this.textBoxResult.Size = new System.Drawing.Size(134, 37);
            this.textBoxResult.TabIndex = 1;
            // 
            // labelCaptcha
            // 
            this.labelCaptcha.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.labelCaptcha.Font = new System.Drawing.Font("Monotype Corsiva", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelCaptcha.Location = new System.Drawing.Point(59, 73);
            this.labelCaptcha.Name = "labelCaptcha";
            this.labelCaptcha.Size = new System.Drawing.Size(152, 37);
            this.labelCaptcha.TabIndex = 2;
            this.labelCaptcha.Text = "la";
            this.labelCaptcha.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // buttonOK
            // 
            this.buttonOK.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonOK.BackgroundImage")));
            this.buttonOK.Font = new System.Drawing.Font("Monotype Corsiva", 13.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonOK.Location = new System.Drawing.Point(347, 116);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(110, 41);
            this.buttonOK.TabIndex = 3;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.ButtonOK_Click);
            // 
            // FormSpecialAbilityProgrammer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(469, 164);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.labelCaptcha);
            this.Controls.Add(this.textBoxResult);
            this.Controls.Add(this.labelTask);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormSpecialAbilityProgrammer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Captcha";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTask;
        private System.Windows.Forms.TextBox textBoxResult;
        public System.Windows.Forms.Label labelCaptcha;
        private System.Windows.Forms.Button buttonOK;
    }
}