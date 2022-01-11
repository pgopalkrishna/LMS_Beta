using Entities;
using LMSDAL;
using LMSService.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMSService.Services
{
    public class WorkLocationRepository : Repository<WorkLocation>, IWorkLocationRepository
    {
        public WorkLocationRepository(ApplicationContext contex) : base(contex) { }
    }
}
