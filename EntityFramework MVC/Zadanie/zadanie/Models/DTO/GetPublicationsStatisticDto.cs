using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace zadanie.Models.DTO
{
    public class GetPublicationsStatisticDto
    {
        public int Id { get; set; }
        public DateTime DateOfRelease { get; set; }
        public int Popularity { get; set; }
    }
}
