using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace zadanie
{
    public partial class FormGame : System.Windows.Forms.Form
    {
        /// <summary>
        /// Forma z głównym interfejsem gry.
        /// </summary>
        public FormGame()
        {
            InitializeComponent();
        }

        // Połączenie z bazą danych.
        readonly string connectionString = @"Data Source=LAPTOP-HPD9G79T; database=MedievalStudents; Trusted_Connection=yes";

        // Pola odpowiadjące za zegar.
        int dayCounter = 1;
        int hourCounter = 12;
        int minCounter = 0;

        // Pola odpowiadające za ilość surowców oraz ludzi.
        public static int amountOfBeer = 100;
        public static int amountOfWood = 250;
        public static int amountOfStone = 200;
        public static int amountOfNotes = 8;
        public static int amountOfGold = 1000;
        public static int amountOfStudents = 10;
        public static int amountOfWarriors = 0;

        // Pola zawierające informację, czy budynek został zbudowany.
        public static char dormitoryBuilt = '0';
        public static char sawMillBuilt = '0';
        public static char stonePitBuilt = '0';
        public static char innBuilt = '0';
        public static char libraryBuilt = '0';
        public static char marketBuilt = '0';
        public static char barrackBuilt = '0';

        // Pola zawierające informację o poziomie budynku.
        public static int sawMillLevel = 1;
        public static int stonePitLevel = 1;
        public static int innLevel = 1;
        public static int libraryLevel = 1;

        // Pola z tekstem na przycisk przy budynku.
        public static string innBuildOrUpgrade = "Build";
        public static string stonePitBuildOrUpgrade = "Build";
        public static string sawMillBuildOrUpgrade = "Build";
        public static string libraryBuildOrUpgrade = "Build";
        public static string dormitoryBuildOrUpgrade = "Build";
        public static string marketBuildOrUpgrade = "Build";
        public static string barrackBuildOrUpgrade = "Build";

        // Boolean odpowiadająca za pauzę w grze.
        public static bool gamePause = false;

        // Lista ze zdarzeniami losowymi.
        public static List<string> listOfEvents = new List<string>() { "attack", "flood", "death", "none", "none" };

        // Zainicjowanie pól potrzebnych do działania zdarzeń losowych.
        string valueFromList;
        string imagePath;
        static Random rnd = new Random();

        // Stworzenie generatorów liczb losowych
        public static Random randomNameGenerator = new Random();
        public static Random randomKnowledgeGenerator = new Random();
        public static Random randomLifeEnergyGenerator = new Random();

        // Pola z postaciami
        static Student studentEnemyOne = new Student(1);
        static Student studentEnemyTwo = new Student(2);
        static Student studentEnemyThree = new Student(3);
        static Student studentEnemyFour = new Student(4);
        static Student studentEnemyFive = new Student(5);
        static Student studentEnemySix = new Student(6);
        static Student studentEnemySeven = new Student(7);
        static Student studentEnemyEight = new Student(8);
        static Student studentEnemyNine = new Student(9);
        static Student studentEnemyTen = new Student(10);
        static StudentsForeman studentEnemyForeman = new StudentsForeman(1);

        // Ścieżka do głównego folderu.
        string filename = Directory.GetParent(Directory.GetParent(Directory.GetParent
                    (System.AppDomain.CurrentDomain.BaseDirectory).FullName).FullName).FullName;

        string currentDirectory = Directory.GetParent(System.AppDomain.CurrentDomain.BaseDirectory).FullName;

        // Lista ze studentami.
        public static List<Person> listOfStudents;

        // Postać gracza.
        public static Person professorCharacter;

        // bool przechowujący informację o stanie walki.
        public static bool battleState = false;

        // zmienne odpowiedzialne za punkty.
        public static int score = 0;
        public static int dayBonus = 100000;

        // Zmienna sprwdzająca, czy tło zostało przesunięte.
        private bool moved = false;

 
        /// <summary>
        /// Metoda zatrzymuje wszystkie timery.
        /// </summary>
        private void StopAllTimers()
        {
            timerMinute.Stop();
            timerScore.Stop();
            timerConsumptionOfBeer.Stop();
            timerGold.Stop();
            timerBeer.Stop();
            timerWood.Stop();
            timerNotes.Stop();
            timerStone.Stop();
            timerEvents.Stop();

        }

        /// <summary>
        /// Nadpisanie metody odpowiedzialnej za wyświetleni FormGame
        /// od razu po włączeniu aplikacji.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnLoad(EventArgs e)
        {
            Visible = false; // Hide form window.
            ShowInTaskbar = false; // Remove from taskbar.
            Opacity = 0;

            base.OnLoad(e);
        }

        /// <summary>
        /// Metoda odpowiedzialna za zapisywanie punktacji w bazie danych.
        /// </summary>
        private void SaveScore()
        {

            // Wpisujemy nowy wynik do bazy.
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            SqlCommand comm = new SqlCommand("SELECT COUNT(*) FROM AvailablePoints WHERE Nick = '" + professorCharacter.name + "'", conn);
            Int32 count = (Int32)comm.ExecuteScalar();

            if (count == 0)
            {
                string query = @"INSERT INTO AvailablePoints(Points, Nick) VALUES(@Points, @Nick)";
                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add("@Points", SqlDbType.NVarChar).Value = score;
                    command.Parameters.Add("@Nick", SqlDbType.NVarChar).Value = professorCharacter.name;
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();

                }
            }
            else
            {
                string query2 = @"UPDATE AvailablePoints SET Points = Points + " + score.ToString() + " WHERE Nick = '" + professorCharacter.name + "'";
                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand(query2, connection))
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();

                }
            }

            string query3 = @"INSERT INTO Score(POINTS, PlayerID) VALUES(@SCORE, (SELECT ID FROM AvailablePoints WHERE Nick ='" + professorCharacter.name + "'))";
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query3, connection))
            {
                command.Parameters.Add("@Score", SqlDbType.NVarChar).Value = score;
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();

            }

            string query4 = @"INSERT INTO FavouriteCharacter(FavourtieClass, PlayerID) VALUES(@FavourtieClass,
            (SELECT ID FROM AvailablePoints WHERE Nick ='" + professorCharacter.name + "'))";
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query4, connection))
            {
                command.Parameters.Add("@FavourtieClass", SqlDbType.NVarChar).Value = professorCharacter.status;
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();

            }
           
        }

        

        /// <summary>
        /// Metoda wczytująca muzykę w tle.
        /// </summary>
        public void PlayBackground()
        {
            SoundPlayer player = new SoundPlayer
            {
                SoundLocation = filename + "/Sounds/field.wav"
            };
            player.PlayLooping();
        }

        /// <summary>
        /// Metoda włączająca wszystkie zatrzymane timery.
        /// </summary>
        private void StartAllTimers()
        {
            timerMinute.Start();
            timerScore.Start();
            timerEvents.Start();
            timerConsumptionOfBeer.Start();
            timerGold.Start();
            if ( sawMillBuilt =='1')
            {
                timerWood.Start();
            }
            if (innBuilt == '1')
            {
                timerBeer.Start();
            }
            if (stonePitBuilt == '1')
            {
                timerStone.Start();
            }
            if (libraryBuilt == '1')
            {
                timerNotes.Start();
            }
        }

        /// <summary>
        /// Metoda odpowiedzialna za wyświetlenie forma z wiadomością.
        /// </summary>
        /// <param name="messageText"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="time"></param>
        private void ShowMessage(string messageText, int x = 380, int y = 156, int time = 2)
        {
            var message = new FormMessageInBattle
            {
                Width = x,
                Height = y
            };
            // ustawiamy rozmiary forma.
            message.labelMessageInBattle.Width = x - 20;
            message.labelMessageInBattle.Height = y - 20;

            // Ustawiamy pozycję forma.
            message.Left = this.Left + (this.Right - this.Left - message.Width) / 2;
            message.Top = this.Top - (this.Top - this.Bottom) / 2 - message.Height;

            // Wczytujemy tekst z wiadomością.
            message.labelMessageInBattle.Text = messageText;

            // Ustawiamy czas, po którym form zostanie zamknięty.
            Task.Delay(TimeSpan.FromSeconds(time)).ContinueWith((t) => message.Close(),
                TaskScheduler.FromCurrentSynchronizationContext());

            // Otwieramy forma z focusem.
            message.ShowDialog();
        }

        /// <summary>
        /// Przycisk wyłączający grę.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonClose_Click(object sender, EventArgs e)
        {
            SaveScore();
            Close();
        }

        /// <summary>
        /// Ładowanie głównego interfejsu gry.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormGame_Load(object sender, EventArgs e)
        {
         
            PlayBackground();
            // Wczytanie wartości z liczbą studentąw do textBoxu.
            textBoxNumberOfStudents.Text = amountOfStudents.ToString();

            // Ustawienie textBoxów jako "tylko do odczytu.
            textBoxNumberOfStudents.ReadOnly = true;
            textBoxNumberOfWarriors.ReadOnly = true;
            textBoxDayCounter.ReadOnly = true;
            textBoxHourCounter.ReadOnly = true;

            FormStartGame startGame = new FormStartGame();
            StopAllTimers();
            startGame.Show();
            timerCheckForCharacterSelectEnd.Start();
            this.Hide();
        }

        /// <summary>
        /// Przycisk wczytujący okno z zasobami.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonResources_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<FormResources>().Count() == 0)
            {
                // Zainicjowanie okna z zasobami.
                var formWithResources = new FormResources();
                formWithResources.Show();
                formWithResources.SetDesktopLocation(this.Location.X - formWithResources.Size.Width, this.Location.Y);
            }
            else
            {
                Application.OpenForms.OfType<FormResources>().First().BringToFront();
            }
           
        }

        /// <summary>
        /// Przycisk otwierający okno z budynkami.
        /// Można w nim wybrać budynki, które chemy zbudować oraz
        /// sprawdzić informacje dotyczące tych budynków.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonBuildings_Click(object sender, EventArgs e)
        {

            if (Application.OpenForms.OfType<FormBuildings>().Count() == 0)
            {
                // Otworzenie okna z budynkami, które jako agrument 
                // pryjmuje  pole ze zdjęciem wioski.
                var formWithBuildings = new FormBuildings(pictureVillageImage, pictureBoxDormitory, pictureBoxSawMill, 
                    pictureBoxStonePitt, pictureBoxInn, pictureBoxLibrary, pictureBoxMarket, pictureBoxBarrack);

                // Wyświetlenie okna. 
                formWithBuildings.Show();
                formWithBuildings.SetDesktopLocation(this.Location.X + this.Size.Width, this.Location.Y);
            }
            else
            {
                Application.OpenForms.OfType<FormBuildings>().First().BringToFront();
            }
        }

        /// <summary>
        /// Timer mierzący czas w grze. Odpowaiada także za sprawdzanie stanu gry.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TimerMinute_Tick(object sender, EventArgs e)
        {
            // Dodawanie minut
            minCounter++;

            // Gdy skończy się piwo, gra zostaje przerwana.
            if (amountOfBeer <= 0)
            {
                StopAllTimers();
                MessageBox.Show("You are out of beer. Game over!");
                SaveScore();
                Application.Restart();

            }

            // Gdy wszyscy studenci umrą, gra zostaje przerwana.
            if (amountOfStudents <= 0)
            {
                StopAllTimers();
                MessageBox.Show("All your students died. Game over!");
                SaveScore();
                Application.Restart();
            }

            // Gdy wszystkie budynki zostaną rozbudowane na maxa, gra zostaje przerwana.
            if ( dormitoryBuildOrUpgrade == "Max"& sawMillBuildOrUpgrade == "Max" &
            stonePitBuildOrUpgrade == "Max" & innBuildOrUpgrade == "Max" & libraryBuildOrUpgrade == "Max" &
            marketBuildOrUpgrade == "Max" & barrackBuildOrUpgrade == "Max")
            {
                StopAllTimers();
                score += dayBonus;
                MessageBox.Show("Congratulations! You built medieval campus. Score :" + score.ToString());
                SaveScore();
                Application.Restart();
            }
            // Jesli stan wioski nie jest taki jak na poczatku
            // wprowadz zmiany do zmiennych z informacja o stanie budynkow.
            if (pictureVillageImage.Tag.ToString() != "10000000")
            {
                dormitoryBuilt = pictureVillageImage.Tag.ToString()[1];
                sawMillBuilt = pictureVillageImage.Tag.ToString()[2];
                stonePitBuilt = pictureVillageImage.Tag.ToString()[3];
                innBuilt = pictureVillageImage.Tag.ToString()[4];
                libraryBuilt = pictureVillageImage.Tag.ToString()[5];
                marketBuilt = pictureVillageImage.Tag.ToString()[6];
                barrackBuilt = pictureVillageImage.Tag.ToString()[7];
            }

            // Jeśli tartak został wybudowany.
            if (sawMillBuilt == '1')
            {
                timerWood.Start();
            }

            // Jeśli kamieniołom zbudowany.
            if (stonePitBuilt == '1')
            {
                // Zacznij naliczać kamień.
                timerStone.Start();
            }

            // Jeśli karczma zbudowana
            if (innBuilt == '1')
            {
                // Zacznij naliczać piwo.
                timerBeer.Start();
            }

            // Jeśli biblioteka zbudowana.
            if (libraryBuilt == '1')
            {
                // Zacznij naliczać notatki.
                timerNotes.Start();
            }

            // Jeśli akademik zbudowany.
            if (dormitoryBuilt == '1')
            {
                // Zaktualizuj textBox z liczbą studentów.
                textBoxNumberOfStudents.Text = amountOfStudents.ToString();
            }

            // Jeśli koszary istnieją.
            if (barrackBuilt == '1')
            {
                // Zaktualizuj textBox z liczbą żołnierzy.
                textBoxNumberOfWarriors.Text = amountOfWarriors.ToString();
            }

            // Jeśli tło jeszcze nie przesunięte, a jakikolwiek budynek 
            // w wiosce wybudowany.
            if(pictureVillageImage.Tag.ToString() != "10000000" & !moved)
            {
                moved = true;
                
                // Przesuń form z avatarem w prawym dolnym rogu.
                pictureBoxProfessorCharacter.Location = new Point(pictureBoxProfessorCharacter.Location.X + 5,
                    pictureBoxProfessorCharacter.Location.Y);
            }
            // Jeśli wybije 10:01 rozpocznij walkę.
            if (minCounter == 1 & hourCounter == 10)
            {
                StopAllTimers();
                battleState = true;
                timerCheckForBattleEnd.Start();
                FormBattlefield lectureRoomBattlefield = new FormBattlefield
                {
                    BackgroundImage = Image.FromFile(filename +
                    "/Images/Battle/battlefield" + rnd.Next(1, 10).ToString() + ".png")
                };
                lectureRoomBattlefield.ShowDialog();
            }
            // Jeśli minutnik przekroczy 59 minut zresetuj godzinę.
            if (minCounter > 59)
            {
                minCounter = 0;

                // Jeśli godzina jest ponizej 23 dodaj godzinę.
                if (hourCounter < 23)
                {
                    hourCounter++;
                }

                // Zresetuj godzinę i dodaj dzień po 23.
                else
                {
                    hourCounter = 0;
                    dayCounter++;
                    dayBonus = (int) Math.Floor(dayBonus * 0.9);

                    // Zmień tekst z dniem gry.
                    textBoxDayCounter.Text = dayCounter.ToString();

                    // Jeśli pod koniec dnia poziom karczmy przekracza łączną ilość akademików
                    // i baraków oznacza  to, że studenci cały dzień pracowali pijani, przez co 
                    // szybkość narastania zasobów maleje o połowę.
                    if (innLevel > 1 + dormitoryBuilt + barrackBuilt)
                    {
                        timerBeer.Interval /= 2;
                        timerGold.Interval /= 2;
                        timerNotes.Interval /= 2;
                        timerWood.Interval /= 2;
                        timerStone.Interval /= 2;
                        StopAllTimers();
                        System.Windows.Forms.MessageBox.Show("Your students were drunk all day. Your production fell by 50%.");
                        StartAllTimers();
                    }
                }
                    
            }

            // Warunki odpowiadające za wyświetlanie godziny.
            if (minCounter < 10)
            {
                if (hourCounter < 10)
                {
                    textBoxHourCounter.Text = "0" + hourCounter.ToString() + ":0" + minCounter.ToString();
                }
                else
                {
                    textBoxHourCounter.Text = hourCounter.ToString() + ":0" + minCounter.ToString();
                }
            }
            else{
                if (hourCounter < 10)
                {
                    textBoxHourCounter.Text = "0" + hourCounter.ToString() + ":" + minCounter.ToString();
                }
                else
                {
                    textBoxHourCounter.Text = hourCounter.ToString() + ":" + minCounter.ToString();
                }
            }
        }

        /// <summary>
        /// Timer naliczający złoto.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TimerGold_Tick(object sender, EventArgs e)
        {
            amountOfGold += Math.Abs(amountOfStudents - amountOfWarriors)*2/5 + 1;
        }

        /// <summary>
        /// Timer naliczający piwo.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TimerBeer_Tick(object sender, EventArgs e)
        {
            amountOfBeer += innLevel*(amountOfStudents)/10;
        }

        /// <summary>
        /// Timer naliczający drewno.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TimerWood_Tick(object sender, EventArgs e)
        {
            amountOfWood += sawMillLevel + 1;
        }

        /// <summary>
        /// Timer naliczający kamień.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TimerStone_Tick(object sender, EventArgs e)
        {
            amountOfStone += stonePitLevel;
        }

        /// <summary>
        /// Timer naliczający notatki.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TimerNotes_Tick(object sender, EventArgs e)
        {
            amountOfNotes += libraryLevel;
        }

        /// <summary>
        /// Timer naliczający konsumpcję piwa.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TimerConsumptionOfBeer_Tick(object sender, EventArgs e)
        {
            amountOfBeer -= innLevel * (amountOfStudents + amountOfWarriors + 2)/10;
        }

        /// <summary>
        /// Przycisk pauzy. Zatrzymuje wszystkie włączone timery.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonPause_Click(object sender, EventArgs e)
        { if (gamePause == false)
            {
                StopAllTimers();
                buttonPause.Text = "Start";
                gamePause = true;
            }

            // Gdy chcemy wrócić do gry timery zostają przywrócone do poprzedniego stanu.
            else if (gamePause == true)
            {
                StartAllTimers();
                buttonPause.Text = "Pause";
                gamePause = false;
            }
        }

        /// <summary>
        /// Timer odliczający czas do losowania zdarzeń jakie mogą zajść.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TimerEvents_Tick(object sender, EventArgs e)
        {
            // Losowanie stringa z nazwą zdarzenia.
            int r = rnd.Next(listOfEvents.Count);
            valueFromList = (string)listOfEvents[r];

            // Jeśli wioska została zaatakowana.
            if(valueFromList == "attack")

            {   // W wypadku braku zolnierzy zabierz 25% zasobow.
                if (amountOfWarriors == 0)
                {
                    amountOfBeer = (int)Math.Floor(amountOfBeer * 0.75);
                    amountOfGold = (int)Math.Floor(amountOfGold * 0.75);
                    amountOfWood = (int)Math.Floor(amountOfWood * 0.75);
                    amountOfNotes = (int)Math.Floor(amountOfNotes * 0.75);
                    amountOfStone = (int)Math.Floor(amountOfStone * 0.75);
                    StopAllTimers();
                    System.Windows.Forms.MessageBox.Show("Enemy took 25 % of your resources.");
                    StartAllTimers();
                }

                // W wypadku posiadania baraków żołnierze zabierają łup od pokonanego wroga.
                else
                {
                    StopAllTimers();
                    System.Windows.Forms.MessageBox.Show("Brave warriors protected you from enemy. " +
                        "You earned extra resources. Unfortunatelly one of warriors died.");
                    StartAllTimers();

                    amountOfBeer += 100;
                    amountOfGold += 100;
                    amountOfWood += 100;
                    amountOfNotes += 100;
                    amountOfStone += 100;
                    // Śmierć żołnierza.
                    amountOfWarriors -= 1;
                    textBoxNumberOfWarriors.Text = amountOfWarriors.ToString();
                }
            }

            // Jeśli powódź i mieszkańcy nie posiadają biblioteki.
            else if(valueFromList == "flood"& libraryBuilt == '0')
            {   
                // Gracz traci 30% zasobów.
                amountOfBeer = (int) Math.Floor(amountOfBeer* 0.7);
                amountOfGold = (int) Math.Floor(amountOfGold * 0.7);
                amountOfWood = (int) Math.Floor(amountOfWood * 0.7);
                amountOfStone = (int) Math.Floor(amountOfStone * 0.7);

                // Jeśli wioska składa się tylko z akademika.
                if(pictureVillageImage.Tag.ToString() == "10000000")
                {
                    StopAllTimers();
                    System.Windows.Forms.MessageBox.Show("Flood took 30% of your resources.");
                    StartAllTimers();
                }

                // Jeśli istnieje drugi akademik to zostaje zniszczony.
                else if ( dormitoryBuilt == '1')
                {
                    dormitoryBuilt = '0';
                    dormitoryBuildOrUpgrade = "Build";
                    Application.OpenForms.OfType<FormBuildings>().First().buttonBuildDormitory.Text = dormitoryBuildOrUpgrade;
                    amountOfStudents -= 10;
                    textBoxNumberOfStudents.Text = amountOfStudents.ToString();

                    imagePath = "1" + dormitoryBuilt.ToString() + sawMillBuilt.ToString() + stonePitBuilt.ToString() +
                        innBuilt.ToString() + libraryBuilt.ToString() + marketBuilt.ToString()
                        + barrackBuilt.ToString();
                    pictureBoxDormitory.Visible = false;
                    pictureVillageImage.Tag = imagePath;

                    StopAllTimers();
                    System.Windows.Forms.MessageBox.Show("Flood took 30% of your resources and one of the buildings.");
                    StartAllTimers();
                }

                // Jeśli istnieje tartak to zostaje zniszczony.
                else if (sawMillBuilt == '1')
                {
                    sawMillBuilt = '0';
                    sawMillBuildOrUpgrade = "Build";
                    Application.OpenForms.OfType<FormBuildings>().First().buttonBuildSawmill.Text = sawMillBuildOrUpgrade;
                    timerWood.Stop();
                    sawMillLevel = 1;
          
                    imagePath = "1" + dormitoryBuilt.ToString() + sawMillBuilt.ToString() + stonePitBuilt.ToString() +
                        innBuilt.ToString() + libraryBuilt.ToString() + marketBuilt.ToString()
                        + barrackBuilt.ToString();
                    pictureBoxSawMill.Visible = false;
                    pictureVillageImage.Tag = imagePath;

                    StopAllTimers();
                    System.Windows.Forms.MessageBox.Show("Flood took 30% of your resources and one of the buildings.");
                    StartAllTimers();
                }

                // Jeśli istnieje kamieniołom to zostaje zniszczony.
                else if (stonePitBuilt == '1')
                {
                    stonePitBuilt = '0';
                    stonePitBuildOrUpgrade = "Build";
                    Application.OpenForms.OfType<FormBuildings>().First().buttonBuildSawmill.Text = stonePitBuildOrUpgrade;
                    timerStone.Stop();
                    stonePitLevel = 1;

                    imagePath = "1" + dormitoryBuilt.ToString() + sawMillBuilt.ToString() + stonePitBuilt.ToString() +
                        innBuilt.ToString() + libraryBuilt.ToString() + marketBuilt.ToString()
                        + barrackBuilt.ToString();
                    pictureBoxStonePitt.Visible = false;
                    pictureVillageImage.Tag = imagePath;

                    StopAllTimers();
                    System.Windows.Forms.MessageBox.Show("Flood took 30% of your resources and one of the buildings.");
                    StartAllTimers();
                }

                // Jeśli istnieje karczma to zostaje zniszczona.
                else if (innBuilt == '1')
                {
                    innBuilt = '0';
                    innBuildOrUpgrade = "Build";
                    Application.OpenForms.OfType<FormBuildings>().First().buttonBuildInn.Text = innBuildOrUpgrade;
                    timerBeer.Stop();
                    innLevel = 1;

                    imagePath = "1" + dormitoryBuilt.ToString() + sawMillBuilt.ToString() + stonePitBuilt.ToString() +
                        innBuilt.ToString() + libraryBuilt.ToString() + marketBuilt.ToString()
                        + barrackBuilt.ToString();
                    pictureBoxInn.Visible = false;
                    pictureVillageImage.Tag = imagePath;

                    StopAllTimers();
                    System.Windows.Forms.MessageBox.Show("Flood took 30% of your resources and one of the buildings.");
                    StartAllTimers();
                }
            }

            // Jeśli wylosowano śmierć odejmujemy jednego studenta z populacji.
            else if (valueFromList == "death")
            {
                amountOfStudents -= 1;
                StopAllTimers();
                System.Windows.Forms.MessageBox.Show("One of students died.");
                StartAllTimers();
                textBoxNumberOfStudents.Text = amountOfStudents.ToString();
            }
        }

        /// <summary>
        /// Timer sprawdzający czy tryb walki został zakończony.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TimerCheckForBattleEnd_Tick(object sender, EventArgs e)
        {
            // Jeśli form z walką oraz formy z zadaniem specjalnym dla profesora
            // wyłączone oraz tryb walki = false.
            if (Application.OpenForms.OfType<FormBattlefield>().Count() == 0 & battleState == false &
                Application.OpenForms.OfType<FormSpecialAbilityAnalyst>().Count() == 0 & 
                Application.OpenForms.OfType<FormSpecialAbilityAlgebraist>().Count() == 0 &
                Application.OpenForms.OfType<FormSpecialAbilityProgrammer>().Count() == 0)
            {
                // Zmiana godziny na 15
                hourCounter = 15;

                // Włączamy wszystkie zatrzymane timery.
                StartAllTimers();

                // Zatrzymujemy timer sprawdzający koniec bitwy
                timerCheckForBattleEnd.Stop();

                // Włączamy muzykę w tle
                PlayBackground();
            }

            // Jeśli form z walką wyłączony, a tryb walki = true, to gracz
            // wyłączył form walki w trakcie jej trwania.
            else if (Application.OpenForms.OfType<FormBattlefield>().Count() == 0 & battleState == true)
            {
                timerCheckForBattleEnd.Stop();

                // Ucieczka z pola bitwy = przegrana gra.
                ShowMessage("You ran away like a coward. " +
                  "Students are in charge of the village now ", 480, 240, 5);

                // Gra zostaje zrestartowana.
                Application.Restart();
            }
        }

        /// <summary>
        /// Timer sprawdzający czy postać została wybrana.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TimerCheckForCharacterSelectEnd_Tick(object sender, EventArgs e)
        {
            // Jeśli form z menu głównym i wyborem postaci zamknięte, a profesor dalej nie wybrany
            // gracz zostaje cofnięty do menu start.
            if (Application.OpenForms.OfType<FormSelectCharacter>().Count() == 0 & professorCharacter == null
                &  Application.OpenForms.OfType<FormStartGame>().Count() == 0)
            {
                timerCheckForCharacterSelectEnd.Stop();
                MessageBox.Show("Game will be restarted.");
                Application.Restart();
            }

            // Jeśli profesor został wybrany.
            else if (Application.OpenForms.OfType<FormSelectCharacter>().Count() == 0 
                & Application.OpenForms.OfType<FormStartGame>().Count() == 0)
            {
                try
                {
                    // Usawiamy avatara profesora w prawym dolnym rogu ekranu.
                    pictureBoxProfessorCharacter.Image = Image.FromFile(professorCharacter.imageOfCharacter);
                    // Timery, które powinny naliczać się od początku gry.
                    timerMinute.Start();
                    timerGold.Start();
                    timerEvents.Start();
                    timerScore.Start();
                    timerConsumptionOfBeer.Start();
                    timerCheckForCharacterSelectEnd.Stop();
                    
                    // Zmieniamy stan forma z ekranem gry na widzialny.
                    Visible = true;
                    ShowInTaskbar = true;
                    Opacity = 100;
                    this.Show();

                    // Tworzymy liste postaci.
                    listOfStudents = new List<Person>() { professorCharacter, studentEnemyOne, studentEnemyTwo, studentEnemyThree,
                    studentEnemyFour, studentEnemyFive, studentEnemySix, studentEnemySeven, studentEnemyEight,
                    studentEnemyNine, studentEnemyTen, studentEnemyForeman};
                }
                // Poniższy wyjątek oznaczy, że został wybrany profesor humanista.
                catch(ArgumentNullException)
                {
                    timerCheckForCharacterSelectEnd.Stop();
                    this.Hide();

                    // Tworzymy postać profesora humanisty.
                    ProfessorHumanist notGoodChoice = new ProfessorHumanist();

                    // Wywołujemy metodę jego śmierci.
                    notGoodChoice.Death();
                }
                
            }
        }

        /// <summary>
        /// Timer naliczający punkty.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TimerScore_Tick(object sender, EventArgs e)
        {
            score++;
            textBoxScore.Text = score.ToString();
        }
    }
}
