using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace zadanie.Models
{
    public class Publications
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public DateTime DateOfRelease { get; set; }
        public int Popularity { get; set; }
        public string Subject { get; set; }

        [ForeignKey("ProfessorId")]
        public int ProfessorId { get; set; }
        public Professor Professor { get; set; }
    }
}
