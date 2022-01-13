using Entities;
using LMSService.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMSService.Interfaces
{
    public interface IWorkLocationRepository : IRepository<WorkLocation>
    {
        Task<IEnumerable<vwWorkLocation>> GetWorkLocationList();
    }
}
