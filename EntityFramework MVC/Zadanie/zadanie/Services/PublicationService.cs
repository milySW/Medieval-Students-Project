using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using zadanie.Models;
using zadanie.Models.DTO;

namespace zadanie.Services
{
    public class PublicationService : IPublicationsService
    {
        private readonly MedievalCampusContext _context;
        private readonly IMapper _mapper;
        public PublicationService(MedievalCampusContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public GetPublicationsStatisticDto GetPublicationsStatistic(int id)
        {
            var publication = _context.Publications.FirstOrDefault(c => c.Id == id);

            var statisticDto = _mapper.Map<GetPublicationsStatisticDto>(publication);

            return statisticDto;
        }
    }
}
