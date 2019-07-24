using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace zadanie.Api.Models
{
    /// <summary>
    /// Class with character info.
    /// </summary>
    public class Character
    {
        /// <summary>
        /// Character id.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Character name.
        /// </summary>
        [Required]
        public string CharacterName { get; set; }

        /// <summary>
        /// Character class.
        /// </summary>
        [Required]
        public string CharacterClass { get; set; }

        /// <summary>
        /// Character sex.
        /// </summary>
        public string CharacterSex { get; set; }

        /// <summary>
        /// Character history.
        [Required]
        public string CharacterHistory { get; set; }
    }
}
