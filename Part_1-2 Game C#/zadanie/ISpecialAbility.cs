using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zadanie
{
    /// <summary>
    /// Interfejs z zadeklarowaną metodą
    /// tworzącą zadanie specjalne  dla profesora.
    /// </summary>
    public interface ISpecialAbility
    {
        /// <summary>
        /// Metoda tworząca zadnie specjalne dla profesora.
        /// </summary>
        void SpecialAbility();
    }
}
