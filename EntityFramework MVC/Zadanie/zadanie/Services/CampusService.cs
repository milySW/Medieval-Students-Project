using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using zadanie.Models;
using zadanie.Models.DTO;

namespace zadanie.Services
{
    public class CampusService : ICampusService
    {
        private readonly MedievalCampusContext _context;
        private readonly IMapper _mapper;
        public CampusService(MedievalCampusContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public GetCampusStatisticDto GetCampusStatistic(int id)
        {
            var campus = _context.Campuses.FirstOrDefault(c => c.Id == id);

            var statisticDto = _mapper.Map<GetCampusStatisticDto>(campus);

            return statisticDto;
        }
    }
}
