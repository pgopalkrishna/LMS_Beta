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
    class LeaveApplicationDetailRepository : Repository<LeaveApplicationDetail>, ILeaveApplicationDetailRepository
    {
        public LeaveApplicationDetailRepository(ApplicationContext contex) : base(contex) { }
    }
}
