using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zadanie
{
    /// <summary>
    /// Najwyższa klasa w hierachi.
    /// Nie potrzebujemy tworzyć jej instancji, więc abstract.
    /// </summary>
    abstract public class Person
    {
        // Zainicjowanie pól wspólnych dla wszystkich klas dziedziczących.
        public string sex;
        public string name;
        public int knowledge;
        public int lifeEnergy;
        public int maximumLifeEnergy;
        
        // Pole ze ścieżką do gifu ataku.
        public string spell;

        // Pole z informacją o statusie osoby.
        public string status;

        // Pole z informacją o postaci.
        public string history;

        // Pole ze ścieżką do zdjęcia postaci.
        public string imageOfCharacter;

        // Pole ze ścieżką do głównego folderu w projekcie.
        public readonly string filename = Directory.GetParent(Directory.GetParent(Directory.GetParent
                    (System.AppDomain.CurrentDomain.BaseDirectory).FullName).FullName).FullName;

    }
}
