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
    /// algebry. Dostaje je w ramach nagrody pocieszenia
    /// po przegranej bitwie. 
    /// </summary>
    public partial class FormSpecialAbilityAlgebraist : Form
    {
        public FormSpecialAbilityAlgebraist()
        {
            InitializeComponent();
        }

        private void ButtonOK_Click(object sender, EventArgs e)
        {
            // Jeśli odpowiedź prawidłowa (wyznacznik dobrze policzony).
            if ((Int32.Parse(labelDeterminant1.Text) * Int32.Parse(labelDeterminant4.Text)
                - Int32.Parse(labelDeterminant2.Text) * Int32.Parse(labelDeterminant3.Text)).ToString() == textBoxResult.Text)
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
