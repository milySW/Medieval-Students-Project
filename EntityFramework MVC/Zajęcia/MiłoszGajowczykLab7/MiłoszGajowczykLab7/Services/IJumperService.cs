using MiłoszGajowczykLab7.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiłoszGajowczykLab7.Services
{
    public interface IJumperService
    {
        GetStaticJumperDto GetStatisticJumper(int id);
    }
}
