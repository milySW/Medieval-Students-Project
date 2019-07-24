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
    ///  Klasa profesora algebry, który jest jedną 
    ///  z 4 postaci do wyboru.
    /// </summary>
    class AlgebraProfessor : Professor,  ISpecialAbility
    {
        /// <summary>
        /// Konstruktor klasy AlgebraProfessor
        /// </summary>
        /// <param name="manOrWoman"></param>
        public AlgebraProfessor(string manOrWoman, string name)
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
                            listOfSkins[0] = Int32.Parse(reader[1].ToString());
                            listOfSkins[1] = Int32.Parse(reader[2].ToString());
                        }

                        reader.Close();

                    }
                    connection.Close();
                }
            }

            // Inne paramtery i zdjęcia w zależności od płci.
            if (manOrWoman == "Man")
            {
                knowledge = 70;
                lifeEnergy = 280;
                if (listOfSkins[0] == 0)
                {
                    imageOfCharacter = filename + "/Images/Battle/algebraistMan.png";
                }
                else
                {
                    imageOfCharacter = filename + "/Images/Battle/algebraistMan2.png";
                }
            }
            else
            {
                knowledge = (int)Math.Floor(70 * 0.8);
                lifeEnergy = (int)Math.Floor(280 * 1.1);
                if (listOfSkins[1] == 0)
                {
                    imageOfCharacter = filename + "/Images/Battle/algebraistWoman.png";
                }
                else
                {
                    imageOfCharacter = filename + "/Images/Battle/algebraistWoman2.png";
                }
            }
            // Zainicjowanie pól wspólnych dla kobiety i mężczyzny.
            maximumLifeEnergy = lifeEnergy;
            sex = manOrWoman;
            currentAttackName = "Matrix";
            attackName1 = "Matrix";
            attackName2 = "Linear space";
            attackName3 = "Jordan Matrix";
            basicSpell = filename + "/Gifs/algebraistProfessor1.gif";
            spell = basicSpell;
            firstSpellPath = filename + "/Gifs/algebraistProfessor2.gif";
            secondSpellPath = filename + "/Gifs/algebraistProfessor3.gif";
           
        }
       
        /// <summary>
        /// Metoda z interfejsu odpowiadająca za bonusowe zadanie, 
        /// które profesor może dostać po przegranej walce.
        /// U profesora algebry jest to liczenie prostego wyznacznika.
        /// </summary>
        public void SpecialAbility()
        {
            // Stworzenie forma z wyznacznikiem.
            FormSpecialAbilityAlgebraist determinantTask = new FormSpecialAbilityAlgebraist();
            // Tworzymy generator randomowych liczb.
            Random rnd = new Random();

            // Tworzymy 4 liczby, które odpowiadają za zawartość wyznacznika.
            var leftUpDeterminant = rnd.Next(1, 20);
            var leftDownDeterminant = rnd.Next(1, 20);
            var rightUpDeterminant = rnd.Next(1, 20);
            var rightDownDeterminant = rnd.Next(1, 20);

            // Wpisanie liczb do forma z wyznacznikiem.
            determinantTask.labelDeterminant1.Text = leftUpDeterminant.ToString();
            determinantTask.labelDeterminant2.Text = leftDownDeterminant.ToString();
            determinantTask.labelDeterminant3.Text = rightUpDeterminant.ToString();
            determinantTask.labelDeterminant4.Text = rightDownDeterminant.ToString();

            // Wyświetlamy form i przsuwamy go na sam przód.
            determinantTask.Show();
            determinantTask.BringToFront();
        }
    }
}
