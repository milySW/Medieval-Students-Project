using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zadanie
{
    /// <summary>
    /// Interfejs z zadeklarowaną metodą na 
    /// stworzenie forma z informacją o postaci.
    /// Może się przydać gdy będę chciał stworzyć
    /// form z informacjami o postaci z poziomu klasy Person.
    /// </summary>
    public interface ICharacterInfo
    {
        /// <summary>
        /// Metoda odpowiedzialna za tworzenie 
        /// forma z informacją o postaci.
        /// </summary>
        void  CharacterInfo();
    }
}
