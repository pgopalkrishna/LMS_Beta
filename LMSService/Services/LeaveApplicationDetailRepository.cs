using Entities;
using LMSDAL;
using LMSService.Interfaces;
using LMSService.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMSService.Services
{
    public class LeaveApplicationDetailRepository : Repository<LeaveApplicationDetail>, ILeaveApplicationDetailRepository
    {
       // private readonly ApplicationContext _context;
        public LeaveApplicationDetailRepository(ApplicationContext contex) : base(contex)
        {
            //_context = contex;
        }
        
    }
}
