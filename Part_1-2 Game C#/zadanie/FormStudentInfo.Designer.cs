namespace zadanie
{
    partial class FormStudentInfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormStudentInfo));
            this.pictureBoxPerson = new System.Windows.Forms.PictureBox();
            this.labelStatus = new System.Windows.Forms.Label();
            this.labelSex = new System.Windows.Forms.Label();
            this.labelKnowledge = new System.Windows.Forms.Label();
            this.labelEnergy = new System.Windows.Forms.Label();
            this.labelSpell = new System.Windows.Forms.Label();
            this.pictureBoxSpell = new System.Windows.Forms.PictureBox();
            this.textBoxStatus = new System.Windows.Forms.TextBox();
            this.textBoxSex = new System.Windows.Forms.TextBox();
            this.labelName = new System.Windows.Forms.Label();
            this.progressBarKnowledge = new System.Windows.Forms.ProgressBar();
            this.progressBarEnergy = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPerson)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSpell)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxPerson
            // 
            this.pictureBoxPerson.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxPerson.Location = new System.Drawing.Point(340, 112);
            this.pictureBoxPerson.Name = "pictureBoxPerson";
            this.pictureBoxPerson.Size = new System.Drawing.Size(239, 298);
            this.pictureBoxPerson.TabIndex = 0;
            this.pictureBoxPerson.TabStop = false;
            // 
            // labelStatus
            // 
            this.labelStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelStatus.Font = new System.Drawing.Font("Monotype Corsiva", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelStatus.Image = ((System.Drawing.Image)(resources.GetObject("labelStatus.Image")));
            this.labelStatus.Location = new System.Drawing.Point(26, 112);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(151, 41);
            this.labelStatus.TabIndex = 1;
            this.labelStatus.Text = "Status";
            this.labelStatus.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // labelSex
            // 
            this.labelSex.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelSex.Font = new System.Drawing.Font("Monotype Corsiva", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelSex.Image = ((System.Drawing.Image)(resources.GetObject("labelSex.Image")));
            this.labelSex.Location = new System.Drawing.Point(26, 171);
            this.labelSex.Name = "labelSex";
            this.labelSex.Size = new System.Drawing.Size(151, 41);
            this.labelSex.TabIndex = 2;
            this.labelSex.Text = "Sex";
            this.labelSex.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // labelKnowledge
            // 
            this.labelKnowledge.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelKnowledge.Font = new System.Drawing.Font("Monotype Corsiva", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelKnowledge.Image = ((System.Drawing.Image)(resources.GetObject("labelKnowledge.Image")));
            this.labelKnowledge.Location = new System.Drawing.Point(26, 228);
            this.labelKnowledge.Name = "labelKnowledge";
            this.labelKnowledge.Size = new System.Drawing.Size(151, 41);
            this.labelKnowledge.TabIndex = 3;
            this.labelKnowledge.Text = "Knowledge";
            this.labelKnowledge.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // labelEnergy
            // 
            this.labelEnergy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelEnergy.Font = new System.Drawing.Font("Monotype Corsiva", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelEnergy.Image = ((System.Drawing.Image)(resources.GetObject("labelEnergy.Image")));
            this.labelEnergy.Location = new System.Drawing.Point(26, 288);
            this.labelEnergy.Name = "labelEnergy";
            this.labelEnergy.Size = new System.Drawing.Size(151, 41);
            this.labelEnergy.TabIndex = 4;
            this.labelEnergy.Text = "Energy";
            this.labelEnergy.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // labelSpell
            // 
            this.labelSpell.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelSpell.Font = new System.Drawing.Font("Monotype Corsiva", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelSpell.Image = ((System.Drawing.Image)(resources.GetObject("labelSpell.Image")));
            this.labelSpell.Location = new System.Drawing.Point(26, 369);
            this.labelSpell.Name = "labelSpell";
            this.labelSpell.Size = new System.Drawing.Size(151, 41);
            this.labelSpell.TabIndex = 5;
            this.labelSpell.Text = "Spell";
            this.labelSpell.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // pictureBoxSpell
            // 
            this.pictureBoxSpell.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxSpell.Location = new System.Drawing.Point(199, 348);
            this.pictureBoxSpell.Name = "pictureBoxSpell";
            this.pictureBoxSpell.Size = new System.Drawing.Size(113, 89);
            this.pictureBoxSpell.TabIndex = 6;
            this.pictureBoxSpell.TabStop = false;
            // 
            // textBoxStatus
            // 
            this.textBoxStatus.Enabled = false;
            this.textBoxStatus.Font = new System.Drawing.Font("Monotype Corsiva", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBoxStatus.Location = new System.Drawing.Point(199, 120);
            this.textBoxStatus.Name = "textBoxStatus";
            this.textBoxStatus.ReadOnly = true;
            this.textBoxStatus.Size = new System.Drawing.Size(113, 30);
            this.textBoxStatus.TabIndex = 7;
            this.textBoxStatus.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxSex
            // 
            this.textBoxSex.Enabled = false;
            this.textBoxSex.Font = new System.Drawing.Font("Monotype Corsiva", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBoxSex.Location = new System.Drawing.Point(199, 179);
            this.textBoxSex.Name = "textBoxSex";
            this.textBoxSex.ReadOnly = true;
            this.textBoxSex.Size = new System.Drawing.Size(113, 30);
            this.textBoxSex.TabIndex = 11;
            this.textBoxSex.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // labelName
            // 
            this.labelName.BackColor = System.Drawing.Color.Transparent;
            this.labelName.Font = new System.Drawing.Font("Monotype Corsiva", 36F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelName.Location = new System.Drawing.Point(26, 22);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(370, 71);
            this.labelName.TabIndex = 12;
            this.labelName.Text = "Name";
            this.labelName.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // progressBarKnowledge
            // 
            this.progressBarKnowledge.Location = new System.Drawing.Point(199, 239);
            this.progressBarKnowledge.Name = "progressBarKnowledge";
            this.progressBarKnowledge.Size = new System.Drawing.Size(113, 21);
            this.progressBarKnowledge.TabIndex = 13;
            // 
            // progressBarEnergy
            // 
            this.progressBarEnergy.Location = new System.Drawing.Point(199, 299);
            this.progressBarEnergy.Name = "progressBarEnergy";
            this.progressBarEnergy.Size = new System.Drawing.Size(113, 21);
            this.progressBarEnergy.TabIndex = 14;
            // 
            // FormCharacterInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(609, 449);
            this.Controls.Add(this.progressBarEnergy);
            this.Controls.Add(this.progressBarKnowledge);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.textBoxSex);
            this.Controls.Add(this.textBoxStatus);
            this.Controls.Add(this.pictureBoxSpell);
            this.Controls.Add(this.labelSpell);
            this.Controls.Add(this.labelEnergy);
            this.Controls.Add(this.labelKnowledge);
            this.Controls.Add(this.labelSex);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.pictureBoxPerson);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormCharacterInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormCharacterInfo";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPerson)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSpell)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.PictureBox pictureBoxPerson;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.Label labelSex;
        private System.Windows.Forms.Label labelKnowledge;
        private System.Windows.Forms.Label labelEnergy;
        private System.Windows.Forms.Label labelSpell;
        public System.Windows.Forms.PictureBox pictureBoxSpell;
        public System.Windows.Forms.TextBox textBoxStatus;
        public System.Windows.Forms.TextBox textBoxSex;
        public System.Windows.Forms.Label labelName;
        public System.Windows.Forms.ProgressBar progressBarKnowledge;
        public System.Windows.Forms.ProgressBar progressBarEnergy;
    }
}