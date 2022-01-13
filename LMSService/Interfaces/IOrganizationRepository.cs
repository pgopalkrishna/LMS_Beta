using Entities;
using LMSService.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMSService.Interfaces
{
    public interface IOrganizationRepository:IRepository<Organization>
    {
        Task<IEnumerable<vwOrganization>> GetOrganizations();
    }
}
