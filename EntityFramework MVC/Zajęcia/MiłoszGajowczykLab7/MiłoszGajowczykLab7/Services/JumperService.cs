using AutoMapper;
using MiłoszGajowczykLab7.Models;
using MiłoszGajowczykLab7.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiłoszGajowczykLab7.Services
{
    public class JumperService : IJumperService
    {
        private readonly SkiJumpingContext _context;
        private readonly IMapper _mapper;
        public JumperService(SkiJumpingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public GetStaticJumperDto GetStatisticJumper(int id)
        {
            var jumper = _context.Jumpers.FirstOrDefault(c => c.Id == id);

            var statisticDto = _mapper.Map<GetStaticJumperDto>(jumper);

            return statisticDto;
        }
    }
}
