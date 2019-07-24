using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiłoszGajowczykLab7.Models.DTO
{
    public class GetStaticJumperDto
    {
        public int Id { get; set; }
        public float Height { get; set; }
        public float Weight { get; set; }
        public float PersonalBest { get; set; }
    }
}
