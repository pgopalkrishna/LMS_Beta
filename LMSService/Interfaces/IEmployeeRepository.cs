using Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMSService.Interfaces
{
    public interface IEmployeeRepository : IRepository<Employee>
    {
        public ArrayList GetCurrentOrg(string userId);
        public int GetCurrentOrgId(string userId);
    }
}
