using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace zadanie.Api.Models
{
    /// <summary>
    /// Class with user info.
    /// </summary>
    public class UserClass
    {
        /// <summary>
        /// User first name.
        /// </summary>
        [Required]
        [MinLength(4)]
        public string FirstName { get; set; }

        /// <summary>
        /// User Last name.
        /// </summary>
        [Required]
        public string LastName { get; set; }

        /// <summary>
        /// User email.
        /// </summary>
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
