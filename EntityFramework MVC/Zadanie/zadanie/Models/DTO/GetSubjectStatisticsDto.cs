using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace zadanie.Models.DTO
{
    public class GetSubjectStatisticsDto
    {
        public int Id { get; set; }
        public int AmountOfHours { get; set; }
        public int ECTS { get; set; }
        public int PassRate { get; set; }
    }
}
