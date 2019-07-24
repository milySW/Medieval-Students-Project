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
    /// Form z zadaniem specjalnym dla profesora
    /// programowania. Dostaje je w ramach nagrody pocieszenia
    /// po przegranej bitwie. 
    /// </summary>
    public partial class FormSpecialAbilityProgrammer : Form
    {
        public FormSpecialAbilityProgrammer()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Przycisk zatwierdzający odpowiedź.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonOK_Click(object sender, EventArgs e)
        {
            // Jeśli odpowiedź prawidłowa (kod captcha dobrze przepisany).
            if (labelCaptcha.Text == textBoxResult.Text)
            {
                // Dodaj 500 punktów.
                FormGame.score += 500;
                MessageBox.Show("Congratulations!");
            }
            else
            {
                MessageBox.Show("Unfortunatelly it was wrong answer.");
            }
            Close();
        }
    }
}
