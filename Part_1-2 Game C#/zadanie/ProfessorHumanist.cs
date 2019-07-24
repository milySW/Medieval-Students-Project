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
    /// Klasa profesora humanisty.
    /// </summary>
    class ProfessorHumanist : Professor 
    {
  
        /// <summary>
        /// Nadpisana metoda śmierci.
        /// </summary>
        public override void Death()
        {
            // Wczytanie muzyki.
            System.Media.SoundPlayer player = new System.Media.SoundPlayer
            {
                SoundLocation = filename + "/Sounds/ProfessorHumanistDeath.wav"
            };
            player.Load();
            player.PlayLooping();

            // Otwracie formu z game over dla humanisty.
            var gameOverPicture = new FormGameOver
            {
                BackgroundImage = Image.FromFile(filename + "/Images/ProfessorHumanistDeath.jpg")
            };
            gameOverPicture.Show();
            MessageBox.Show("Students are terrified because of your choice. " +
                "Even if you want to try again with the new campus, any of the students will not work with you. " +
                "It's not game over it' s the game crash. After this message game will be closed. If you want to play " +
                "run the game one more time, maybe you will deceive students.");

            // Zamknięcie aplikacji.
            Application.OpenForms.OfType<FormGame>().First().Close();

        }
    }
}
