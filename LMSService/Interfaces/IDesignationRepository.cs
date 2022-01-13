using Entities;
using LMSService.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMSService.Interfaces
{
    public interface IDesignationRepository : IRepository<Designation>
    {
        Task<IEnumerable<vwDesignation>> GetDesignationList();
    }
}
