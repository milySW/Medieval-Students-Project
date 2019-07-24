using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace zadanie.Models
{
    public class Subject
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string SubjectName { get; set; }
        public int AmountOfHours { get; set; }
        public int ECTS { get; set; }
        public int PassRate { get; set; }

        [ForeignKey("ProfessorId")]
        public int ProfessorId { get; set; }
        public Professor Professor { get; set; }
    }
}
