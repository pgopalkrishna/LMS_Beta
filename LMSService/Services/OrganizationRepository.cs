using Entities;
using LMSDAL;
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
    public class OrganizationRepository : Repository<Organization>,IOrganizationRepository
    {
        private readonly ApplicationContext _context;
        public OrganizationRepository(ApplicationContext contex) : base(contex) 
        {
            _context = contex;
        }

        public async  Task<IEnumerable<vwOrganization>> GetOrganizations()
        {
            return await  _context.Organizations.Select(s => new vwOrganization
            {
                Id = s.Id,
                OrgnizationName = s.OrgnizationName,
                ContactEmail = s.ContactEmail,
                ContactNumber = s.ContactNumber,
                OrgAddress = s.OrgAddress
            }).ToListAsync();
        }

        //public async Task<IEnumerable<vwOrganization>> GetVWOrganizations() 
        //{
        //    return _context.Organizations.Select(s => new vwOrganization
        //    {
        //        Id=s.Id,
        //        OrgnizationName=s.OrgnizationName,
        //        ContactEmail=s.ContactEmail,
        //        ContactNumber=s.ContactNumber,
        //        OrgAddress=s.OrgAddress
        //    }).ToList();
        //}
        
    }
}
