using Entities;
using LMSDAL;
using LMSService.Interfaces;
using LMSService.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMSService.Services
{
    public class WorkLocationRepository : Repository<WorkLocation>, IWorkLocationRepository
    {
        private readonly ApplicationContext _context;
        public WorkLocationRepository(ApplicationContext contex) : base(contex)
        {
            _context = contex;
        }
        public async Task<IEnumerable<vwWorkLocation>> GetWorkLocationList()
        {
            return await _context.WorkLocations.Select(s => new vwWorkLocation
            {
                Id = s.Id,
                Name = s.Name,
                Address = s.Address,
                ContactNumber = s.ContactNumber
            }).ToListAsync();
        }

    }
}
