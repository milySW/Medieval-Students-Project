using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using zadanie.Models.DTO;

namespace zadanie.Services
{
    interface IPublicationsService
    {
        GetPublicationsStatisticDto GetPublicationsStatistic(int id);
    }
}
