using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zadanie
{
    /// <summary>
    /// Klasa dziedzicząca po klasie student.
    /// Odpowiada za starostę studentów.
    /// </summary>
    class StudentsForeman : Student
    {
        /// <summary>
        /// Konstruktor klasy StudentsForeman.
        /// </summary>
        /// <param name="number"></param>
        public StudentsForeman(int number) : base(number)
        {
            // Wzmacniamy atak
            knowledge = knowledge + 10;

            // Zwiększamy życie.
            lifeEnergy = lifeEnergy * 2;

            // Wczytujemy zdjęcie postaci.
            imageOfCharacter = filename + "/Images/Battle/studentsForeman.png";

            // Wczytujemy gif ataku.
            spell = filename + "/Gifs/studentsForeman.gif";
        }   
    }
}
