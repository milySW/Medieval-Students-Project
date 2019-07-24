namespace zadanie
{
    partial class FormProfessorInfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormProfessorInfo));
            this.progressBarEnergy = new System.Windows.Forms.ProgressBar();
            this.progressBarKnowledge = new System.Windows.Forms.ProgressBar();
            this.labelName = new System.Windows.Forms.Label();
            this.textBoxSex = new System.Windows.Forms.TextBox();
            this.textBoxStatus = new System.Windows.Forms.TextBox();
            this.pictureBoxSpell = new System.Windows.Forms.PictureBox();
            this.labelSpell = new System.Windows.Forms.Label();
            this.labelEnergy = new System.Windows.Forms.Label();
            this.labelKnowledge = new System.Windows.Forms.Label();
            this.labelSex = new System.Windows.Forms.Label();
            this.labelStatus = new System.Windows.Forms.Label();
            this.pictureBoxPerson = new System.Windows.Forms.PictureBox();
            this.richTextBoxHistory = new System.Windows.Forms.RichTextBox();
            this.labelSpellName = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSpell)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPerson)).BeginInit();
            this.SuspendLayout();
            // 
            // progressBarEnergy
            // 
            this.progressBarEnergy.Location = new System.Drawing.Point(200, 295);
            this.progressBarEnergy.Name = "progressBarEnergy";
            this.progressBarEnergy.Size = new System.Drawing.Size(113, 21);
            this.progressBarEnergy.TabIndex = 26;
            // 
            // progressBarKnowledge
            // 
            this.progressBarKnowledge.Location = new System.Drawing.Point(200, 235);
            this.progressBarKnowledge.Name = "progressBarKnowledge";
            this.progressBarKnowledge.Size = new System.Drawing.Size(113, 21);
            this.progressBarKnowledge.TabIndex = 25;
            // 
            // labelName
            // 
            this.labelName.BackColor = System.Drawing.Color.Transparent;
            this.labelName.Font = new System.Drawing.Font("Monotype Corsiva", 36F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelName.Location = new System.Drawing.Point(27, 18);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(370, 71);
            this.labelName.TabIndex = 24;
            this.labelName.Text = "Name";
            this.labelName.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // textBoxSex
            // 
            this.textBoxSex.Enabled = false;
            this.textBoxSex.Font = new System.Drawing.Font("Monotype Corsiva", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBoxSex.Location = new System.Drawing.Point(200, 175);
            this.textBoxSex.Name = "textBoxSex";
            this.textBoxSex.ReadOnly = true;
            this.textBoxSex.Size = new System.Drawing.Size(113, 30);
            this.textBoxSex.TabIndex = 23;
            this.textBoxSex.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxStatus
            // 
            this.textBoxStatus.Enabled = false;
            this.textBoxStatus.Font = new System.Drawing.Font("Monotype Corsiva", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBoxStatus.Location = new System.Drawing.Point(200, 116);
            this.textBoxStatus.Name = "textBoxStatus";
            this.textBoxStatus.ReadOnly = true;
            this.textBoxStatus.Size = new System.Drawing.Size(113, 30);
            this.textBoxStatus.TabIndex = 22;
            this.textBoxStatus.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // pictureBoxSpell
            // 
            this.pictureBoxSpell.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxSpell.Location = new System.Drawing.Point(200, 340);
            this.pictureBoxSpell.Name = "pictureBoxSpell";
            this.pictureBoxSpell.Size = new System.Drawing.Size(113, 89);
            this.pictureBoxSpell.TabIndex = 21;
            this.pictureBoxSpell.TabStop = false;
            // 
            // labelSpell
            // 
            this.labelSpell.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelSpell.Font = new System.Drawing.Font("Monotype Corsiva", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelSpell.Image = ((System.Drawing.Image)(resources.GetObject("labelSpell.Image")));
            this.labelSpell.Location = new System.Drawing.Point(27, 355);
            this.labelSpell.Name = "labelSpell";
            this.labelSpell.Size = new System.Drawing.Size(151, 41);
            this.labelSpell.TabIndex = 20;
            this.labelSpell.Text = "Spell";
            this.labelSpell.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // labelEnergy
            // 
            this.labelEnergy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelEnergy.Font = new System.Drawing.Font("Monotype Corsiva", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelEnergy.Image = ((System.Drawing.Image)(resources.GetObject("labelEnergy.Image")));
            this.labelEnergy.Location = new System.Drawing.Point(27, 284);
            this.labelEnergy.Name = "labelEnergy";
            this.labelEnergy.Size = new System.Drawing.Size(151, 41);
            this.labelEnergy.TabIndex = 19;
            this.labelEnergy.Text = "Energy";
            this.labelEnergy.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // labelKnowledge
            // 
            this.labelKnowledge.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelKnowledge.Font = new System.Drawing.Font("Monotype Corsiva", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelKnowledge.Image = ((System.Drawing.Image)(resources.GetObject("labelKnowledge.Image")));
            this.labelKnowledge.Location = new System.Drawing.Point(27, 224);
            this.labelKnowledge.Name = "labelKnowledge";
            this.labelKnowledge.Size = new System.Drawing.Size(151, 41);
            this.labelKnowledge.TabIndex = 18;
            this.labelKnowledge.Text = "Knowledge";
            this.labelKnowledge.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // labelSex
            // 
            this.labelSex.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelSex.Font = new System.Drawing.Font("Monotype Corsiva", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelSex.Image = ((System.Drawing.Image)(resources.GetObject("labelSex.Image")));
            this.labelSex.Location = new System.Drawing.Point(27, 167);
            this.labelSex.Name = "labelSex";
            this.labelSex.Size = new System.Drawing.Size(151, 41);
            this.labelSex.TabIndex = 17;
            this.labelSex.Text = "Sex";
            this.labelSex.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // labelStatus
            // 
            this.labelStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelStatus.Font = new System.Drawing.Font("Monotype Corsiva", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelStatus.Image = ((System.Drawing.Image)(resources.GetObject("labelStatus.Image")));
            this.labelStatus.Location = new System.Drawing.Point(27, 108);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(151, 41);
            this.labelStatus.TabIndex = 16;
            this.labelStatus.Text = "Status";
            this.labelStatus.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // pictureBoxPerson
            // 
            this.pictureBoxPerson.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxPerson.Location = new System.Drawing.Point(574, 98);
            this.pictureBoxPerson.Name = "pictureBoxPerson";
            this.pictureBoxPerson.Size = new System.Drawing.Size(239, 298);
            this.pictureBoxPerson.TabIndex = 15;
            this.pictureBoxPerson.TabStop = false;
            // 
            // richTextBoxHistory
            // 
            this.richTextBoxHistory.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.richTextBoxHistory.Font = new System.Drawing.Font("Monotype Corsiva", 12F, System.Drawing.FontStyle.Italic);
            this.richTextBoxHistory.Location = new System.Drawing.Point(330, 98);
            this.richTextBoxHistory.Name = "richTextBoxHistory";
            this.richTextBoxHistory.ReadOnly = true;
            this.richTextBoxHistory.Size = new System.Drawing.Size(218, 298);
            this.richTextBoxHistory.TabIndex = 27;
            this.richTextBoxHistory.Text = "";
            // 
            // labelSpellName
            // 
            this.labelSpellName.AutoSize = true;
            this.labelSpellName.BackColor = System.Drawing.Color.Transparent;
            this.labelSpellName.Font = new System.Drawing.Font("Monotype Corsiva", 10.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSpellName.Location = new System.Drawing.Point(196, 433);
            this.labelSpellName.Name = "labelSpellName";
            this.labelSpellName.Size = new System.Drawing.Size(117, 22);
            this.labelSpellName.TabIndex = 28;
            this.labelSpellName.Text = "labelSpellName";
            this.labelSpellName.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // FormProfessorInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(825, 464);
            this.Controls.Add(this.labelSpellName);
            this.Controls.Add(this.richTextBoxHistory);
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
            this.Name = "FormProfessorInfo";
            this.Text = "FormProfessor";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSpell)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPerson)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ProgressBar progressBarEnergy;
        public System.Windows.Forms.ProgressBar progressBarKnowledge;
        public System.Windows.Forms.Label labelName;
        public System.Windows.Forms.TextBox textBoxSex;
        public System.Windows.Forms.TextBox textBoxStatus;
        public System.Windows.Forms.PictureBox pictureBoxSpell;
        private System.Windows.Forms.Label labelSpell;
        private System.Windows.Forms.Label labelEnergy;
        private System.Windows.Forms.Label labelKnowledge;
        private System.Windows.Forms.Label labelSex;
        private System.Windows.Forms.Label labelStatus;
        public System.Windows.Forms.PictureBox pictureBoxPerson;
        public System.Windows.Forms.RichTextBox richTextBoxHistory;
        public System.Windows.Forms.Label labelSpellName;
    }
}