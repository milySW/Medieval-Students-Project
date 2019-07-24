using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using zadanie.Models;
using zadanie.Models.DTO;
using AutoMapper;

namespace zadanie.Mappings
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<Professor, GetProfessorStatisticsDto>();
            CreateMap<Campus, GetCampusStatisticDto>();
            CreateMap<Subject, GetSubjectStatisticsDto>();
            CreateMap<Publications, GetPublicationsStatisticDto>();
        }
    }
}
