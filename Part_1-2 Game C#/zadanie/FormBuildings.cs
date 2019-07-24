using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace zadanie
{
    public partial class FormBuildings : Form
    {
        // Metoda, która pozwala na używanie zdjęcia z argumentu.
        public PictureBox VillagePicture { get; }
        public PictureBox DormitoryPicture { get; }
        public PictureBox StonePitPicture { get; }
        public PictureBox InnPicture { get; }
        public PictureBox LibraryPicture { get; }
        public PictureBox MarketPicture { get; }
        public PictureBox BarrackPicture { get; }
        public PictureBox SawMillPicture { get; }
       

        string filename = Directory.GetParent(Directory.GetParent(Directory.GetParent
                    (System.AppDomain.CurrentDomain.BaseDirectory).FullName).FullName).FullName;

        /// <summary>
        /// Forma z budynkami, które możemy zbudować. Za argument przyjmuje 
        /// zdjęcie z aktualnym stanem wioski.
        /// </summary>
        /// <param name="villageImage"></param>
        public FormBuildings(PictureBox villageImage, PictureBox pictureBoxDormitory, PictureBox pictureBoxSawMill,
                   PictureBox pictureBoxStonePitt, PictureBox pictureBoxInn, PictureBox pictureBoxLibrary,
                   PictureBox pictureBoxMarket, PictureBox pictureBoxBarrack)
        {
            InitializeComponent();
            // Przejęcie informacji zawartej w argumencie do formy.
            VillagePicture = villageImage;
            DormitoryPicture = pictureBoxDormitory;
            InnPicture = pictureBoxInn;
            SawMillPicture = pictureBoxSawMill;
            StonePitPicture = pictureBoxStonePitt;
            LibraryPicture = pictureBoxLibrary;
            MarketPicture = pictureBoxMarket;
            BarrackPicture = pictureBoxBarrack;
        

        }

        /// <summary>
        /// Załadowanie okna z budynkami. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormBuildings_Load(object sender, EventArgs e)
        {
            // Napisy, które powinny znaleźć się na przyciskach zostają na nie naniesione.
            buttonBuildSawmill.Text = FormGame.sawMillBuildOrUpgrade;
            buttonBuildStonePit.Text = FormGame.stonePitBuildOrUpgrade;
            buttonBuildInn.Text = FormGame.innBuildOrUpgrade;
            buttonBuildLibrary.Text = FormGame.libraryBuildOrUpgrade;
            buttonBuildDormitory.Text = FormGame.dormitoryBuildOrUpgrade;
            buttonBuildMarket.Text = FormGame.marketBuildOrUpgrade;
            buttonBuildBarrack.Text = FormGame.barrackBuildOrUpgrade;
        }

        /// <summary>
        /// Przycisk inicjujący akcje związane z budową akademika.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonBuildDormitory_Click(object sender, EventArgs e)
        {   
            // Jeśli ilość zasobów wystarczająca i budynek jeszcze nie zbudowany.
            if (FormGame.gamePause)
            {
                MessageBox.Show("You can't build in pause mode!");
            }
            else if (FormGame.amountOfWood >= 50 & FormGame.amountOfStone >= 10 & FormGame.amountOfGold >= 100 & FormGame.dormitoryBuildOrUpgrade == "Build")
                { 

                if (FormGame.innBuilt == '1' | FormGame.sawMillBuilt == '1' | FormGame.stonePitBuilt == '1')
                {
                    
                    VillagePicture.Tag = VillagePicture.Tag.ToString()[0] + "1" + VillagePicture.Tag.ToString().Substring(2,6);
                    DormitoryPicture.Visible = true;
                    // Zaktualizowanie zasobów.
                    FormGame.amountOfStudents += 10;
                    FormGame.amountOfWood -= 50;
                    FormGame.amountOfStone -= 10;
                    FormGame.amountOfGold -= 100;

                    // Zmiana napisu na przycisku budowy.
                    FormGame.dormitoryBuildOrUpgrade = "Max";
                    buttonBuildDormitory.Text = "Max";
                }

                else
                {
                    System.Windows.Forms.MessageBox.Show("You have to build saw mill, stone-pit or inn before.");
                }

            }

            // Jeśli budynek rozbudowany na maksymalny poziom.
            else if (FormGame.dormitoryBuildOrUpgrade == "Max")
            {
                System.Windows.Forms.MessageBox.Show("You achived maximum level of this building.");
            }

            // Jeśli nie mamy wystarczającej ilości surowców.
            else {
                System.Windows.Forms.MessageBox.Show("You haven't enough resources.");
            }

        }

        /// <summary>
        /// Przycisk inicjujący akcje związane z budową tartaku.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonBuildSawmill_Click(object sender, EventArgs e)
        {
            if (FormGame.gamePause)
            {
                MessageBox.Show("You can't build in pause mode!");
            }
            // Jeśli ilość zasobów wystarczająca i budynek jeszcze nie zbudowany.
           else if (FormGame.amountOfGold >= 100 & FormGame.amountOfStone >= 20 & FormGame.amountOfWood >= 20
                       & FormGame.sawMillBuildOrUpgrade == "Build") {

                if (FormGame.innBuilt == '1')
                {
                    VillagePicture.Image = Image.FromFile(filename + "/Images/allRoads.png");
                }
                else
                {
                    VillagePicture.Image = Image.FromFile(filename + "/Images/sawMillRoad.png");
                }
                VillagePicture.Tag = VillagePicture.Tag.ToString().Substring(0, 2) + "1" + VillagePicture.Tag.ToString().Substring(3, 5);
                SawMillPicture.Visible = true;

                // Zaktualizowanie zasobów i napisu na przycisku.
                FormGame.amountOfWood -= 20;
                FormGame.amountOfStone -= 30;
                FormGame.amountOfGold -= 100;
                FormGame.sawMillBuildOrUpgrade = "Lvl 2";
                buttonBuildSawmill.Text = "Lvl 2";
            }

            // Jeśli ulepszamy budynek koszta zostają odjęte od zasobów, a nazwa przycisku zmieniona.
             else if (FormGame.amountOfGold >= 150 & FormGame.amountOfStone >= 30 & FormGame.amountOfWood >= 50
                & FormGame.sawMillBuildOrUpgrade == "Lvl 2")
            {
                FormGame.amountOfWood -= 50;
                FormGame.amountOfStone -= 30;
                FormGame.amountOfGold -= 150;
                FormGame.sawMillLevel = 2;
                FormGame.sawMillBuildOrUpgrade = "Lvl 3";
                buttonBuildSawmill.Text = "Lvl 3";
            }

             else if (FormGame.amountOfGold >= 150 & FormGame.amountOfStone >= 50 & FormGame.amountOfWood >= 80
                & FormGame.sawMillBuildOrUpgrade == "Lvl 3")
            {
                FormGame.amountOfWood -= 80;
                FormGame.amountOfStone -= 50;
                FormGame.amountOfGold -= 200;
                FormGame.sawMillBuildOrUpgrade = "Max";
                FormGame.sawMillLevel = 3;
                buttonBuildSawmill.Text = "Max";
            }

            else if (FormGame.sawMillBuildOrUpgrade == "Max")
            {
                System.Windows.Forms.MessageBox.Show("You achived maximum level of this building.");
            }

            else
            {
                System.Windows.Forms.MessageBox.Show("You haven't enough resources.");
            }
        }

        /// <summary>
        /// Przycisk inicjujący akcje związane z budową kamieniołomu.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonBuildStonePit_Click(object sender, EventArgs e)
        {
            if (FormGame.gamePause)
            {
                MessageBox.Show("You can't build in pause mode!");
            }
            // Jeśli ilośc zasobów wystarczająca i budynek nie istieje.
            else if (FormGame.amountOfGold >= 100 & FormGame.amountOfStone >= 20 & FormGame.amountOfWood >= 40
                    & FormGame.stonePitBuildOrUpgrade == "Build" )
            {
                VillagePicture.Tag = VillagePicture.Tag.ToString().Substring(0, 3) + "1" + VillagePicture.Tag.ToString().Substring(4, 4);
                StonePitPicture.Visible = true;

                // Zaktulizowanie zasobów i napisu na przycisku.
                FormGame.amountOfWood -= 40;
                FormGame.amountOfStone -= 20;
                FormGame.amountOfGold -= 100;
                FormGame.stonePitBuildOrUpgrade = "Lvl 2" ;
                buttonBuildStonePit.Text = "Lvl 2";
            }

            // Gdy ulepszamy budynek koszta zostają odjęte od zasobów, a nazwa przycisku zmieniona.
            else if (FormGame.amountOfGold >= 150 & FormGame.amountOfStone >= 30 & FormGame.amountOfWood >= 50
                    & FormGame.stonePitBuildOrUpgrade == "Lvl 2")
                {
                    FormGame.amountOfWood -= 50;
                    FormGame.amountOfStone -= 30;
                    FormGame.amountOfGold -= 150;
                    FormGame.stonePitBuildOrUpgrade = "Lvl 3";
                    FormGame.stonePitLevel = 2;
                    buttonBuildStonePit.Text = "Lvl 3";
            }
            else if (FormGame.amountOfGold >= 180 & FormGame.amountOfStone >= 40 & FormGame.amountOfWood >= 80 
                & FormGame.stonePitBuildOrUpgrade == "Lvl 3")
                {
                    FormGame.amountOfWood -= 50;
                    FormGame.amountOfStone -= 30;
                    FormGame.amountOfGold -= 180;
                    FormGame.stonePitBuildOrUpgrade = "Max";
                    FormGame.stonePitLevel = 3;
                    buttonBuildStonePit.Text = "Max";
            }

            // Gdy budynek na maksymalnym poziomie.
            else if (FormGame.stonePitBuildOrUpgrade == "Max")
            {
                System.Windows.Forms.MessageBox.Show("You achived maximum level of this building.");
            }

            // Gdy ilość zasobów niewystarczająca.
            else
            {
                System.Windows.Forms.MessageBox.Show("You haven't enough resources.");
            }
        }

        /// <summary>
        /// Przycisk odpowiadający za akcje związane z budową karczmy.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonBuildInn_Click(object sender, EventArgs e)
        {
            if (FormGame.gamePause)
            {
                MessageBox.Show("You can't build in pause mode!");
            }
            // Jeśli ilość zasobów wystarczająca i budynek nie istnieje.
            else if (FormGame.amountOfGold >= 250 & FormGame.amountOfStone >= 20 & FormGame.amountOfWood >= 50
                        & FormGame.innBuildOrUpgrade == "Build") {

                if (FormGame.sawMillBuilt == '1')
                {
                    VillagePicture.Image = Image.FromFile(filename + "/Images/allRoads.png");
                }
                else
                {
                    VillagePicture.Image = Image.FromFile(filename + "/Images/innRoad.png");
                }
                VillagePicture.Tag = VillagePicture.Tag.ToString().Substring(0, 4) + "1" + VillagePicture.Tag.ToString().Substring(5, 3);
                InnPicture.Visible = true;

                FormGame.amountOfGold -= 250;
                FormGame.amountOfStone -= 20;
                FormGame.amountOfWood -= 50;
                FormGame.innBuildOrUpgrade = "Lvl 2";
                buttonBuildInn.Text = "Lvl 2";
            }

            // Warunku na rozbudowę.
            else if (FormGame.amountOfGold >= 300 & FormGame.amountOfStone >= 30 & FormGame.amountOfWood >= 100
                    & FormGame.innBuildOrUpgrade == "Lvl 2")
            {
                FormGame.amountOfWood -= 100;
                FormGame.amountOfStone -= 30;
                FormGame.amountOfGold -= 300;
                FormGame.innBuildOrUpgrade = "Lvl 3";
                FormGame.innLevel = 2;
                buttonBuildInn.Text = "Lvl 3";
            }
            else if (FormGame.amountOfGold >= 350 & FormGame.amountOfStone >= 40 & FormGame.amountOfWood >= 80
                & FormGame.innBuildOrUpgrade == "Lvl 3")
            {
                FormGame.amountOfWood -= 80;
                FormGame.amountOfStone -= 40;
                FormGame.amountOfGold -= 350;
                FormGame.innBuildOrUpgrade = "Max";
                FormGame.innLevel = 3;
                buttonBuildInn.Text = "Max";
            }
            else if (FormGame.innBuildOrUpgrade == "Max")
            {
                System.Windows.Forms.MessageBox.Show("You achived maximum level of this building.");
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("You haven't enough resources.");
            }
        }

        /// <summary>
        /// Przycisk odpowiadający za akcje związane z budową targowiska.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonBuildMarket_Click(object sender, EventArgs e)
        {
            if (FormGame.gamePause)
            {
                MessageBox.Show("You can't build in pause mode!");
            }
            // Warunek sprawdzający, czy wioska wystaczająco rozwinięta.
            else if (FormGame.dormitoryBuilt == '1' & FormGame.sawMillBuilt == '1' & FormGame.stonePitBuilt == '1'
                    & FormGame.innBuilt == '1' & FormGame.libraryBuilt == '1' & FormGame.marketBuilt == '0' & FormGame.barrackBuilt == '0') {

                // Warunek sprawzający, czy ilość zasobów wystarczająca.
                if (FormGame.amountOfGold >= 250 & FormGame.amountOfStone >= 100 & FormGame.amountOfWood >= 100
                  & FormGame.amountOfNotes >= 4 & FormGame.marketBuildOrUpgrade == "Build")
                {
                    VillagePicture.Tag = VillagePicture.Tag.ToString().Substring(0, 6) + "1" + VillagePicture.Tag.ToString()[7];
                    MarketPicture.Visible = true;

                    // Zaktualizowanie zasobów i napisu na przycisku.
                    FormGame.amountOfGold -= 250;
                    FormGame.amountOfStone -= 100;
                    FormGame.amountOfWood -= 100;
                    FormGame.amountOfNotes -= 4;
                    FormGame.marketBuildOrUpgrade = "Max";
                    buttonBuildMarket.Text = "Max";
                }

                else
                {
                    System.Windows.Forms.MessageBox.Show("You haven't enough resources.");
                }
            }

            else if(FormGame.marketBuildOrUpgrade == "Max")
            {
                System.Windows.Forms.MessageBox.Show("You achived maximum level of this building.");
            }

            // Informacja o budynkach niezbędnych do budowy targowiska.
            else {
                System.Windows.Forms.MessageBox.Show("You have to build sawmill, stone-pit, inn, second dormitory" +
                    "and library before.");
            }

        }

        /// <summary>
        /// Przycisk odpowiadający za akcje związane z budową koszar.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonBuildBarrack_Click(object sender, EventArgs e)
        {
            if (FormGame.gamePause)
            {
                MessageBox.Show("You can't build in pause mode!");
            }
            // Warunek sprawdzający, czy wioska wystarczająco rozwinięta.
            else if (FormGame.dormitoryBuilt == '1' & FormGame.sawMillBuilt == '1' & FormGame.stonePitBuilt == '1'
                    & FormGame.innBuilt == '1' & FormGame.libraryBuilt == '1' & FormGame.marketBuilt == '1' & FormGame.barrackBuilt == '0')
            {
   
                if (FormGame.amountOfGold >= 400 & FormGame.amountOfStone >= 100 & FormGame.amountOfWood >= 100
                   & FormGame.amountOfNotes >= 10 & FormGame.barrackBuildOrUpgrade == "Build")
                {
                    VillagePicture.Tag = VillagePicture.Tag.ToString().Substring(0, 7) + "1";
                    BarrackPicture.Visible = true;

                    // Zaktualizowanie zasobow i napisu na przycisku.
                    FormGame.amountOfGold -= 400;
                    FormGame.amountOfStone -= 100;
                    FormGame.amountOfWood -= 100;
                    FormGame.amountOfNotes -= 10;
                    FormGame.amountOfWarriors += 10;
                    FormGame.barrackBuildOrUpgrade = "Max";
                    buttonBuildBarrack.Text = "Max";
                }

                else if (FormGame.barrackBuildOrUpgrade == "Max")
                {
                    System.Windows.Forms.MessageBox.Show("You achived maximum level of this building.");
                }

                else
                {
                    System.Windows.Forms.MessageBox.Show("You haven't enough resources.");
                }
            }

            // Informacja o budynkach niezbędnych do budowy koszar.
            else
            {
                System.Windows.Forms.MessageBox.Show("You have to build all other buildings before.");
            }
        }

        /// <summary>
        /// Przycisk odpowiadający za akcje związane z budową biblioteki.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonBuildLibrary_Click(object sender, EventArgs e)
        {
            if (FormGame.gamePause)
            {
                MessageBox.Show("You can't build in pause mode!");
            }
            // Jeśli ilość zasobów wystarczająca.
            else if (FormGame.amountOfGold >= 150 & FormGame.amountOfStone >= 50 & FormGame.amountOfWood >= 100
                   & FormGame.libraryBuildOrUpgrade == "Build") { 

                // Jeśli wioska wystarczająco rozwinięta.
                if (FormGame.dormitoryBuilt == '1' & FormGame.sawMillBuilt == '1' & FormGame.stonePitBuilt == '1'
                    & FormGame.innBuilt == '1' & FormGame.libraryBuilt == '0' & FormGame.marketBuilt == '0' & FormGame.barrackBuilt == '0')
                {
                    VillagePicture.Tag = VillagePicture.Tag.ToString().Substring(0, 5) + "1" + VillagePicture.Tag.ToString().Substring(6, 2);
                    LibraryPicture.Visible = true;
                    VillagePicture.Image = Image.FromFile(filename + "/Images/libraryRoad.png");

                    FormGame.amountOfGold -= 150;
                    FormGame.amountOfStone -= 50;
                    FormGame.amountOfWood -= 100;
                    FormGame.libraryBuildOrUpgrade = "Lvl 2";
                    buttonBuildLibrary.Text = "Lvl 2";

                    // Od teraz zdarzenie powodzi nie będzie realizowane po wylosowaiu.
                    System.Windows.Forms.MessageBox.Show("Congratulations! Your people learned how to avoid flood. ");
                }

                // Informacje o budynkach niezbędnych do budowy biblioteki.
                else
                {
                    System.Windows.Forms.MessageBox.Show("You have to finish sawmill, " +
                        "stone-pit, inn and second dormitory before.");
                }
            }

            // Warunki dotyczące ulepszania biblioteki.
            else if (FormGame.amountOfGold >= 200 & FormGame.amountOfStone >= 70 & FormGame.amountOfWood >= 100
                    & FormGame.libraryBuildOrUpgrade == "Lvl 2")
            {
                FormGame.amountOfWood -= 100;
                FormGame.amountOfStone -= 70;
                FormGame.amountOfGold -= 200;
                FormGame.libraryBuildOrUpgrade = "Lvl 3";
                FormGame.libraryLevel = 2;
                buttonBuildLibrary.Text = "Lvl 3";
            }

            else if (FormGame.amountOfGold >= 350 & FormGame.amountOfStone >= 100 & FormGame.amountOfWood >= 120
                & FormGame.libraryBuildOrUpgrade == "Lvl 3")
            {
                FormGame.amountOfWood -= 120;
                FormGame.amountOfStone -= 100;
                FormGame.amountOfGold -= 350;
                FormGame.libraryBuildOrUpgrade = "Max";
                FormGame.libraryLevel = 3;
                buttonBuildLibrary.Text = "Max";
            }

            else if (FormGame.libraryBuildOrUpgrade == "Max")
            {
                System.Windows.Forms.MessageBox.Show("You achived maximum level of this building.");
            }

            else
            {
                System.Windows.Forms.MessageBox.Show("You haven't enough resources.");
            }
        }

        /// <summary>
        /// Przycisk otwierający okno do informacji dotyczącyh akademika.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonDormitoryInfo_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<FormBuildingInfo>().Count() != 0)
            {
                Application.OpenForms.OfType<FormBuildingInfo>().First().Close();
            }
            var oneLevelBuildingDormitory = new FormBuildingInfo("50", "10", "0", "100", "Gives 10 additional studenst. " +
                "Consumption of beer will increase as well as gold incomes.", "dormitory.PNG");
            oneLevelBuildingDormitory.Show();
        }

        /// <summary>
        /// Przycisk otwierający okno do informacji dotyczącyh targowiska.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonMarketInfo_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<FormBuildingInfo>().Count() != 0)
            {
                Application.OpenForms.OfType<FormBuildingInfo>().First().Close();
            }
            var oneLevelBuildingMarket = new FormBuildingInfo("100", "100", "4", "250", "Your gold incomes will increase by 100%.",
                "market.PNG");
            oneLevelBuildingMarket.Show();
        }

        /// <summary>
        /// Przycisk otwierający okno do informacji dotyczącyh koszar.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonBarracksInfo_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<FormBuildingInfo>().Count() != 0)
            {
                Application.OpenForms.OfType<FormBuildingInfo>().First().Close();
            }
            var oneLevelBuildingBarracks = new FormBuildingInfo("100", "100", "10", "400", "Gives 10 additional soldiers." +
                "Threat of invasion decreases by 100% as long as you have warriors.", "barrack.PNG");
            oneLevelBuildingBarracks.Show();
        }

        /// <summary>
        /// Przycisk otwierający okno do informacji dotyczącyh tartaku.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonSawmillInfo_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<FormBuildingInfo>().Count() != 0)
            {
                Application.OpenForms.OfType<FormBuildingInfo>().First().Close();
            }
            if (FormGame.sawMillBuildOrUpgrade == "Build")
            {
                var oneLevelBuildingBarracks = new FormBuildingInfo("20", "20", "0", "100",
                    "Gives 120 wood per day.", "sawmill.PNG");
                oneLevelBuildingBarracks.Show();
            }
            else if (FormGame.sawMillBuildOrUpgrade == "Lvl 2")
            {
                var oneLevelBuildingBarracks = new FormBuildingInfo("50", "30", "0", "150",
                    "Gives 180 wood per day.", "sawmill.PNG");
                oneLevelBuildingBarracks.Show();
            }
            else if (FormGame.sawMillBuildOrUpgrade == "Lvl 3" | FormGame.sawMillBuildOrUpgrade == "Max")
            {
                var oneLevelBuildingBarracks = new FormBuildingInfo("80", "50", "0", "150",
                    "Gives 240 wood per day.", "sawmill.PNG");
                oneLevelBuildingBarracks.Show();
            }
        }

        /// <summary>
        /// Przycisk otwierający okno do informacji dotyczącyh kamieniołomu.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonStonePitInfo_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<FormBuildingInfo>().Count() != 0)
            {
                Application.OpenForms.OfType<FormBuildingInfo>().First().Close();
            }
            if (FormGame.stonePitBuildOrUpgrade == "Build")
            {
                var oneLevelBuildingBarracks = new FormBuildingInfo("40", "20", "0", "100",
                    "Gives 50 stones per day.", "stonepit.PNG");
                oneLevelBuildingBarracks.Show();
            }
            else if (FormGame.stonePitBuildOrUpgrade == "Lvl 2")
            {
                var oneLevelBuildingBarracks = new FormBuildingInfo("50", "30", "0", "150",
                    "Gives 100 stones per day.", "stonepit.PNG");
                oneLevelBuildingBarracks.Show();
            }
            else if (FormGame.stonePitBuildOrUpgrade == "Lvl 3" | FormGame.stonePitBuildOrUpgrade == "Max")
            {
                var oneLevelBuildingBarracks = new FormBuildingInfo("80", "40", "0", "180",
                    "Gives 150 stones per day.", "stonepit.PNG");
                oneLevelBuildingBarracks.Show();
            }

        }

        /// <summary>
        /// Przycisk otwierający okno do informacji dotyczącyh karczmy.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonInnInfo_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<FormBuildingInfo>().Count() != 0)
            {
                Application.OpenForms.OfType<FormBuildingInfo>().First().Close();
            }
            if (FormGame.innBuildOrUpgrade == "Build")
            {
                var oneLevelBuildingBarracks = new FormBuildingInfo("50", "20", "0", "250",
                    "Gives 144 paints of beer per day. Assuming you have 10 students.", "inn.PNG");
                oneLevelBuildingBarracks.Show();
            }
            else if (FormGame.innBuildOrUpgrade == "Lvl 2")
            {
                var oneLevelBuildingBarracks = new FormBuildingInfo("100", "30", "0", "300",
                    "Doubles your beer incomes.", "inn.PNG");
                oneLevelBuildingBarracks.Show();
            }
            else if (FormGame.innBuildOrUpgrade == "Lvl 3" | FormGame.innBuildOrUpgrade == "Max")
            {
                var oneLevelBuildingBarracks = new FormBuildingInfo("80", "40", "0", "350",
                    "Increase your beer incomes by 50%.", "inn.PNG");
                oneLevelBuildingBarracks.Show();
            }
        }

        /// <summary>
        /// Przycisk otwierający okno do informacji dotyczącyh biblioteki.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonLibraryInfo_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<FormBuildingInfo>().Count() != 0)
            {
                Application.OpenForms.OfType<FormBuildingInfo>().First().Close();
            }
            if (FormGame.libraryBuildOrUpgrade == "Build")
            {
                var oneLevelBuildingBarracks = new FormBuildingInfo("100", "50", "0", "150",
                    "Gives 5 notes per day. Your people will learn how to avoid flood.", "library.PNG");
                oneLevelBuildingBarracks.Show();
            }
            else if (FormGame.libraryBuildOrUpgrade == "Lvl 2")
            {
                var oneLevelBuildingBarracks = new FormBuildingInfo("100", "70", "0", "200",
                    "Gives 10 notes per day.", "library.PNG");
                oneLevelBuildingBarracks.Show();
            }
            else if (FormGame.libraryBuildOrUpgrade == "Lvl 3" | FormGame.libraryBuildOrUpgrade == "Max")
            {
                var oneLevelBuildingBarracks = new FormBuildingInfo("120", "100", "0", "350",
                    "Gives 15 notes per day.", "library.PNG");
                oneLevelBuildingBarracks.Show();
            }
        }
    }
}
