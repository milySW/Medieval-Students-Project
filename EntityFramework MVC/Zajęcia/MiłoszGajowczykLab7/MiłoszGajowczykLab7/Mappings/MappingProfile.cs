using AutoMapper;
using MiłoszGajowczykLab7.Models;
using MiłoszGajowczykLab7.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiłoszGajowczykLab7.Mappings
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<Jumper, GetStaticJumperDto>();
        }
    }
}
