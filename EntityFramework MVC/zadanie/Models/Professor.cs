using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace zadanie.Models
{
    public class Professor
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string ClassName { get; set; }
        public DateTime BirthDay { get; set; }
        public int AmountOfPublications { get; set; }

        [ForeignKey("CampusId")]
        public int CampusId { get; set; }
        public Campus Campus { get; set; }
    }
}
