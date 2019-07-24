namespace zadanie
{
    partial class FormGame
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormGame));
            this.labelStudents = new System.Windows.Forms.Label();
            this.buttonResources = new System.Windows.Forms.Button();
            this.buttonBuildings = new System.Windows.Forms.Button();
            this.labelWarriors = new System.Windows.Forms.Label();
            this.labelTitle = new System.Windows.Forms.Label();
            this.pictureVillageImage = new System.Windows.Forms.PictureBox();
            this.buttonClose = new System.Windows.Forms.Button();
            this.textBoxNumberOfStudents = new System.Windows.Forms.TextBox();
            this.textBoxNumberOfWarriors = new System.Windows.Forms.TextBox();
            this.timerBeer = new System.Windows.Forms.Timer(this.components);
            this.timerWood = new System.Windows.Forms.Timer(this.components);
            this.timerStone = new System.Windows.Forms.Timer(this.components);
            this.timerNotes = new System.Windows.Forms.Timer(this.components);
            this.timerGold = new System.Windows.Forms.Timer(this.components);
            this.textBoxDayCounter = new System.Windows.Forms.TextBox();
            this.textBoxHourCounter = new System.Windows.Forms.TextBox();
            this.labelDay = new System.Windows.Forms.Label();
            this.labelHour = new System.Windows.Forms.Label();
            this.timerMinute = new System.Windows.Forms.Timer(this.components);
            this.timerConsumptionOfBeer = new System.Windows.Forms.Timer(this.components);
            this.buttonPause = new System.Windows.Forms.Button();
            this.timerEvents = new System.Windows.Forms.Timer(this.components);
            this.timerCheckForBattleEnd = new System.Windows.Forms.Timer(this.components);
            this.timerCheckForCharacterSelectEnd = new System.Windows.Forms.Timer(this.components);
            this.pictureBoxProfessorCharacter = new System.Windows.Forms.PictureBox();
            this.labelScore = new System.Windows.Forms.Label();
            this.textBoxScore = new System.Windows.Forms.TextBox();
            this.timerScore = new System.Windows.Forms.Timer(this.components);
            this.pictureBoxSawMill = new System.Windows.Forms.PictureBox();
            this.pictureBoxBarrack = new System.Windows.Forms.PictureBox();
            this.pictureBoxStonePitt = new System.Windows.Forms.PictureBox();
            this.pictureBoxLibrary = new System.Windows.Forms.PictureBox();
            this.pictureBoxDormitory = new System.Windows.Forms.PictureBox();
            this.pictureBoxMarket = new System.Windows.Forms.PictureBox();
            this.pictureBoxInn = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureVillageImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxProfessorCharacter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSawMill)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBarrack)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxStonePitt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLibrary)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDormitory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMarket)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxInn)).BeginInit();
            this.SuspendLayout();
            // 
            // labelStudents
            // 
            this.labelStudents.AutoSize = true;
            this.labelStudents.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelStudents.Font = new System.Drawing.Font("Monotype Corsiva", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelStudents.Image = ((System.Drawing.Image)(resources.GetObject("labelStudents.Image")));
            this.labelStudents.Location = new System.Drawing.Point(713, 269);
            this.labelStudents.Name = "labelStudents";
            this.labelStudents.Size = new System.Drawing.Size(114, 39);
            this.labelStudents.TabIndex = 0;
            this.labelStudents.Text = "Students";
            // 
            // buttonResources
            // 
            this.buttonResources.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonResources.BackgroundImage")));
            this.buttonResources.Cursor = System.Windows.Forms.Cursors.Default;
            this.buttonResources.Font = new System.Drawing.Font("Monotype Corsiva", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonResources.Image = ((System.Drawing.Image)(resources.GetObject("buttonResources.Image")));
            this.buttonResources.Location = new System.Drawing.Point(709, 134);
            this.buttonResources.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonResources.Name = "buttonResources";
            this.buttonResources.Size = new System.Drawing.Size(192, 55);
            this.buttonResources.TabIndex = 1;
            this.buttonResources.Text = "Resources";
            this.buttonResources.UseVisualStyleBackColor = true;
            this.buttonResources.Click += new System.EventHandler(this.ButtonResources_Click);
            // 
            // buttonBuildings
            // 
            this.buttonBuildings.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonBuildings.BackgroundImage")));
            this.buttonBuildings.Font = new System.Drawing.Font("Monotype Corsiva", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonBuildings.Image = ((System.Drawing.Image)(resources.GetObject("buttonBuildings.Image")));
            this.buttonBuildings.Location = new System.Drawing.Point(709, 203);
            this.buttonBuildings.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonBuildings.Name = "buttonBuildings";
            this.buttonBuildings.Size = new System.Drawing.Size(192, 55);
            this.buttonBuildings.TabIndex = 2;
            this.buttonBuildings.Text = "Buildings";
            this.buttonBuildings.UseVisualStyleBackColor = true;
            this.buttonBuildings.Click += new System.EventHandler(this.ButtonBuildings_Click);
            // 
            // labelWarriors
            // 
            this.labelWarriors.AutoSize = true;
            this.labelWarriors.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelWarriors.Font = new System.Drawing.Font("Monotype Corsiva", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelWarriors.Image = ((System.Drawing.Image)(resources.GetObject("labelWarriors.Image")));
            this.labelWarriors.Location = new System.Drawing.Point(713, 323);
            this.labelWarriors.Name = "labelWarriors";
            this.labelWarriors.Size = new System.Drawing.Size(114, 39);
            this.labelWarriors.TabIndex = 3;
            this.labelWarriors.Text = "Warriors";
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.BackColor = System.Drawing.Color.Transparent;
            this.labelTitle.Font = new System.Drawing.Font("Monotype Corsiva", 39.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelTitle.Location = new System.Drawing.Point(159, 32);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(495, 82);
            this.labelTitle.TabIndex = 4;
            this.labelTitle.Text = "Medieval Students";
            // 
            // pictureVillageImage
            // 
            this.pictureVillageImage.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureVillageImage.BackgroundImage")));
            this.pictureVillageImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureVillageImage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureVillageImage.Location = new System.Drawing.Point(40, 135);
            this.pictureVillageImage.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureVillageImage.Name = "pictureVillageImage";
            this.pictureVillageImage.Size = new System.Drawing.Size(641, 357);
            this.pictureVillageImage.TabIndex = 5;
            this.pictureVillageImage.TabStop = false;
            this.pictureVillageImage.Tag = "10000000";
            // 
            // buttonClose
            // 
            this.buttonClose.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonClose.BackgroundImage")));
            this.buttonClose.Font = new System.Drawing.Font("Monotype Corsiva", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonClose.Image = ((System.Drawing.Image)(resources.GetObject("buttonClose.Image")));
            this.buttonClose.Location = new System.Drawing.Point(713, 436);
            this.buttonClose.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(192, 55);
            this.buttonClose.TabIndex = 6;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.ButtonClose_Click);
            // 
            // textBoxNumberOfStudents
            // 
            this.textBoxNumberOfStudents.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.textBoxNumberOfStudents.Enabled = false;
            this.textBoxNumberOfStudents.Font = new System.Drawing.Font("Monotype Corsiva", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBoxNumberOfStudents.ImeMode = System.Windows.Forms.ImeMode.On;
            this.textBoxNumberOfStudents.Location = new System.Drawing.Point(845, 271);
            this.textBoxNumberOfStudents.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxNumberOfStudents.Name = "textBoxNumberOfStudents";
            this.textBoxNumberOfStudents.ReadOnly = true;
            this.textBoxNumberOfStudents.Size = new System.Drawing.Size(48, 37);
            this.textBoxNumberOfStudents.TabIndex = 7;
            this.textBoxNumberOfStudents.Text = "10";
            this.textBoxNumberOfStudents.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxNumberOfWarriors
            // 
            this.textBoxNumberOfWarriors.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.textBoxNumberOfWarriors.Enabled = false;
            this.textBoxNumberOfWarriors.Font = new System.Drawing.Font("Monotype Corsiva", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBoxNumberOfWarriors.Location = new System.Drawing.Point(845, 324);
            this.textBoxNumberOfWarriors.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxNumberOfWarriors.Name = "textBoxNumberOfWarriors";
            this.textBoxNumberOfWarriors.ReadOnly = true;
            this.textBoxNumberOfWarriors.Size = new System.Drawing.Size(48, 37);
            this.textBoxNumberOfWarriors.TabIndex = 8;
            this.textBoxNumberOfWarriors.Text = "0";
            this.textBoxNumberOfWarriors.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // timerBeer
            // 
            this.timerBeer.Interval = 1000;
            this.timerBeer.Tick += new System.EventHandler(this.TimerBeer_Tick);
            // 
            // timerWood
            // 
            this.timerWood.Interval = 2400;
            this.timerWood.Tick += new System.EventHandler(this.TimerWood_Tick);
            // 
            // timerStone
            // 
            this.timerStone.Interval = 2880;
            this.timerStone.Tick += new System.EventHandler(this.TimerStone_Tick);
            // 
            // timerNotes
            // 
            this.timerNotes.Interval = 28800;
            this.timerNotes.Tick += new System.EventHandler(this.TimerNotes_Tick);
            // 
            // timerGold
            // 
            this.timerGold.Interval = 1000;
            this.timerGold.Tick += new System.EventHandler(this.TimerGold_Tick);
            // 
            // textBoxDayCounter
            // 
            this.textBoxDayCounter.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.textBoxDayCounter.Enabled = false;
            this.textBoxDayCounter.Font = new System.Drawing.Font("Monotype Corsiva", 10F, System.Drawing.FontStyle.Italic);
            this.textBoxDayCounter.Location = new System.Drawing.Point(507, 466);
            this.textBoxDayCounter.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxDayCounter.Name = "textBoxDayCounter";
            this.textBoxDayCounter.ReadOnly = true;
            this.textBoxDayCounter.Size = new System.Drawing.Size(57, 26);
            this.textBoxDayCounter.TabIndex = 9;
            this.textBoxDayCounter.Text = "1";
            this.textBoxDayCounter.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxHourCounter
            // 
            this.textBoxHourCounter.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.textBoxHourCounter.Enabled = false;
            this.textBoxHourCounter.Font = new System.Drawing.Font("Monotype Corsiva", 10F, System.Drawing.FontStyle.Italic);
            this.textBoxHourCounter.Location = new System.Drawing.Point(628, 466);
            this.textBoxHourCounter.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxHourCounter.Name = "textBoxHourCounter";
            this.textBoxHourCounter.ReadOnly = true;
            this.textBoxHourCounter.Size = new System.Drawing.Size(52, 26);
            this.textBoxHourCounter.TabIndex = 10;
            this.textBoxHourCounter.Text = "12:00";
            this.textBoxHourCounter.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // labelDay
            // 
            this.labelDay.BackColor = System.Drawing.Color.Transparent;
            this.labelDay.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelDay.Font = new System.Drawing.Font("Monotype Corsiva", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelDay.Image = ((System.Drawing.Image)(resources.GetObject("labelDay.Image")));
            this.labelDay.Location = new System.Drawing.Point(457, 466);
            this.labelDay.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelDay.Name = "labelDay";
            this.labelDay.Size = new System.Drawing.Size(51, 26);
            this.labelDay.TabIndex = 11;
            this.labelDay.Text = "Day";
            // 
            // labelHour
            // 
            this.labelHour.BackColor = System.Drawing.Color.Transparent;
            this.labelHour.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelHour.Font = new System.Drawing.Font("Monotype Corsiva", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelHour.Image = ((System.Drawing.Image)(resources.GetObject("labelHour.Image")));
            this.labelHour.Location = new System.Drawing.Point(572, 466);
            this.labelHour.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelHour.Name = "labelHour";
            this.labelHour.Size = new System.Drawing.Size(58, 26);
            this.labelHour.TabIndex = 12;
            this.labelHour.Text = "Hour";
            // 
            // timerMinute
            // 
            this.timerMinute.Enabled = true;
            this.timerMinute.Tick += new System.EventHandler(this.TimerMinute_Tick);
            // 
            // timerConsumptionOfBeer
            // 
            this.timerConsumptionOfBeer.Interval = 1440;
            this.timerConsumptionOfBeer.Tick += new System.EventHandler(this.TimerConsumptionOfBeer_Tick);
            // 
            // buttonPause
            // 
            this.buttonPause.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonPause.BackgroundImage")));
            this.buttonPause.Font = new System.Drawing.Font("Monotype Corsiva", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonPause.Image = ((System.Drawing.Image)(resources.GetObject("buttonPause.Image")));
            this.buttonPause.Location = new System.Drawing.Point(709, 376);
            this.buttonPause.Name = "buttonPause";
            this.buttonPause.Size = new System.Drawing.Size(192, 55);
            this.buttonPause.TabIndex = 13;
            this.buttonPause.Text = "Pause";
            this.buttonPause.UseVisualStyleBackColor = true;
            this.buttonPause.Click += new System.EventHandler(this.ButtonPause_Click);
            // 
            // timerEvents
            // 
            this.timerEvents.Interval = 32000;
            this.timerEvents.Tick += new System.EventHandler(this.TimerEvents_Tick);
            // 
            // timerCheckForBattleEnd
            // 
            this.timerCheckForBattleEnd.Tick += new System.EventHandler(this.TimerCheckForBattleEnd_Tick);
            // 
            // timerCheckForCharacterSelectEnd
            // 
            this.timerCheckForCharacterSelectEnd.Tick += new System.EventHandler(this.TimerCheckForCharacterSelectEnd_Tick);
            // 
            // pictureBoxProfessorCharacter
            // 
            this.pictureBoxProfessorCharacter.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxProfessorCharacter.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBoxProfessorCharacter.BackgroundImage")));
            this.pictureBoxProfessorCharacter.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBoxProfessorCharacter.Location = new System.Drawing.Point(546, 314);
            this.pictureBoxProfessorCharacter.Name = "pictureBoxProfessorCharacter";
            this.pictureBoxProfessorCharacter.Size = new System.Drawing.Size(126, 136);
            this.pictureBoxProfessorCharacter.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxProfessorCharacter.TabIndex = 14;
            this.pictureBoxProfessorCharacter.TabStop = false;
            // 
            // labelScore
            // 
            this.labelScore.Font = new System.Drawing.Font("Monotype Corsiva", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelScore.Image = ((System.Drawing.Image)(resources.GetObject("labelScore.Image")));
            this.labelScore.Location = new System.Drawing.Point(37, 499);
            this.labelScore.Name = "labelScore";
            this.labelScore.Size = new System.Drawing.Size(58, 26);
            this.labelScore.TabIndex = 16;
            this.labelScore.Text = "Score";
            this.labelScore.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // textBoxScore
            // 
            this.textBoxScore.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.textBoxScore.Font = new System.Drawing.Font("Monotype Corsiva", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxScore.ForeColor = System.Drawing.SystemColors.WindowText;
            this.textBoxScore.Location = new System.Drawing.Point(101, 497);
            this.textBoxScore.Name = "textBoxScore";
            this.textBoxScore.Size = new System.Drawing.Size(113, 27);
            this.textBoxScore.TabIndex = 17;
            this.textBoxScore.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // timerScore
            // 
            this.timerScore.Interval = 50;
            this.timerScore.Tick += new System.EventHandler(this.TimerScore_Tick);
            // 
            // pictureBoxSawMill
            // 
            this.pictureBoxSawMill.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxSawMill.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBoxSawMill.BackgroundImage")));
            this.pictureBoxSawMill.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBoxSawMill.Location = new System.Drawing.Point(175, 146);
            this.pictureBoxSawMill.Name = "pictureBoxSawMill";
            this.pictureBoxSawMill.Size = new System.Drawing.Size(68, 54);
            this.pictureBoxSawMill.TabIndex = 18;
            this.pictureBoxSawMill.TabStop = false;
            this.pictureBoxSawMill.Visible = false;
            // 
            // pictureBoxBarrack
            // 
            this.pictureBoxBarrack.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxBarrack.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBoxBarrack.BackgroundImage")));
            this.pictureBoxBarrack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBoxBarrack.Location = new System.Drawing.Point(295, 248);
            this.pictureBoxBarrack.Name = "pictureBoxBarrack";
            this.pictureBoxBarrack.Size = new System.Drawing.Size(136, 65);
            this.pictureBoxBarrack.TabIndex = 19;
            this.pictureBoxBarrack.TabStop = false;
            this.pictureBoxBarrack.Visible = false;
            // 
            // pictureBoxStonePitt
            // 
            this.pictureBoxStonePitt.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxStonePitt.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBoxStonePitt.BackgroundImage")));
            this.pictureBoxStonePitt.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBoxStonePitt.Location = new System.Drawing.Point(114, 381);
            this.pictureBoxStonePitt.Name = "pictureBoxStonePitt";
            this.pictureBoxStonePitt.Size = new System.Drawing.Size(55, 38);
            this.pictureBoxStonePitt.TabIndex = 20;
            this.pictureBoxStonePitt.TabStop = false;
            this.pictureBoxStonePitt.Visible = false;
            // 
            // pictureBoxLibrary
            // 
            this.pictureBoxLibrary.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxLibrary.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBoxLibrary.BackgroundImage")));
            this.pictureBoxLibrary.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBoxLibrary.Location = new System.Drawing.Point(357, 376);
            this.pictureBoxLibrary.Name = "pictureBoxLibrary";
            this.pictureBoxLibrary.Size = new System.Drawing.Size(74, 112);
            this.pictureBoxLibrary.TabIndex = 21;
            this.pictureBoxLibrary.TabStop = false;
            this.pictureBoxLibrary.Visible = false;
            // 
            // pictureBoxDormitory
            // 
            this.pictureBoxDormitory.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxDormitory.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBoxDormitory.BackgroundImage")));
            this.pictureBoxDormitory.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBoxDormitory.Location = new System.Drawing.Point(101, 259);
            this.pictureBoxDormitory.Name = "pictureBoxDormitory";
            this.pictureBoxDormitory.Size = new System.Drawing.Size(68, 49);
            this.pictureBoxDormitory.TabIndex = 22;
            this.pictureBoxDormitory.TabStop = false;
            this.pictureBoxDormitory.Visible = false;
            // 
            // pictureBoxMarket
            // 
            this.pictureBoxMarket.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxMarket.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBoxMarket.BackgroundImage")));
            this.pictureBoxMarket.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBoxMarket.Location = new System.Drawing.Point(101, 203);
            this.pictureBoxMarket.Name = "pictureBoxMarket";
            this.pictureBoxMarket.Size = new System.Drawing.Size(68, 50);
            this.pictureBoxMarket.TabIndex = 23;
            this.pictureBoxMarket.TabStop = false;
            this.pictureBoxMarket.Visible = false;
            // 
            // pictureBoxInn
            // 
            this.pictureBoxInn.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxInn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBoxInn.BackgroundImage")));
            this.pictureBoxInn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBoxInn.Location = new System.Drawing.Point(423, 143);
            this.pictureBoxInn.Name = "pictureBoxInn";
            this.pictureBoxInn.Size = new System.Drawing.Size(67, 57);
            this.pictureBoxInn.TabIndex = 24;
            this.pictureBoxInn.TabStop = false;
            this.pictureBoxInn.Visible = false;
            // 
            // FormGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(917, 532);
            this.Controls.Add(this.pictureBoxInn);
            this.Controls.Add(this.pictureBoxMarket);
            this.Controls.Add(this.pictureBoxDormitory);
            this.Controls.Add(this.pictureBoxLibrary);
            this.Controls.Add(this.pictureBoxStonePitt);
            this.Controls.Add(this.pictureBoxBarrack);
            this.Controls.Add(this.pictureBoxSawMill);
            this.Controls.Add(this.textBoxScore);
            this.Controls.Add(this.labelScore);
            this.Controls.Add(this.pictureBoxProfessorCharacter);
            this.Controls.Add(this.buttonPause);
            this.Controls.Add(this.labelDay);
            this.Controls.Add(this.textBoxDayCounter);
            this.Controls.Add(this.labelHour);
            this.Controls.Add(this.textBoxHourCounter);
            this.Controls.Add(this.textBoxNumberOfWarriors);
            this.Controls.Add(this.textBoxNumberOfStudents);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.labelTitle);
            this.Controls.Add(this.labelWarriors);
            this.Controls.Add(this.buttonBuildings);
            this.Controls.Add(this.buttonResources);
            this.Controls.Add(this.labelStudents);
            this.Controls.Add(this.pictureVillageImage);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.Name = "FormGame";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Medieval Students";
            this.Load += new System.EventHandler(this.FormGame_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureVillageImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxProfessorCharacter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSawMill)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBarrack)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxStonePitt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLibrary)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDormitory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMarket)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxInn)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelStudents;
        private System.Windows.Forms.Button buttonResources;
        private System.Windows.Forms.Button buttonBuildings;
        private System.Windows.Forms.Label labelWarriors;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.TextBox textBoxNumberOfStudents;
        private System.Windows.Forms.TextBox textBoxNumberOfWarriors;
        private System.Windows.Forms.Timer timerBeer;
        private System.Windows.Forms.Timer timerWood;
        private System.Windows.Forms.Timer timerStone;
        private System.Windows.Forms.Timer timerNotes;
        private System.Windows.Forms.Timer timerGold;
        private System.Windows.Forms.TextBox textBoxDayCounter;
        private System.Windows.Forms.TextBox textBoxHourCounter;
        private System.Windows.Forms.Label labelDay;
        private System.Windows.Forms.Label labelHour;
        private System.Windows.Forms.Timer timerMinute;
        public System.Windows.Forms.PictureBox pictureVillageImage;
        private System.Windows.Forms.Timer timerConsumptionOfBeer;
        private System.Windows.Forms.Button buttonPause;
        private System.Windows.Forms.Timer timerEvents;
        private System.Windows.Forms.Timer timerCheckForBattleEnd;
        private System.Windows.Forms.Timer timerCheckForCharacterSelectEnd;
        private System.Windows.Forms.PictureBox pictureBoxProfessorCharacter;
        private System.Windows.Forms.Label labelScore;
        private System.Windows.Forms.TextBox textBoxScore;
        private System.Windows.Forms.Timer timerScore;
        public System.Windows.Forms.PictureBox pictureBoxSawMill;
        public System.Windows.Forms.PictureBox pictureBoxBarrack;
        public System.Windows.Forms.PictureBox pictureBoxStonePitt;
        public System.Windows.Forms.PictureBox pictureBoxLibrary;
        public System.Windows.Forms.PictureBox pictureBoxDormitory;
        public System.Windows.Forms.PictureBox pictureBoxMarket;
        public System.Windows.Forms.PictureBox pictureBoxInn;
    }
}

