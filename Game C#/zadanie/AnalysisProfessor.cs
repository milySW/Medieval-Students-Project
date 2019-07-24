using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace zadanie
{
    /// <summary>
    /// Klasa profesora algebry, który jest
    /// jedną z 4 podstawowych postaci do wyboru.
    /// </summary>
    class AnalysisProfessor : Professor,  ISpecialAbility
    {
        /// <summary>
        /// Konstruktor klasy AnalysisProfessor
        /// </summary>
        /// <param name="manOrWoman"></param>
        public AnalysisProfessor(string manOrWoman, string name)
        {

            List<int> listOfSkins = new List<int> { 0, 0 };

            string query = @"SELECT * FROM CharacterSkins WHERE PlayerID = (SELECT ID FROM AvailablePoints WHERE AvailablePoints.Nick = '" + name + "')";
            using (SqlConnection connection = new SqlConnection(@"Data Source=LAPTOP-HPD9G79T; database=MedievalStudents; Trusted_Connection=yes"))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            listOfSkins[0] = Int32.Parse(reader[3].ToString());
                            listOfSkins[1] = Int32.Parse(reader[4].ToString());
                        }

                        reader.Close();

                    }
                    connection.Close();
                }
            }

            // Inne paramtery i zdjęcia w zależności od płci.
            if (manOrWoman == "Man")
            {
                knowledge = 80;
                lifeEnergy = 240;
                if (listOfSkins[0] == 0)
                {
                    imageOfCharacter = filename + "/Images/Battle/analystMan.png";
                }
                else
                {
                    imageOfCharacter = filename + "/Images/Battle/analystMan2.png";
                }
            }
            else
            {
                knowledge = (int)Math.Floor(80 * 0.8);
                lifeEnergy = (int)Math.Floor(240 * 1.1);
                if (listOfSkins[1] == 0)
                {
                    imageOfCharacter = filename + "/Images/Battle/analystWoman.png";
                }
                else
                {
                    imageOfCharacter = filename + "/Images/Battle/analystWoman2.png";
                }
            }

            // Zainicjowanie pól wspólnych dla kobiety i mężczyzny.
            maximumLifeEnergy = lifeEnergy;
            sex = manOrWoman;
            currentAttackName = "Derivative";
            attackName1 = "Derivative";
            attackName2 = "Integral";
            attackName3 = "Proof";
            basicSpell = filename + "/Gifs/analysisProfessor1.gif";
            spell = basicSpell;
            firstSpellPath = filename + "/Gifs/analysisProfessor2.gif";
            secondSpellPath = filename + "/Gifs/analysisProfessor3.gif";
           
        }

        /// <summary>
        /// Metoda z interfejsu odpowiadająca za bonusowe zadanie, 
        /// które profesor może dostać po przegranej walce.
        /// U profesora analizy jest to liczenie prostej całki.
        /// </summary>
        public void SpecialAbility()
        {
            // Stworzenie forma z całką.
            FormSpecialAbilityAnalyst integralTask = new FormSpecialAbilityAnalyst();
            
            // Tworzymy generator randomowych liczb.
            Random rnd = new Random();

            // Tworzymy 3 liczby, które odpowiadają za zawartość całki
            var upperLimit = rnd.Next(1, 30);
            var lowerLimit = upperLimit - rnd.Next(1, 10);
            var valueInIntegral = rnd.Next(1, 20);

            // Wpisanie liczb do forma z całką.
            integralTask.labelUpperLimit.Text = upperLimit.ToString();
            integralTask.labelLowerLimit.Text = lowerLimit.ToString();
            integralTask.labelDx.Text = valueInIntegral.ToString();

            // Wyświetlamy form i przsuwamy go na sam przód.
            integralTask.Show();
            integralTask.BringToFront();
        }
    }
}
