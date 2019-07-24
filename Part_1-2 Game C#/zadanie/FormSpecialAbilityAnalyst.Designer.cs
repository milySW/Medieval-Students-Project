namespace zadanie
{
    partial class FormSpecialAbilityAnalyst
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSpecialAbilityAnalyst));
            this.pictureBoxIntegral = new System.Windows.Forms.PictureBox();
            this.textBoxResult = new System.Windows.Forms.TextBox();
            this.labelUpperLimit = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.labelLowerLimit = new System.Windows.Forms.Label();
            this.labelDx = new System.Windows.Forms.Label();
            this.buttonOK = new System.Windows.Forms.Button();
            this.labelRealDx = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIntegral)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxIntegral
            // 
            this.pictureBoxIntegral.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxIntegral.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBoxIntegral.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxIntegral.Image")));
            this.pictureBoxIntegral.Location = new System.Drawing.Point(31, 38);
            this.pictureBoxIntegral.Name = "pictureBoxIntegral";
            this.pictureBoxIntegral.Size = new System.Drawing.Size(78, 110);
            this.pictureBoxIntegral.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxIntegral.TabIndex = 0;
            this.pictureBoxIntegral.TabStop = false;
            // 
            // textBoxResult
            // 
            this.textBoxResult.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.textBoxResult.Font = new System.Drawing.Font("Monotype Corsiva", 16F, System.Drawing.FontStyle.Italic);
            this.textBoxResult.Location = new System.Drawing.Point(324, 79);
            this.textBoxResult.Name = "textBoxResult";
            this.textBoxResult.Size = new System.Drawing.Size(116, 37);
            this.textBoxResult.TabIndex = 1;
            this.textBoxResult.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // labelUpperLimit
            // 
            this.labelUpperLimit.AutoSize = true;
            this.labelUpperLimit.BackColor = System.Drawing.Color.Transparent;
            this.labelUpperLimit.Font = new System.Drawing.Font("Monotype Corsiva", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelUpperLimit.Location = new System.Drawing.Point(98, 51);
            this.labelUpperLimit.Name = "labelUpperLimit";
            this.labelUpperLimit.Size = new System.Drawing.Size(52, 24);
            this.labelUpperLimit.TabIndex = 4;
            this.labelUpperLimit.Text = "label1";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(195, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(147, 171);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // labelLowerLimit
            // 
            this.labelLowerLimit.AutoSize = true;
            this.labelLowerLimit.BackColor = System.Drawing.Color.Transparent;
            this.labelLowerLimit.Font = new System.Drawing.Font("Monotype Corsiva", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelLowerLimit.Location = new System.Drawing.Point(84, 124);
            this.labelLowerLimit.Name = "labelLowerLimit";
            this.labelLowerLimit.Size = new System.Drawing.Size(52, 24);
            this.labelLowerLimit.TabIndex = 6;
            this.labelLowerLimit.Text = "label2";
            // 
            // labelDx
            // 
            this.labelDx.AutoSize = true;
            this.labelDx.BackColor = System.Drawing.Color.Transparent;
            this.labelDx.Font = new System.Drawing.Font("Monotype Corsiva", 19.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelDx.Location = new System.Drawing.Point(126, 76);
            this.labelDx.Name = "labelDx";
            this.labelDx.Size = new System.Drawing.Size(62, 40);
            this.labelDx.TabIndex = 7;
            this.labelDx.Text = "100";
            // 
            // buttonOK
            // 
            this.buttonOK.Font = new System.Drawing.Font("Monotype Corsiva", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonOK.Image = ((System.Drawing.Image)(resources.GetObject("buttonOK.Image")));
            this.buttonOK.Location = new System.Drawing.Point(348, 122);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(82, 48);
            this.buttonOK.TabIndex = 8;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.ButtonOK_Click);
            // 
            // labelRealDx
            // 
            this.labelRealDx.AutoSize = true;
            this.labelRealDx.BackColor = System.Drawing.Color.Transparent;
            this.labelRealDx.Font = new System.Drawing.Font("Monotype Corsiva", 19.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRealDx.Location = new System.Drawing.Point(185, 75);
            this.labelRealDx.Name = "labelRealDx";
            this.labelRealDx.Size = new System.Drawing.Size(47, 41);
            this.labelRealDx.TabIndex = 9;
            this.labelRealDx.Text = "dx";
            // 
            // FormSpecialAbilityAnalyst
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(455, 184);
            this.Controls.Add(this.labelRealDx);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.labelDx);
            this.Controls.Add(this.labelLowerLimit);
            this.Controls.Add(this.labelUpperLimit);
            this.Controls.Add(this.textBoxResult);
            this.Controls.Add(this.pictureBoxIntegral);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormSpecialAbilityAnalyst";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Calculate integral";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIntegral)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxIntegral;
        private System.Windows.Forms.TextBox textBoxResult;
        public System.Windows.Forms.Label labelUpperLimit;
        private System.Windows.Forms.PictureBox pictureBox1;
        public System.Windows.Forms.Label labelLowerLimit;
        public System.Windows.Forms.Label labelDx;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Label labelRealDx;
    }
}