using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace zadanie
{
    /// <summary>
    /// Klasa dziedzicząca po abstrakcyjnej klasie Person.
    /// </summary>
    class Student : Person, ICharacterInfo
    {
        // Listy z imionami mężczyzn do losowania.
        List<string> listWithManNames = new List<string>() { "Baudegundis", "Clarimond", "Lidiardis", "Megendrod", "Methdin",
        "Nemerte", "Nycaise", "Parise", "Rosamund", "Reinewif", "Stenburch", "Teudsindis", "Txori", "Kordel" , "Ganor", "Guener",
        "Duncan", "Roland", "Deloys", "Zigfrid", "Zoltan", "Markus", "Midylos", "Martel"};

        // Listy z imionami kobiet do losowania.
        List<string> listWithWomanNames = new List<string>() { "Aiora", "Dametta", "Celestria", "Dora", "Lewen",
        "Mirabell", "Nyra", "Polydora", "Prothesia", "Rinnett", "Susanna", "Sibilie", "Thelma", "Kallisto", "Kalotte", "Deipyle"};

        /// <summary>
        /// Konstruktor postaci
        /// </summary>
        /// <param name="number"></param>
        public Student(int number)
        {

            // Jeśli number < 5 losuj kobietę.
            if (number < 5)
            {
                int elementOfList = FormGame.randomNameGenerator.Next(listWithWomanNames.Count());
                name = (string)listWithWomanNames[elementOfList];
                sex = "Woman";
            }
            // Losuj mężczyznę.
            else
            {
                int elementOfList = FormGame.randomNameGenerator.Next(listWithManNames.Count());
                name = (string)listWithManNames[elementOfList];
                sex = "Man";
            }
            //

            // Losujemy parametry wiedzy i energii postaci.
            knowledge = FormGame.randomKnowledgeGenerator.Next(15, 25);
            lifeEnergy = FormGame.randomLifeEnergyGenerator.Next(50, 100);

            // Zapisujemy maksymalną wartość zdrowia postaci.
            maximumLifeEnergy = lifeEnergy;

            // Zapisujemy ścieżkę do zdjęcia postaci.
            imageOfCharacter = filename + "/Images/Battle/student" + number.ToString() + ".png";

            // Wczytujemy ścieżkę do gifa z atakiem postaci.
            spell = filename + "/Gifs/student.gif";
        }

        /// <summary>
        /// Metoda z interfejsu. Wczytuje parametry postaci do
        /// forma z informacjami.
        /// </summary>
        public void CharacterInfo()
        {
            FormStudentInfo infoAboutStudent = new FormStudentInfo();
            infoAboutStudent.labelName.Text = name;
            infoAboutStudent.textBoxStatus.Text = "Student";
            infoAboutStudent.textBoxSex.Text = sex;
            infoAboutStudent.progressBarKnowledge.Value = knowledge;
            infoAboutStudent.progressBarEnergy.Value = (int) Math.Floor(maximumLifeEnergy * 0.25);
            infoAboutStudent.pictureBoxPerson.SizeMode = PictureBoxSizeMode.StretchImage;
            infoAboutStudent.pictureBoxSpell.SizeMode = PictureBoxSizeMode.StretchImage;
            infoAboutStudent.pictureBoxPerson.Image = Image.FromFile(imageOfCharacter);
            infoAboutStudent.pictureBoxSpell.Image = Image.FromFile(spell);
            infoAboutStudent.Show();
        }
    }
}
