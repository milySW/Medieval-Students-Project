namespace zadanie
{
    partial class FormSelectCharacter
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSelectCharacter));
            this.pictureBoxProfessor = new System.Windows.Forms.PictureBox();
            this.buttonMan = new System.Windows.Forms.Button();
            this.buttonWoman = new System.Windows.Forms.Button();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.progressBarLifeEnergy = new System.Windows.Forms.ProgressBar();
            this.progressBarKnowledge = new System.Windows.Forms.ProgressBar();
            this.labelName = new System.Windows.Forms.Label();
            this.labelLifeEnergy = new System.Windows.Forms.Label();
            this.labelKnowledge = new System.Windows.Forms.Label();
            this.labelClass = new System.Windows.Forms.Label();
            this.buttonSelect = new System.Windows.Forms.Button();
            this.buttonPrevious = new System.Windows.Forms.Button();
            this.buttonNext = new System.Windows.Forms.Button();
            this.richTextBoxCharacterInfo = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxProfessor)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxProfessor
            // 
            this.pictureBoxProfessor.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxProfessor.Location = new System.Drawing.Point(53, 51);
            this.pictureBoxProfessor.Name = "pictureBoxProfessor";
            this.pictureBoxProfessor.Size = new System.Drawing.Size(339, 356);
            this.pictureBoxProfessor.TabIndex = 0;
            this.pictureBoxProfessor.TabStop = false;
            // 
            // buttonMan
            // 
            this.buttonMan.Font = new System.Drawing.Font("Monotype Corsiva", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonMan.Image = ((System.Drawing.Image)(resources.GetObject("buttonMan.Image")));
            this.buttonMan.Location = new System.Drawing.Point(407, 146);
            this.buttonMan.Name = "buttonMan";
            this.buttonMan.Size = new System.Drawing.Size(156, 65);
            this.buttonMan.TabIndex = 1;
            this.buttonMan.Text = "Man";
            this.buttonMan.UseVisualStyleBackColor = true;
            this.buttonMan.Click += new System.EventHandler(this.ButtonMan_Click);
            // 
            // buttonWoman
            // 
            this.buttonWoman.Font = new System.Drawing.Font("Monotype Corsiva", 18F, System.Drawing.FontStyle.Italic);
            this.buttonWoman.Image = ((System.Drawing.Image)(resources.GetObject("buttonWoman.Image")));
            this.buttonWoman.Location = new System.Drawing.Point(579, 146);
            this.buttonWoman.Name = "buttonWoman";
            this.buttonWoman.Size = new System.Drawing.Size(176, 65);
            this.buttonWoman.TabIndex = 2;
            this.buttonWoman.Text = "Woman";
            this.buttonWoman.UseVisualStyleBackColor = true;
            this.buttonWoman.Click += new System.EventHandler(this.ButtonWoman_Click);
            // 
            // textBoxName
            // 
            this.textBoxName.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.textBoxName.Font = new System.Drawing.Font("Monotype Corsiva", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxName.Location = new System.Drawing.Point(579, 230);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(176, 41);
            this.textBoxName.TabIndex = 3;
            // 
            // progressBarLifeEnergy
            // 
            this.progressBarLifeEnergy.Location = new System.Drawing.Point(579, 286);
            this.progressBarLifeEnergy.Name = "progressBarLifeEnergy";
            this.progressBarLifeEnergy.Size = new System.Drawing.Size(176, 37);
            this.progressBarLifeEnergy.TabIndex = 4;
            // 
            // progressBarKnowledge
            // 
            this.progressBarKnowledge.Location = new System.Drawing.Point(579, 348);
            this.progressBarKnowledge.Name = "progressBarKnowledge";
            this.progressBarKnowledge.Size = new System.Drawing.Size(176, 37);
            this.progressBarKnowledge.TabIndex = 5;
            // 
            // labelName
            // 
            this.labelName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelName.Font = new System.Drawing.Font("Monotype Corsiva", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelName.Image = ((System.Drawing.Image)(resources.GetObject("labelName.Image")));
            this.labelName.Location = new System.Drawing.Point(410, 230);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(153, 37);
            this.labelName.TabIndex = 6;
            this.labelName.Text = "Name";
            this.labelName.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // labelLifeEnergy
            // 
            this.labelLifeEnergy.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelLifeEnergy.Font = new System.Drawing.Font("Monotype Corsiva", 18F, System.Drawing.FontStyle.Italic);
            this.labelLifeEnergy.Image = ((System.Drawing.Image)(resources.GetObject("labelLifeEnergy.Image")));
            this.labelLifeEnergy.Location = new System.Drawing.Point(410, 286);
            this.labelLifeEnergy.Name = "labelLifeEnergy";
            this.labelLifeEnergy.Size = new System.Drawing.Size(153, 37);
            this.labelLifeEnergy.TabIndex = 7;
            this.labelLifeEnergy.Text = "Life energy";
            this.labelLifeEnergy.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // labelKnowledge
            // 
            this.labelKnowledge.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelKnowledge.Font = new System.Drawing.Font("Monotype Corsiva", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelKnowledge.Image = ((System.Drawing.Image)(resources.GetObject("labelKnowledge.Image")));
            this.labelKnowledge.Location = new System.Drawing.Point(410, 344);
            this.labelKnowledge.Name = "labelKnowledge";
            this.labelKnowledge.Size = new System.Drawing.Size(153, 41);
            this.labelKnowledge.TabIndex = 8;
            this.labelKnowledge.Text = "Knowledge";
            this.labelKnowledge.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // labelClass
            // 
            this.labelClass.BackColor = System.Drawing.Color.Transparent;
            this.labelClass.Font = new System.Drawing.Font("Monotype Corsiva", 36F, System.Drawing.FontStyle.Italic);
            this.labelClass.Location = new System.Drawing.Point(407, 34);
            this.labelClass.Name = "labelClass";
            this.labelClass.Size = new System.Drawing.Size(636, 82);
            this.labelClass.TabIndex = 9;
            this.labelClass.Text = "Class";
            this.labelClass.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // buttonSelect
            // 
            this.buttonSelect.Font = new System.Drawing.Font("Monotype Corsiva", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonSelect.Image = ((System.Drawing.Image)(resources.GetObject("buttonSelect.Image")));
            this.buttonSelect.Location = new System.Drawing.Point(410, 408);
            this.buttonSelect.Name = "buttonSelect";
            this.buttonSelect.Size = new System.Drawing.Size(350, 43);
            this.buttonSelect.TabIndex = 10;
            this.buttonSelect.Text = "Select";
            this.buttonSelect.UseVisualStyleBackColor = true;
            this.buttonSelect.Click += new System.EventHandler(this.ButtonSelect_Click);
            // 
            // buttonPrevious
            // 
            this.buttonPrevious.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonPrevious.BackgroundImage")));
            this.buttonPrevious.Font = new System.Drawing.Font("Monotype Corsiva", 16.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonPrevious.Image = ((System.Drawing.Image)(resources.GetObject("buttonPrevious.Image")));
            this.buttonPrevious.Location = new System.Drawing.Point(53, 413);
            this.buttonPrevious.Name = "buttonPrevious";
            this.buttonPrevious.Size = new System.Drawing.Size(159, 38);
            this.buttonPrevious.TabIndex = 11;
            this.buttonPrevious.Text = "Previous";
            this.buttonPrevious.UseVisualStyleBackColor = true;
            this.buttonPrevious.Click += new System.EventHandler(this.ButtonPrevious_Click);
            // 
            // buttonNext
            // 
            this.buttonNext.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonNext.BackgroundImage")));
            this.buttonNext.Font = new System.Drawing.Font("Monotype Corsiva", 16.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonNext.Image = ((System.Drawing.Image)(resources.GetObject("buttonNext.Image")));
            this.buttonNext.Location = new System.Drawing.Point(232, 413);
            this.buttonNext.Name = "buttonNext";
            this.buttonNext.Size = new System.Drawing.Size(160, 38);
            this.buttonNext.TabIndex = 12;
            this.buttonNext.Text = "Next";
            this.buttonNext.UseVisualStyleBackColor = true;
            this.buttonNext.Click += new System.EventHandler(this.ButtonNext_Click);
            // 
            // richTextBoxCharacterInfo
            // 
            this.richTextBoxCharacterInfo.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.richTextBoxCharacterInfo.Cursor = System.Windows.Forms.Cursors.Default;
            this.richTextBoxCharacterInfo.Font = new System.Drawing.Font("Monotype Corsiva", 14F, System.Drawing.FontStyle.Italic);
            this.richTextBoxCharacterInfo.Location = new System.Drawing.Point(782, 146);
            this.richTextBoxCharacterInfo.Name = "richTextBoxCharacterInfo";
            this.richTextBoxCharacterInfo.ReadOnly = true;
            this.richTextBoxCharacterInfo.Size = new System.Drawing.Size(261, 305);
            this.richTextBoxCharacterInfo.TabIndex = 13;
            this.richTextBoxCharacterInfo.Text = "";
            // 
            // FormSelectCharacter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1100, 475);
            this.Controls.Add(this.richTextBoxCharacterInfo);
            this.Controls.Add(this.buttonNext);
            this.Controls.Add(this.buttonPrevious);
            this.Controls.Add(this.buttonSelect);
            this.Controls.Add(this.labelClass);
            this.Controls.Add(this.labelKnowledge);
            this.Controls.Add(this.labelLifeEnergy);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.progressBarKnowledge);
            this.Controls.Add(this.progressBarLifeEnergy);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.buttonWoman);
            this.Controls.Add(this.buttonMan);
            this.Controls.Add(this.pictureBoxProfessor);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormSelectCharacter";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Select Character";
            this.Load += new System.EventHandler(this.FormSelectCharacter_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxProfessor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxProfessor;
        private System.Windows.Forms.Button buttonMan;
        private System.Windows.Forms.Button buttonWoman;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.ProgressBar progressBarLifeEnergy;
        private System.Windows.Forms.ProgressBar progressBarKnowledge;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Label labelLifeEnergy;
        private System.Windows.Forms.Label labelKnowledge;
        private System.Windows.Forms.Label labelClass;
        private System.Windows.Forms.Button buttonSelect;
        private System.Windows.Forms.Button buttonPrevious;
        private System.Windows.Forms.Button buttonNext;
        private System.Windows.Forms.RichTextBox richTextBoxCharacterInfo;
    }
}