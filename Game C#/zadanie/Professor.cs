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
     abstract class Professor : Person, ICharacterInfo
    {
        // pola z informacją czy zdobyliśmy itemy w trakcie walki.
        public bool itemOneChecked = false;
        public bool itemTwoChecked = false;

        // Pola ze ścieżkami do gifów ataków.
        public string firstSpellPath;
        public string secondSpellPath;
        public string basicSpell;

        // Pola zawierające informacje o nazwach ataków.
        public string currentAttackName;
        public string attackName1;
        public string attackName2;
        public string attackName3;

        Random rnd = new Random();

        /// <summary>
        /// Metoda wyświetlająca informację, gdy gracz przegra.
        /// </summary>
        public virtual void Death()
        {
            MessageBox.Show("You were fighting with students like " +
                "a beast. You lost 50% of beer supplies but students have the last gift for you. If you anwer the question you will gain " +
                "an extra 500 points.");
        }

        /// <summary>
        /// Metoda odpowiedzialna za ilość obrażeń jakie 
        /// profesor zadaje przy ataku.
        /// </summary>
        /// <returns></returns>
        public int Teach()
        {
            return (int)Math.Floor(knowledge * rnd.Next(8, 10) * 0.1);
        }

        /// <summary>
        /// Metoda ataku przeciążone o mnożnik.
        /// </summary>
        /// <param name="multipledDamage"></param>
        /// <returns></returns>
        public int Teach(int multipledDamage)
        {
            return (int) Math.Floor(knowledge * multipledDamage* rnd.Next(8,10) * 0.1);
        }

        /// <summary>
        /// Metoda ataku przeciążona o mnożnik i dodatkowe obrażenia.
        /// </summary>
        /// <param name="multipledDamage"></param>
        /// <param name="additionalDamage"></param>
        /// <returns></returns>
        public int Teach(int multipledDamage, int additionalDamage)
        {
            return (int)Math.Floor(knowledge * multipledDamage * rnd.Next(8, 10) * 0.1) + additionalDamage;
        }

        /// <summary>
        /// Metoda wczytująca parametry postaci do formu z informacjami.
        /// </summary>
        public void CharacterInfo()
        {
            FormProfessorInfo infoAboutProfessor = new FormProfessorInfo();
            infoAboutProfessor.labelSpellName.Text = currentAttackName;
            infoAboutProfessor.labelName.Text = name;
            infoAboutProfessor.richTextBoxHistory.Text = history;
            infoAboutProfessor.textBoxStatus.Text = status;
            infoAboutProfessor.textBoxSex.Text = sex;
            infoAboutProfessor.progressBarKnowledge.Value = knowledge;
            infoAboutProfessor.progressBarEnergy.Value = (int)Math.Floor(maximumLifeEnergy * 0.25);
            infoAboutProfessor.pictureBoxPerson.SizeMode = PictureBoxSizeMode.StretchImage;
            infoAboutProfessor.pictureBoxSpell.SizeMode = PictureBoxSizeMode.StretchImage;
            infoAboutProfessor.pictureBoxPerson.Image = Image.FromFile(imageOfCharacter);
            infoAboutProfessor.pictureBoxSpell.Image = Image.FromFile(spell);
            infoAboutProfessor.Show();

        }

    }
}
