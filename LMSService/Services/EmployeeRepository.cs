using Entities;
using LMSDAL;
using LMSService.Enums;
using LMSService.Interfaces;
using LMSService.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMSService.Services
{
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        private readonly ApplicationContext _contex;
        public EmployeeRepository(ApplicationContext contex) : base(contex)
        {
            _contex = contex;
        }
        public ArrayList GetCurrentOrg(string userId)
        {
            var CurrentOrg = new ArrayList();
            //var OrgId_str = _contex.Employees.Where(e => e.UserId == userId).FirstOrDefault().OrgnizationId;
            int OrgId = _contex.Employees.Where(e => e.UserId == userId).FirstOrDefault().OrgnizationId;
            string OrgName = _contex.Organizations.Find(OrgId).OrgnizationName;
            CurrentOrg.Add(OrgId);
            CurrentOrg.Add(OrgName);
            return CurrentOrg;
        }
        public int GetCurrentOrgId(string userId)
        {
            return Convert.ToInt32(_contex.Employees.Where(e => e.UserId == userId).FirstOrDefault().OrgnizationId);
        }
        public async Task<IEnumerable<vwEmployee>> GetvwEmployeeList()
        {
            return await _contex.Employees.Select(s => new vwEmployee
            {
                Id = s.Id,
                EmpCode = s.EmpCode,
                FirstName = s.FirstName,
                LastName = s.LastName,
                EmailId=s.EmailId,
                Designation = _contex.Designations.Where(d=>d.Id== s.DesignationId).FirstOrDefault().Name,
                Dob = s.Dob,
                ReportingManager = _contex.Employees.Where(d => d.Id == s.ReportingManagerId).FirstOrDefault().FirstName,
                WorkLocation = _contex.WorkLocations.Where(d => d.Id == s.WorkLocationId).FirstOrDefault().Name,
                Status = ((EmployeeStatusEnum)s.Status).ToString()
            }).ToListAsync();
        }
        public async Task<IEnumerable<Employee>> GetManagersList()
        {
            //var mgrs = await _contex.Employees.Join(_contex.Employees,
            //    e1 => e1.ReportingManagerId,
            //    e2 => e2.Id, (e1, e2) => new
            //    {
            //        Id = e1.FirstName,
            //        Name = $" {e2.FirstName} {e2.LastName}"
            //    }).ToListAsync();
            //return await (from e1 in _contex.Employees
            //            join e2 in _contex.Employees
            //            on e1.ReportingManagerId equals e2.Id
            //            select e1).ToListAsync();
            return await _contex.Employees.Where(e => e.Status == (int)EmployeeStatusEnum.ACTIVE).ToListAsync();
        }
    }
}
