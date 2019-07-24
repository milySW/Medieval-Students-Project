using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace zadanie.Api.Models
{
    /// <summary>
    /// Class with message text and user info
    /// </summary>
    public class Message
    {
        /// <summary>
        /// Message id.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// User info.
        /// </summary>
        [Required]
        public UserClass User { get; set; }

        /// <summary>
        ///  Message text.
        /// </summary>
        [Required]
        public string MessageText { get; set; }
    }
}
