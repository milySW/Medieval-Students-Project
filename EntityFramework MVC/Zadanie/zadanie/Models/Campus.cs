using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace zadanie.Models
{
    public class Campus
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int AmountOfPublications { get; set; }
        public int Rank { get; set; }
        public virtual List<Professor> Professors { get; set; }
    }
}
