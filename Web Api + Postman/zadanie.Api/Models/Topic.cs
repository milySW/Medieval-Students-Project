using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace zadanie.Api.Models
{
    /// <summary>
    /// Class with topic name and tags.
    /// </summary>
    public class Topic
    {
        /// <summary>
        /// Topic id.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Topic name.
        /// </summary>
        [Required]
        public string TopicName { get; set; }

        /// <summary>
        /// Topic tags.
        /// </summary>
        public List<string> Tags { get; set; }
    }
}
