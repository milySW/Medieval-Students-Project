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
    /// <summary>
    /// Form, w którym dokonujemy wyboru postaci.
    /// </summary>
    public partial class FormSelectCharacter : Form
    {
        public FormSelectCharacter()
        {
            InitializeComponent();
        }

        // Lista z dostępnymi klasami profesorów.
        List<string> listOfProfessorsClass = new List<string>() {"Professor of analysis", "Professor of algebra",
            "Professor of programming", "Professor humanist" };

        // Lista z nazwami obrazków.
        List<string> listOfPictureNames = new List<string>() { "analyst", "algebraist", "programmer", "humanist" };

        // Lista z opisami postaci.
        List<string> listOfStories = new List<string>() { "Powerful magician, the terror for humanist students." +
                " Every student has to pass his exams to become a true craftsman." +
                " He can use his incomprehensible magic to decrease the death indicator.",
            "Ancient magicians, who know how to change the behavior of the environment. " +
                "They could easily change space and avoid flood or earthquakes.",
            "There were no computers in ancient times. Despite it, there were people" +
                " who could reach or secure every place in the kingdom using magic. Every information was" +
                " passed through them. Those cunning and bright people were known as spies or programmers." +
                "Very useful when you want to avoid fights or feel safety.", "No real skills." };

        // Lista z informacjami o wiedzy i wytrzymałości dla mężczyzn.
        List<int> listOfManKnowledgeAndEnergy = new List<int>() {80, 240, 70, 280, 60, 360, 15, 40};

        // Lista z informacjami o wiedzy i wytrzymałości dla kobiet.
        List<int> listOfWomanKnowledgeAndEnergy = new List<int>() { 64, 264, 56, 308, 48, 396, 15, 40 };

        // Indeks pozwalający na poruszanie się w liście.
        int elementIndex = 0;

        // Zadeklarowanie domyślnej płci.
        string sex = "Man";

        // Ścieżka do głównego folderu.
        string filename = Directory.GetParent(Directory.GetParent(Directory.GetParent
                    (System.AppDomain.CurrentDomain.BaseDirectory).FullName).FullName).FullName;

        /// <summary>
        /// Metoda przygotowująca parametry postaci.
        /// </summary>
        private void PrepareParameters()
        {
            //Ustawiamy informację o klasie postaci.
            labelClass.Text = listOfProfessorsClass[elementIndex];

            //Ustawiamy obrazek postaci.
            pictureBoxProfessor.Image = Image.FromFile(filename + "/Images/Battle/" + listOfPictureNames[elementIndex] + sex + ".png");

            // Ustawiamy parametry różniące się w zależności od płci.
            if (sex == "Man")
            {
                progressBarKnowledge.Value = listOfManKnowledgeAndEnergy[2 * elementIndex];
                progressBarLifeEnergy.Value = listOfManKnowledgeAndEnergy[2 * elementIndex + 1]/4;
            }
            else
            {
                progressBarKnowledge.Value = listOfWomanKnowledgeAndEnergy[2 * elementIndex];
                progressBarLifeEnergy.Value = listOfWomanKnowledgeAndEnergy[2 * elementIndex + 1]/4;
            }
            
            // Ustawiamy historię postaci.
            richTextBoxCharacterInfo.Text = listOfStories[elementIndex];
        }

        /// <summary>
        /// Metoda odpowiedzialna za wybór postaci.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonSelect_Click(object sender, EventArgs e)
        {   
            // Pierwsze 3 ify sprawdzają czy podane imię spełnia wymogi 
            // (potrzebne to tabeli z wynikami)
            if (textBoxName.Text == "")
            {
                MessageBox.Show("Please enter character's name.");
            }
            else if (textBoxName.Text.Contains(" "))
            {
                MessageBox.Show("Character's name can't contain space.");
            }
            else if(textBoxName.Text.Count() > 10)
            {
                MessageBox.Show("Character's name can't be longer than 10 signs.");
            }
            else if (textBoxName.Text.Contains("ł") || textBoxName.Text.Contains("ą")
                || textBoxName.Text.Contains("ę") || textBoxName.Text.Contains("ó")
                || textBoxName.Text.Contains("ć") || textBoxName.Text.Contains("ź")
                || textBoxName.Text.Contains("ż"))
            {
                MessageBox.Show("Character's name can't contain polish characters.");
            }
            // Jeśli podane imie spełnia wymagania, sprawdzamy jakiej klasy profesora wybrano.
            else
            {
                if (listOfPictureNames[elementIndex] == "analyst")
                {
                    // Tworzymy profesora analizy.
                    FormGame.professorCharacter = new AnalysisProfessor(sex, textBoxName.Text)
                    {
                        status = "Analyst",
                        history = listOfStories[0],
                    };

                    // Profesor obniża szansę na śmierć studenta.
                    // Dodajemy do listy eventów inne możliwe zdarzenia,
                    // tak żeby było ich 2 razy więcej.
                    FormGame.listOfEvents.Add("attack");
                    FormGame.listOfEvents.Add("flood");
                }
                else if (listOfPictureNames[elementIndex] == "algebraist")
                {
                    // Tworzymy profesora algebry.
                    FormGame.professorCharacter = new AlgebraProfessor(sex, textBoxName.Text)
                    {
                        status = "Algebraist",
                        history = listOfStories[1],
                    };

                    // Profesor obniża szansę na powódź.
                    // Dodajemy do listy eventów inne możliwe zdarzenia,
                    // tak żeby było ich 2 razy więcej.
                    FormGame.listOfEvents.Add("attack");
                    FormGame.listOfEvents.Add("death");
                }
                else if (listOfPictureNames[elementIndex] == "programmer")
                {
                    // tworzymy profesora programowania.
                    FormGame.professorCharacter = new ProgrammingProfessor(sex, textBoxName.Text)
                    {
                        status = "Programmer",
                        history = listOfStories[2],
                    };

                    // Profesor obniża szansę na atak.
                    // Dodajemy do listy eventów inne możliwe zdarzenia,
                    // tak żeby było ich 2 razy więcej.
                    FormGame.listOfEvents.Add("death");
                    FormGame.listOfEvents.Add("flood");
                }
                else if (listOfPictureNames[elementIndex] == "humanist")
                {
                    // Tworzymy profesora humanistę.
                    FormGame.professorCharacter = new ProfessorHumanist();
                }
                FormGame.professorCharacter.name = textBoxName.Text;
                this.Close();
            }
        }

        /// <summary>
        /// Przycisk zmieniający płeć na męską.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonMan_Click(object sender, EventArgs e)
        {
            sex = "Man";
            PrepareParameters();
        }

        /// <summary>
        /// Przycisk zmieniający płeć na żeńską.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonWoman_Click(object sender, EventArgs e)
        {
            sex = "Woman";
            PrepareParameters();
        }

        /// <summary>
        /// Przycisk cofający do poprzedniej postaci.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonPrevious_Click(object sender, EventArgs e)
        {
            {
                if (elementIndex > 0)
                {
                    elementIndex--;
                }
                else
                {
                    elementIndex = 3;
                }
                PrepareParameters();
            }

        }

        /// <summary>
        /// Przycisk zmieniający postać na następną.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonNext_Click(object sender, EventArgs e)
        {
            if (elementIndex < 3)
            {
                elementIndex++;
            }
            else
            {
                elementIndex = 0;
            }
            PrepareParameters();
        }

        /// <summary>
        /// Załadowanie okna z wyborem postaci.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormSelectCharacter_Load(object sender, EventArgs e)
        {
            // Przygotowujemy widok ładując parametry pierwszej postaci z listy.
            PrepareParameters();
        }
    }
}
