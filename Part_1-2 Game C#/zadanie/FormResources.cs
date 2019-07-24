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
    public partial class FormResources : System.Windows.Forms.Form
    {
        /// <summary>
        /// Forma zawierająca informacje o aktualnych zasobach. Jako argumenty przyjmuje aktualne ilości zasobów.
        /// </summary>
        public FormResources()
        {
            InitializeComponent();
            timerTimeInResources.Start();
        }

        /// <summary>
        /// Załadowanie okna z surowcami i ustawienie textBoxów na "tylko do oczytu".
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormResources_Load(object sender, EventArgs e)
        {
            textBoxAmountOfBeer.ReadOnly = true;
            textBoxAmountOfWood.ReadOnly = true;
            textBoxAmountOfStone.ReadOnly = true;
            textBoxAmountOfNotes.ReadOnly = true;
            textBoxAmountOfGold.ReadOnly = true;

        }
        /// <summary>
        /// Timer odświeżający wartości surowców.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TimerTimeInResources_Tick(object sender, EventArgs e)
        {
            textBoxAmountOfGold.Text = FormGame.amountOfGold.ToString();
            textBoxAmountOfBeer.Text = FormGame.amountOfBeer.ToString();
            textBoxAmountOfWood.Text = FormGame.amountOfWood.ToString();
            textBoxAmountOfStone.Text = FormGame.amountOfStone.ToString();
            textBoxAmountOfNotes.Text = FormGame.amountOfNotes.ToString();
            textBoxAmountOfGold.Text = FormGame.amountOfGold.ToString();
        }
    }
}
