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
    public class LeaveRuleRepository : Repository<LeaveRule>, ILeaveRuleRepository
    {
        public LeaveRuleRepository(ApplicationContext contex) : base(contex) { }
    }
}
