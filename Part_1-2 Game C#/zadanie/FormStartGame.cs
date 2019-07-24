using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace zadanie
{
    /// <summary>
    /// Form z menu startowym.
    /// </summary>
    public partial class FormStartGame : Form
    {
        public FormStartGame()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Przycisk wyłączający aplikację.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonQuit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// Przycisk włączający grę.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonStart_Click(object sender, EventArgs e)
        {
            // Tworzymy okno z wyborem postaci 
            FormSelectCharacter selectYourProfessor = new FormSelectCharacter();
            Close();
            selectYourProfessor.ShowDialog();
        }

        /// <summary>
        /// Przycisk otwierający okno z najlepszymi wynikami.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonScore_Click(object sender, EventArgs e)
        {
            FormScoreBoard scoreBoard = new FormScoreBoard();
            scoreBoard.ShowDialog();
        }
    }
}
