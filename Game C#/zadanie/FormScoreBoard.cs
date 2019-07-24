using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
    /// Form z najlepszymi wynikami.
    /// </summary>
    public partial class FormScoreBoard : Form
    {
        public FormScoreBoard()
        {
            InitializeComponent();
        }

        string currentDirectory = Directory.GetParent(System.AppDomain.CurrentDomain.BaseDirectory).FullName;

        /// <summary>
        /// Przycisk zamykający okno z wynikami.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonBack_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Ładowanie forma z wynikami.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormScoreBoard_Load(object sender, EventArgs e)
        {
            List<string> scores = new List<string> { };
            string connectionString = @"Data Source=LAPTOP-HPD9G79T; database=MedievalStudents; Trusted_Connection=yes";

            string query = @"SELECT Score.POINTS, AvailablePoints.Nick FROM Score INNER JOIN AvailablePoints ON Score.PlayerID 
            = AvailablePoints.ID WHERE Score.POINTS IN(SELECT TOP 10 POINTS FROM Score ORDER BY POINTS DESC)";
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        scores.Add(reader[1].ToString() + " " + reader[0].ToString());
                    }

                reader.Close();
                }
            connection.Close();

            }

            try
            {
                labelScore1.Text = scores[0];
                labelScore2.Text = scores[1];
                labelScore3.Text = scores[2];
                labelScore4.Text = scores[3];
                labelScore5.Text = scores[4];
                labelScore6.Text = scores[5];
                labelScore7.Text = scores[6];
                labelScore8.Text = scores[7];
                labelScore9.Text = scores[8];
                labelScore10.Text = scores[9];
            }
            // Jeśli wyników mniej niż 10 w pewnym momenice wyskoczy
            // poniższy wyjątek, wtedy przerywamy wczytywanie wyników.
            catch(System.IndexOutOfRangeException)
            {

            }
            
        }
    }
}
