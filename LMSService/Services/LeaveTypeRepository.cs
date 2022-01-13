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
    public class LeaveTypeRepository : Repository<LeaveType>, ILeaveTypeRepository
    {
        private readonly ApplicationContext _context;
        public LeaveTypeRepository(ApplicationContext contex) : base(contex) 
        { 
            _context = contex;
        }
        public async Task<IEnumerable<vwLeaveType>> GetLeaveTypeList()
        {
            return await _context.LeaveTypes.Select(s => new vwLeaveType
            {
                Id = s.Id,
                Name = s.Name,
                IsActive = s.IsActive,
                OrgnizationId = s.OrgnizationId,
                OrgName = _context.Organizations.Where(o=>o.Id==s.OrgnizationId).FirstOrDefault().OrgnizationName
            }).ToListAsync();
        }
    }
}
