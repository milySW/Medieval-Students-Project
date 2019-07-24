using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace zadanie.Models.DTO
{
    public class GetProfessorStatisticsDto
    {
        public int Id { get; set; }
        public DateTime BirthDay { get; set; }
        public int AmountOfPublications { get; set; }
    }
}
