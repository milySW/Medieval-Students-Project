using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace zadanie.Models
{
    /// <summary>
    /// Klasa z danymi użytkownika.
    /// </summary>
    public class UserFormViewModel
    {
        /// <summary>
        /// Imię
        /// </summary>
        [Required(ErrorMessage = "First name is required.")]
        public string FirstName { get; set; }

        /// <summary>
        /// Nazwisko
        /// </summary>
        [Required(ErrorMessage = "Last name is required.")]
        public string LastName { get; set; }

        /// <summary>
        /// Nick gracza
        /// </summary>
        [Required(ErrorMessage = "Nick is required.")]
        public string Nick { get; set; }

        /// <summary>
        /// Hasło
        /// </summary>
        [Required(ErrorMessage = "Password is required.")]
        [MinLength(8)]
        public string Password { get; set; }

        /// <summary>
        /// Potwierdzenie hasła
        /// </summary>
        [Required(ErrorMessage = "Confirmation Password is required.")]
        [Compare("Password", ErrorMessage = "Password and Confirmation Password must match.")]
        public string ConfirmPassword { get; set; }

        /// <summary>
        /// Zdjęcie profilowe
        /// </summary>
        public string Photo { get; set; }
    }
}
