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
    /// Klasa profesora programowania, który jest
    /// jedną z 4 podstawowych postaci do wyboru.
    /// </summary>
    class ProgrammingProfessor : Professor, ISpecialAbility
    {
        /// <summary>
        /// Konstruktor klasy ProgrammingProfessor.
        /// </summary>
        /// <param name="manOrWoman"></param>
        public ProgrammingProfessor(string manOrWoman, string name)
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
                            listOfSkins[0] = Int32.Parse(reader[5].ToString());
                            listOfSkins[1] = Int32.Parse(reader[6].ToString());
                        }

                        reader.Close();

                    }
                    connection.Close();
                }
            }


            // Inne paramtery i zdjęcia w zależności od płci.
            if (manOrWoman == "Man")
            {
                knowledge = 60;
                lifeEnergy = 360;
                if(listOfSkins[0] == 0)
                {
                    imageOfCharacter = filename + "/Images/Battle/programmerMan.png";
                }
                else
                {
                    imageOfCharacter = filename + "/Images/Battle/programmerMan2.png";
                }
            }
            else
            {
                knowledge = (int)Math.Floor(60 * 0.8);
                lifeEnergy = (int)Math.Floor(360 * 1.1);
                if (listOfSkins[1] == 0)
                {
                    imageOfCharacter = filename + "/Images/Battle/programmerWoman.png";
                }
                else
                {
                    imageOfCharacter = filename + "/Images/Battle/programmerWoman2.png";
                }
            }

            // Zainicjowanie pól wspólnych dla kobiety i mężczyzny.
            maximumLifeEnergy = lifeEnergy;
            sex = manOrWoman;
            basicSpell = filename + "/Gifs/programmerProfessor1.gif";
            spell = basicSpell;
            firstSpellPath = filename + "/Gifs/programmerProfessor2.gif";
            secondSpellPath = filename + "/Gifs/programmerProfessor3.gif";
            currentAttackName = "'Hello world'";
            attackName1 = "'Hello world'";
            attackName2 = "Git repository";
            attackName3 = "'Hello world' assembler";
           
        }

        public override void Death()
        {
            MessageBox.Show("You were fighting with students like " +
                "a beast. You lost 50% of beer supplies but students have the last gift for you. If you anwer the question you will gain " +
                "an extra 500 points.");

        }

        /// <summary>
        /// Metoda z interfejsu odpowiadająca za bonusowe zadanie, 
        /// które profesor może dostać po przegranej walce.
        /// U profesora programowania jest to przepisanie kodu captcha.
        /// </summary>
        public void SpecialAbility()
        {
            // Stworzenie forma z kodem captcha.
            FormSpecialAbilityProgrammer captchaTask = new FormSpecialAbilityProgrammer();

            // Tworzymy generator randomowych liczb.
            Random rnd = new Random();
            var captcha = "";

            // Tworzymy 8 znakowy string randomowych liter.
            for (int i = 0; i < 8; i++)
            {
                char let = (char)('a' + rnd.Next(0, 26));
                captcha += let.ToString();
            }

            // Wpisanie tekstu do pola z kodem captcha.
            captchaTask.labelCaptcha.Text = captcha;

            // Wyświetlamy form i przsuwamy go na sam przód.
            captchaTask.Show();
            captchaTask.BringToFront();
        }
    }
}
