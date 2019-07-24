using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace zadanie.Api.Models
{
    /// <summary>
    /// Class with description of new character.
    /// </summary>
    public class NewCharacter
    {
        /// <summary>
        /// New character id.
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// User info.
        /// </summary>
        [Required]
        public UserClass User { get; set; }

        /// <summary>
        /// Character info.
        /// </summary>
        public Character PostedCharacter { get; set; }

        /// <summary>
        /// Image converted to Base64 string (example converter: https://www.base64-image.de).
        /// Remember to delete 'data:image/png;base64,' prefix.
        /// </summary>
        [JsonConverter(typeof(Base64FileJsonConverter))]
        public byte[] ImageData { get; set; }

    }
}
