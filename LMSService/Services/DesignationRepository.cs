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
    public class DesignationRepository : Repository<Designation>, IDesignationRepository
    {
        private readonly ApplicationContext _context;
        public DesignationRepository(ApplicationContext contex) : base(contex)
        {
            _context = contex;
        }
        public async Task<IEnumerable<vwDesignation>> GetDesignationList()
        {
            return await _context.Designations.Select(s => new vwDesignation
            {
                Id = s.Id,
                Name = s.Name
            }).ToListAsync();
        }
    }
}
