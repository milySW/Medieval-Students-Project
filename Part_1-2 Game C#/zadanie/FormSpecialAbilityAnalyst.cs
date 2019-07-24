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
    /// analizy. Dostaje je w ramach nagrody pocieszenia
    /// po przegranej bitwie. 
    /// </summary>
    public partial class FormSpecialAbilityAnalyst : Form
    {
        public FormSpecialAbilityAnalyst()
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
            // Jeśli odpowiedź prawidłowa (całka dobrze policzona).
            if((Int32.Parse(labelDx.Text) * (Int32.Parse(labelUpperLimit.Text) 
                - Int32.Parse(labelLowerLimit.Text))).ToString() == textBoxResult.Text)
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
