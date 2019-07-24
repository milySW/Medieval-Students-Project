using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace zadanie.Api.Models
{
    /// <summary>
    /// Class with issue.
    /// </summary>
    public class Issue
    {
        /// <summary>
        /// Issue id.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// User who created issue info.
        /// </summary>
        [Required]
        public UserClass User { get; set; }

        /// <summary>
        /// Issue name and tags.
        /// </summary>
        [Required]
        public Topic TopicInfo { get; set; }

        /// <summary>
        /// List of comments in issue.
        /// </summary>
        public Dictionary<string, Message> ListOfMessages { get; set; } 
    }
}