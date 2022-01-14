using Entities;
using LMSDAL;
using LMSService.Enums;
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
    public class LeaveRuleRepository : Repository<LeaveRule>, ILeaveRuleRepository
    {
        private readonly ApplicationContext _context;
        public LeaveRuleRepository(ApplicationContext contex) : base(contex)
        {
            _context = contex;
        }
        public async Task<IEnumerable<vwLeaveRule>> GetLeaveRuleList()
        {
            return await _context.LeaveRules.Select(s => new vwLeaveRule
            {
                Id = s.Id,
                LeaveTypeName = _context.LeaveTypes.Where(l => l.Id == s.LeaveTypeId).FirstOrDefault().Name,
                NoOfLeaves = s.NoOfLeaves,
                LeaveValidity = ((LeaveValidityEnum)s.LeaveValidity).ToString(),
                IsCarryForward = s.IsCarryForward,
                CarryForwardCap = s.CarryForwardCap
            }).ToListAsync();
        }
        public vwLeaveRule GetvwLeaveRuleById(int id)
        {
            return _context.LeaveRules.Where(l => l.Id == id).Select(s => new vwLeaveRule
            {
                Id = s.Id,
                LeaveTypeName = _context.LeaveTypes.Where(l => l.Id == s.LeaveTypeId).FirstOrDefault().Name,
                NoOfLeaves = s.NoOfLeaves,
                LeaveValidity = ((LeaveValidityEnum)s.LeaveValidity).ToString(),
                IsCarryForward = s.IsCarryForward,
                CarryForwardCap = s.CarryForwardCap
            }).FirstOrDefault();
        }
    }
}

