using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace zadanie
{
    /// <summary>
    /// Form odpowiadający za walkę.
    /// Codziennie o 10:00 profesor rozpoczyna wykłady 
    /// ze studentami. Walka trwa do 15:00.
    /// </summary>
    public partial class FormBattlefield : Form
    {

        public FormBattlefield()
        {
            InitializeComponent();
        }
        // Stworzenie generatora liczb losowych.
        static Random rnd = new Random();
        // Czas na ruch profesora.
        int secondsLeft = 30;
        // Czas pomiędzy atakami przeciwnika.
        int secondBetweenEnemiesAttacks = 3;

        // Ścieżka do folderu, po dwóch cofnięciach z Debug.
        string filename = Directory.GetParent(Directory.GetParent(Directory.GetParent
                    (System.AppDomain.CurrentDomain.BaseDirectory).FullName).FullName).FullName;

        //  Deklaracje zmiennej, która będzie przechowywać postać aktualnie wykonującą ruch.
        Person currentPerson;
        // Deklaracja zmiennej, która będzie przechowywać postać profesora.
        Professor professor;
    
        // Indeks osoby aktualnie wykonującej ruch
        int currentPersonIndex = 0;

        // Lista osób biorących udział w walce.
        List<Person> fightingTeam = new List<Person>(6)
            {
                FormGame.listOfStudents[0]
            };

        // Lista z numerami osób biorących udział w walce. 
        // Po pokonaniu numer zmienia się na 0.
        List<int> listForInfo = new List<int>(6) { 1, 2, 3, 4, 5, 6 };

        // Liczba pokonanych przeciwników. 
        private int numberOfDefeated = 0;

        // Zainicjowanie czasu potrzebnego do zakończenia wiadomości
        private int messageEndValue = 0;

        // bool sprawdzającym czy profesor wykonał atak w tej turze.
        bool? attackDone = null;

        // bool sprawdzające, czy wiadomość została pokazana.
        bool messageShown = false;

        // Zmienna będzie przechowywać wartość ataku zadanego przez aktualnie atakującą postać.
        int attack;

        // bool sprawdający, czy już możemy atakować.
        bool allowAttack = false;
   
        /// <summary>
        /// Metoda przywracająca wszystkim walczącym postaciom 
        /// ich parametry początkowe. Używana pod koniec walki,
        /// aby postaci mogły wziąć udział w walce następnego dnia.
        /// </summary>
        private void RestorePersonFields()
        {
            // Cofamy profesora do ataków początkowych.
            professor.currentAttackName = professor.attackName1;
            professor.itemOneChecked = false;
            professor.itemTwoChecked = false;
            professor.spell = professor.basicSpell;

            // Zwracamy maksymalne zdrowie każdej postaci.
            foreach(Person fighter in fightingTeam)
            {
                fighter.lifeEnergy = fighter.maximumLifeEnergy;
            }
            
        }
        /// <summary>
        /// Metoda odpowiadająca za wybór odpowiedniej broni.
        /// Sprawdza ile osób profesor pokonał i  zmienia
        /// spell (ścieżka do gifa z atakiem) oraz nazwę broni,
        /// co ma wpływ na siłę ataków.
        /// </summary>
        private void ChooseValidWeapon()
        {   
            // Jeśli profesor pokonał jednego przeciwnika i jeszcze nie ma drugiej broni.
            if (professor.itemOneChecked == false & numberOfDefeated == 1)
            {
                professor.itemOneChecked = true;
                professor.spell = professor.firstSpellPath;
                professor.currentAttackName = professor.attackName2;
            }
            // Jeśli profesor pokonał trzech przeciwników i jeszcze nie ma trzeciej broni.
            else if (professor.itemTwoChecked == false & numberOfDefeated == 3)
            {
                professor.itemTwoChecked = true;
                professor.spell = professor.secondSpellPath;
                professor.currentAttackName = professor.attackName3;
            }
        }
        /// <summary>
        /// Metoda zamykająca otwarte formy z informacjami o postaciach.
        /// </summary>
        private void CloseInfoForms()
        {
            // Jeśli form z informacją o profesorze otwarty.
            if(Application.OpenForms.OfType<FormProfessorInfo>().Count() != 0)
                {
                    Application.OpenForms.OfType<FormProfessorInfo>().First().Close();
                }

            // Jeśli form z informacją o studencie otwarty.
            if (Application.OpenForms.OfType<FormStudentInfo>().Count() != 0)
                {
                    Application.OpenForms.OfType<FormStudentInfo>().First().Close();
                }
        }

        /// <summary>
        ///  Metoda odpowiadająca za atak profesora.
        /// </summary>
        /// <param name="e"></param>
        /// <param name="number"></param>
        /// <param name="progressBarStudent"></param>
        /// <param name="pictureBoxStudentBattle"></param>
        private void ProfessorAttack(MouseEventArgs e, int number, ProgressBar progressBarStudent, PictureBox pictureBoxStudentBattle)
        {
            // Jeśli lewy klik --> atak.
            if (e.Button == MouseButtons.Left)
            {
                // Jeśli ruch profesora oraz atak nie wykonany.
                if (currentPerson == fightingTeam[0] & listForInfo[number] != 0 & attackDone == false & allowAttack)
                {
                    try
                    {
                        // Jeśli profesor nie zdobył żadnego itemu.
                        if (professor.itemOneChecked == false)
                        {
                            attack = professor.Teach();

                        }

                        // Jeśli profesor zdobył pierwszy item, ale nie ma drugiego.
                        else if (professor.itemTwoChecked == false)
                        {
                            attack = professor.Teach(2);

                            // Ustaw atak na drugi.
                            professor.spell = professor.firstSpellPath;
                        }

                        // Jeśli profesor zdobył oba itemy.
                        else
                        {
                            attack = professor.Teach(2, 20);

                            // Ustaw atak na trzeci.
                            professor.spell = professor.secondSpellPath;
                        }

                        // Odejmij życie przeciwnikowi
                        fightingTeam[number].lifeEnergy -= attack;

                        // Zmień stan paska życia.
                        progressBarStudent.Value -= attack * 100 / fightingTeam[number].maximumLifeEnergy;
                    }

                    // Jeśli przekroczyliśmy przedział to życie przeciwnika spadło poniżej zera.
                    catch (System.ArgumentOutOfRangeException)
                    {
                        // Schowaj pasek życia.
                        progressBarStudent.Hide();

                        // Ustaw nowy obrazek studenta na pokonanego studenta.
                        if (fightingTeam[number].sex == "Man")
                            pictureBoxStudentBattle.Image = Image.FromFile(professor.filename + "/Images/Battle/defeatedManStudent.png");
                        else
                        {
                            pictureBoxStudentBattle.Image = Image.FromFile(professor.filename + "/Images/Battle/defeatedWomanStudent.png");
                        }

                        // Zmiana statusu przeciwnika na pokonany.
                        listForInfo[number] = 0;

                        // Zwiększamy liczbę pokonanych.
                        numberOfDefeated++;
                    }

                    //Informacja o ataku
                    richTextBoxAttacksInfo.AppendText("Professor attacked " + fightingTeam[number].name + " and did " + attack.ToString() + " damage");
                    richTextBoxAttacksInfo.AppendText(Environment.NewLine);


                    // Ustawiamy gifa z atakiem profesora.
                    pictureBoxAttack.Image = Image.FromFile(currentPerson.spell);

                    // Blokujemy możliwość ataku gracza.
                    attackDone = true;

                    // Odczekujemy 2 sekundy.
                    WaitForMessageEnd(2);

                    // Ustawiamy nową broń jeśli warunki spełnione.
                    ChooseValidWeapon();
                }
            }
            // Jeśli prawy klik --> informacja.
            else if (e.Button == MouseButtons.Right)
            {
                // Zamykamy inne otwarte formy z informacją o postaci.
                CloseInfoForms();

                // Tworzymy nowy form z informacją o postaci.
                Student infoStudent = (Student)fightingTeam[number];

                // Wczytujemy do forma dane postaci.
                infoStudent.CharacterInfo();
            }
        }

        /// <summary>
        /// Metoda wczytująca dźwięk.
        /// </summary>
        /// <param name="soundfileName"></param>
        public void Sounds(string soundfileName)
        {
            SoundPlayer player = new SoundPlayer
            {
                SoundLocation = filename + "/Sounds/" + soundfileName + ".wav"
            };
            player.Load();
            player.Play();
        }

        /// <summary>
        /// Metoda odpowiadająca za atak przeciwnika.
        /// </summary>
        /// <param name="enemy"></param>
        private void EnemyAttack(Person enemy)
        {
            // Ustawiamy gifa z atakiem na polu między graczem, a przeciwnikiem.
            pictureBoxAttack.Image = Image.FromFile(enemy.spell);
            try
            {
                attack = (int)Math.Floor(enemy.knowledge * rnd.Next(8, 10) * 0.1);

                // Odejmujemy profesorowi życie.
                fightingTeam[0].lifeEnergy -= attack;
                // Zmieniamy stan paska życia profesora.
                progressBarProfessor.Value -= attack * 100 / fightingTeam[0].maximumLifeEnergy;
            }
            // Jeśli program wyrzuci poniższ wyjątek to życie profesora spadło poniżej zera. 
            // Koniec walki.
            catch(ArgumentOutOfRangeException)
            {
                // Zmiana wartości na pasku życia na 0.
                progressBarProfessor.Value = 0;

                // Wczytanie dźwięku przegranej.
                Sounds("lostBattle");

                // Zamknięcie formów z informacjami o postaciach.
                CloseInfoForms();

                // Wywołujemy metodę, która informuje o przegranej.
                professor.Death();

                // Zmiana stanu bitwy na false.
                FormGame.battleState = false;

                // Spadek zasobów piwa o 50%.
                FormGame.amountOfBeer = (int)Math.Floor(FormGame.amountOfBeer * 0.5);

                // Czekamy 3 sekundy na wyłączenie wiadomości.
                WaitForMessageEnd(3);

                // Odnowienie pól postaci.
                RestorePersonFields();

                // Korzystamy z interfejsu, aby dostać się do metody SpecialAbility 
                // z poziomu klasy wyżej.
                ISpecialAbility childProfessor = (ISpecialAbility) professor;
                childProfessor.SpecialAbility();

                // Zamykamy form z walką.
                this.Close();
                
            }

            //Informacja o ataku
            richTextBoxAttacksInfo.AppendText(enemy.name +  " attacked and did " + attack.ToString() + " damage");
            richTextBoxAttacksInfo.AppendText(Environment.NewLine);

            // Jeśli życie profesora nie spadło do 0.
            if (progressBarProfessor.Value != 0)
            {
                // Poczekaj 1 sekundę.
                WaitForMessageEnd(1);

                // Idź do następnej osoby.
                GoToNextPerson();
                
                //  Zmieniaj osoby tak długo aż znajdziesz kogoś, kto nie jest pokonany.
                while (listForInfo[fightingTeam.IndexOf(currentPerson)] == 0)
                {
                    GoToNextPerson();
                }
            }
        }
        
        /// <summary>
        /// Metoda, która jest odpowiedzialna za wyświetlanei wiadomości 
        /// w czasie walki.
        /// </summary>
        /// <param name="messageText"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="time"></param>
        private void ShowMessage(string messageText, int x = 380, int y = 156, int time = 1)
        {
            // Tworzymy forma z wiadomością.
            var message = new FormMessageInBattle
            {
                Width = x,
                Height = y
            };

            // Ustawiamy szerokość forma.
            message.labelMessageInBattle.Width = x - 20;
            message.labelMessageInBattle.Height = y - 20;

            // Ustawiamy położenie forma.
            message.Left = this.Left + (this.Right - this.Left - message.Width) / 2;
            message.Top = this.Top - (this.Top - this.Bottom) / 2 - message.Height;

            // Wczytujemy tekst do wiadomości.
            message.labelMessageInBattle.Text = messageText;

            // Ustawiamy czas, po którym form zostanie zamknięty.
            Task.Delay(TimeSpan.FromSeconds(time)).ContinueWith((t) => message.Close(),
                TaskScheduler.FromCurrentSynchronizationContext());
            // Wyświetlenie wiadomości z focusem na ten form.
            message.ShowDialog();
        }

        /// <summary>
        /// Metoda, która wyświetla wiadomość o turze przeciwnika
        /// oraz przechodzi do następnej postaci.
        /// </summary>
        private void OpponentTurn()
        {
            // Resetujemy czas profesora na ruch.
            secondsLeft = 30;

            // Przechodzimy do następnej osoby.
            GoToNextPerson();

            // Wiadomość nie została pokazana.
            messageShown = false;

            // Wyświetlamy wiadomość z turą przeciwnika
            ShowMessage("Opponent's turn.");

            // Czekamy sekundę i wyłączamy wiadomość.
            WaitForMessageEnd(1);
        }
        

        /// <summary>
        /// Metoda odpowiedzialna za czas oczekiwania 
        /// do wyłączenia wiadomości.
        /// </summary>
        /// <param name="timeAmount"></param>
        private void WaitForMessageEnd(int timeAmount)
        {
            // Zatrzymaj czas w walce.
            timerSecondsLeft.Stop();

            // Ustaw nowy czas dla wiadomości
            messageEndValue = timeAmount;

            // Włącz timer oczekujący do końca wiadomości.
            timerWaitForMessageEnd.Start();
        }

        /// <summary>
        /// Ładowanie forma z walką.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void FormBattlefield_Load(object sender, EventArgs e)
        {
            // Włączamy i zapętlamy dźwięk w walce.
            SoundPlayer sound = new SoundPlayer(filename + "/Sounds/battle" + rnd.Next(1,3).ToString() + ".wav");
            sound.PlayLooping();

            textBoxSecondsLeft.ReadOnly = true;

            // Dopóki lista z walczącymi postaciami krótsza niż 5 losuj nowe postaci.
            while (fightingTeam.Count() <= 4)
            {
                int elementIndex = rnd.Next(1, 10);
                if (fightingTeam.Contains(FormGame.listOfStudents[elementIndex]) == false)
                {
                    fightingTeam.Add(FormGame.listOfStudents[elementIndex]);
                }
            }

            // Dodajemy do listy starostę studentów.
            fightingTeam.Add(FormGame.listOfStudents[FormGame.listOfStudents.Count() - 1]);

            // Wczytujemy obrazki z postaciami.
            pictureBoxProfessorBattle.Image = Image.FromFile(fightingTeam[0].imageOfCharacter);
            pictureBoxStudentBattle1.Image = Image.FromFile(fightingTeam[1].imageOfCharacter);
            pictureBoxStudentBattle2.Image = Image.FromFile(fightingTeam[2].imageOfCharacter);
            pictureBoxStudentBattle3.Image = Image.FromFile(fightingTeam[3].imageOfCharacter);
            pictureBoxStudentBattle4.Image = Image.FromFile(fightingTeam[4].imageOfCharacter);
            pictureBoxStudentBattle5.Image = Image.FromFile(fightingTeam[5].imageOfCharacter);

            // Ustawiamy aktualną osobę na profesora.
            currentPerson = fightingTeam[0];

            // Przypisujemy zadeklarowanemu profesorowi pierwszy element listy 
            // zrzutowany klasę niżej.
            professor  = (Professor)fightingTeam[0];

            // Włączamy główny timer w walce.
            timerSecondsLeft.Start();
        }
        
        /// <summary>
        /// Metoda odpowiedzialna za zmianę aktualnej osoby.
        /// </summary>
        private void GoToNextPerson()
        {
            // Sprawdzamy czy index + 1 nie przekroczy długości listy.
            if (currentPersonIndex <= fightingTeam.Count() - 2)
            {
                currentPersonIndex += 1;
                currentPerson = fightingTeam[currentPersonIndex];
            }
            // Jeśli przekroczy ustawiamy profesora na aktualną postać.
            else
            {
                currentPerson = fightingTeam[0];
                currentPersonIndex = 0;
            }
        }

        /// <summary>
        ///  Metoda odliczająca czas w głównym timerze z gry.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TimerSecondsLeft_Tick(object sender, EventArgs e)
        {   
            // Jeśli obecna osoba to profesor.
            if (currentPerson == fightingTeam[0])
            {
                // Jeśli wiadomość o turze gracza jeszcze nie pokazana.
                if(messageShown == false)
                {
                    messageShown = true;
                    ShowMessage("Your turn.");
                    WaitForMessageEnd(2);
                    allowAttack = true;

                    // Zmiana boola z informacją o tym, czy gracz może atakować.	
                    attackDone = false;
                }

                // Odliczanie sekund w ruchu gracza.
                secondsLeft--;
            }
            
            // Jeśli ruch przeciwnika.
            else
            {
                // Odliczanie sekund pomiędzy atakami.
                secondBetweenEnemiesAttacks--;

                // Jeśli czas pomiędzy atakami upłynął. 
                if (secondBetweenEnemiesAttacks == 0)
                {
                    // Jeśli obecna osoba jest już pokonana idź do następnej.
                    while (listForInfo[fightingTeam.IndexOf(currentPerson)] == 0)
                    {
                        GoToNextPerson();
                    }

                    // Jeśli pętla nie przerzuciła nas na profesora.
                    if (currentPerson != professor)
                    {
                        EnemyAttack(currentPerson);
                    }
                    secondBetweenEnemiesAttacks = 3;
                }
                // Jeśli upłynie sekunda od ataku przeciwnika skasuj gifa z pola ataku.
                if (secondBetweenEnemiesAttacks == 2)
                {
                    pictureBoxAttack.Image = null;
                }
            }
            // Wyświetlamy czas, który pozostał na ruch w textBoxie.
            textBoxSecondsLeft.Text = secondsLeft.ToString();

            // Inicjujemy nowy hashSet z informacją o tym ilu przeciwników pokonaliśmy.
            HashSet<int> setOfFighters = new HashSet<int>(listForInfo);
            // Jeśli hashset liczy 2 wartości --> 0 i 1 to walka wygrana.
            if (setOfFighters.Count() == 2)
            {
                timerSecondsLeft.Stop();

                // Zamykamy otwarte formy z informacjami o postaciach.
                CloseInfoForms();

                Sounds("wonBattle");
                MessageBox.Show("You finally taught them something. " +
                    " + 1500 points");
                FormGame.score += 1500;
                FormGame.battleState = false;
                WaitForMessageEnd(3);
            }

            // Jeśli czas się skończył lub atak został wykonany, a walka nadal się toczy
            if ((secondsLeft == 0 | attackDone == true) & FormGame.battleState == true)
            {
                // Odnów możliwość ataku gracza         
                attackDone = false;

                // Mimo odnowionej możliwości ataku blokuj do czasu końca wiadomośći.
                allowAttack = false;

                // Przejdź do tury przeciwnika.
                OpponentTurn();
            }

        }
        /// <summary>
        /// Timer oczekujący na koniec wiadomości.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TimerWaitForMessageEnd_Tick(object sender, EventArgs e)
        {
            messageEndValue--;
            // Jeśli czas się skończył.
            if (messageEndValue == 0)
            {
                // Zatrzymaj timer.
                timerWaitForMessageEnd.Stop();
                
                // Jeśli walka trwa.
                if (FormGame.battleState == true)
                {
                    

                    // Włącz główny timer w trybie walki.
                    timerSecondsLeft.Start();
                }

                // Jeśli walka zakończona
                else
                {
                    // Przywróć postaciom początkowe parametry.
                    RestorePersonFields();

                    // Zamknij form.
                    Close();
                }
                // Ustaw gifa na polu ataku na null
                // (Metoda używana także do wyłączania gifów).
                pictureBoxAttack.Image = null;
            }
        }

        /// <summary>
        /// Metod odpowiedzialna za atak studenta na pierwszym polu.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PictureBoxStudentBattle1_MouseDown(object sender, MouseEventArgs e)
        {
            ProfessorAttack(e, 1, progressBarStudent1, pictureBoxStudentBattle1);
        }

        /// <summary>
        /// Metod odpowiedzialna za atak studenta na drugim polu.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PictureBoxStudentBattle2_MouseDown(object sender, MouseEventArgs e)
        {
            ProfessorAttack(e, 2, progressBarStudent2, pictureBoxStudentBattle2);
        }

        /// <summary>
        /// Metod odpowiedzialna za atak studenta na trzecim polu.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PictureBoxStudentBattle3_MouseDown(object sender, MouseEventArgs e)
        {
            ProfessorAttack(e, 3, progressBarStudent3, pictureBoxStudentBattle3);
        }

        /// <summary>
        /// Metod odpowiedzialna za atak studenta na czwartym polu.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PictureBoxStudentBattle4_MouseDown(object sender, MouseEventArgs e)
        {
            ProfessorAttack(e, 4, progressBarStudent4, pictureBoxStudentBattle4);
        }

        /// <summary>
        /// Metod odpowiedzialna za atak studenta na piątym polu.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PictureBoxStudentBattle5_MouseDown(object sender, MouseEventArgs e)
        {
            ProfessorAttack(e, 5, progressBarStudent5, pictureBoxStudentBattle5);
        }

        /// <summary>
        /// Metoda odpowiedzialna za otwarcie forma z informacją o profesorze.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PictureBoxProfessorBattle_MouseDown(object sender, MouseEventArgs e)
        {
           if (e.Button == MouseButtons.Right)
            {
                CloseInfoForms();
                professor.CharacterInfo();

            }
        }
    }
}
