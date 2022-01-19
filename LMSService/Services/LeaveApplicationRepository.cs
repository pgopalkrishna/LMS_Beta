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
    public class LeaveApplicationRepository : Repository<LeaveApplication>, ILeaveApplicationRepository
    {
        private readonly ApplicationContext _context;
        public LeaveApplicationRepository(ApplicationContext contex) : base(contex) 
        {
            _context = contex;
        }
        public async Task<IEnumerable<vwLeaveApplication>> GetVwLeaveApplication()
        {
            var result = await (from leave in _context.LeaveApplications
                                join leaveDetails in _context.LeaveApplicationDetails on leave.Id equals leaveDetails.LeaveApplicationId
                                join emp in _context.Employees on leave.EmployeeId equals emp.Id
                                join leaveTypes in _context.LeaveTypes on leave.LeaveTypeId equals leaveTypes.Id
                                join lt in _context.LeaveTransactions on leave.Id equals lt.LeaveApplicationId
                                select new vwLeaveApplication
                                {
                                    Id = leave.Id,
                                    EmployeeId = leave.EmployeeId,
                                    LeaveTypeId = leave.LeaveTypeId,
                                    EmployeeName = emp.FirstName + " " + emp.LastName,
                                    LeaveTypeName = leaveTypes.Name,
                                    StartDate = leaveDetails.StartDate,
                                    EndDate = leaveDetails.EndDate,
                                    FirstDayHalf = leaveDetails.FirstDayHalf,
                                    LastDayHalf = leaveDetails.LastDayHalf,
                                    NoOfLeaves = leaveDetails.NoOfLeaves,
                                    LeaveReason = leaveDetails.LeaveReason,
                                    //Status =(int) LeaveStatusEnum.APPLIED,
                                    //Status = lt.LeaveStatus
                                    Status = ((LeaveStatusEnum)lt.LeaveStatus).ToString()
                                }).ToListAsync();
            return result;
        }
    }
}
