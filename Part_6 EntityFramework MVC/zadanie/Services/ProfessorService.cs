using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using zadanie.Models;
using zadanie.Models.DTO;

namespace zadanie.Services
{
    public class ProfessorService : IProfessorService
    {
     
        private readonly MedievalCampusContext _context;
        private readonly IMapper _mapper;
        public ProfessorService(MedievalCampusContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public GetProfessorStatisticsDto GetProfessorStatistics(int id)
        {
            var professor = _context.Professors.FirstOrDefault(c => c.Id == id);

            var statisticDto = _mapper.Map<GetProfessorStatisticsDto>(professor);

            return statisticDto;
        }
    }
}
