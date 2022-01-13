using Entities;
using LMSDAL;
using LMSService.Interfaces;
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
            return Convert.ToInt32( _contex.Employees.Where(e => e.UserId == userId).FirstOrDefault().OrgnizationId);
        }
    }
}
