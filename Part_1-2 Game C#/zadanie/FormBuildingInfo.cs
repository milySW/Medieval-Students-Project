using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace zadanie
{
    public partial class FormBuildingInfo : Form
    {
        public string WoodCost { get; }
        public string StoneCost { get; }
        public string NotesCost { get; }
        public string GoldCost { get; }
        public string BuildingInfo { get; }
        public string BuildingPictureName { get; }

        /// <summary>
        /// Forma z informacjami o budynku. Jako argumenty przyjmuje iformacje o kosztach, opis i nazwe obrazka.
        /// </summary>
        /// <param name="wood"></param>
        /// <param name="stone"></param>
        /// <param name="notes"></param>
        /// <param name="gold"></param>
        /// <param name="info"></param>
        /// <param name="pictureName"></param>
        public FormBuildingInfo(String wood, String stone, String notes, String gold,
            String info, String pictureName)
        {
            InitializeComponent();
            WoodCost = wood;
            StoneCost = stone;
            NotesCost = notes;
            GoldCost = gold;
            BuildingInfo = info;
            BuildingPictureName= pictureName;
        }

        /// <summary>
        /// Załadowanie okna z informacjami o budynku.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormOneLevelInfo_Load(object sender, EventArgs e)
        {
            // Wczytanie kosztów budynku.
            textBoxWoodCost.Text = WoodCost;
            textBoxStoneCost.Text = StoneCost;
            textBoxGoldCost.Text = GoldCost;
            textBoxNotesCost.Text = NotesCost;

            // Wczytanie opisu budynku.
            richTextBoxInfo.Text = BuildingInfo;

            // Załadowanie obrazka budynku.
            string filename = Directory.GetParent(Directory.GetParent(Directory.GetParent
                    (System.AppDomain.CurrentDomain.BaseDirectory).FullName).FullName).FullName;
            pictureBoxBuilding.Image = Image.FromFile(filename + "/Images/" + BuildingPictureName);
            pictureBoxBuilding.SizeMode = PictureBoxSizeMode.StretchImage;
        }
    }
}
