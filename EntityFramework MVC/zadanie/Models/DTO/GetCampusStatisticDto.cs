using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace zadanie.Models.DTO
{
    public class GetCampusStatisticDto
    {
        public int Id { get; set; }
        public int AmountOfPublications { get; set; }
        public int Rank { get; set; }
    }
}
