using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using zadanie.Models;
using zadanie.Models.DTO;

namespace zadanie.Services
{
    public class SubjectService : ISubjectService
    {
        private readonly MedievalCampusContext _context;
        private readonly IMapper _mapper;
        public SubjectService(MedievalCampusContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public GetSubjectStatisticsDto GetSubjectStatistics(int id)
        {
            var subject = _context.Subjects.FirstOrDefault(c => c.Id == id);

            var statisticDto = _mapper.Map<GetSubjectStatisticsDto>(subject);

            return statisticDto;
        }
    }
}
