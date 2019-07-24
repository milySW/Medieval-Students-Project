using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace zadanie.Models
{
    /// <summary>
    /// Klasa z liczbą logów, które chcemy usunąć z historii.
    /// </summary>
    public class HistoryViewModel
    {
        /// <summary>
        /// Liczba logów do usunięcia.
        /// </summary>
        [Required(ErrorMessage = "Number is required")]
        public int LogsToRemove { get; set; }
    }
}
