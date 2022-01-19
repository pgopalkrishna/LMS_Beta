using Entities;
using LMSService.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMSWebApp.Controllers
{
    [Authorize(Roles = "Admin")]
    public class OrganizationController : Controller
    {
        private IOrganizationRepository _repoOrganization;
        public OrganizationController(IOrganizationRepository repo)
        {
            _repoOrganization = repo;
        }
        // GET: OrganizationController
        public async Task<IActionResult> Index()
        {
            return View(await _repoOrganization.GetOrganizations());
            //return View();
        }

        // GET: OrganizationController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var org = await _repoOrganization.GetById(id);
            if (org == null)
            {
                return NotFound();
            }
            return View(org);
        }

        // GET: OrganizationController/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: OrganizationController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind("Id", "OrgnizationName", "ContactEmail", "ContactNumber", "OrgAddress")] Organization org)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //org.UpdatedBy = "";
                    //org.CreatedBy = "";
                    org.CreatedDate = DateTime.UtcNow;
                    //org.UpdatedDate = DateTime.UtcNow;
                }
                else
                {
                    //org.UpdatedBy = "";
                    //org.CreatedBy = "";
                    //org.CreatedDate = DateTime.UtcNow;
                    //org.UpdatedDate = DateTime.UtcNow;
                }
                await _repoOrganization.Add(org);
                await _repoOrganization.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: OrganizationController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var org = await _repoOrganization.GetById(id);
            if (org == null)
            {
                return NotFound();
            }
            return View(org);
        }

        // POST: OrganizationController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, IFormCollection collection)
        {
            try
            {
                var Org = new Organization();

                await TryUpdateModelAsync<Organization>(Org);
                if (id != Org.Id)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    Org.UpdatedBy = "";
                    Org.UpdatedDate = DateTime.UtcNow;
                    _repoOrganization.Update(Org);
                    await _repoOrganization.SaveChanges();
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: OrganizationController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var org = await _repoOrganization.GetById(id);
            if (org == null)
            {
                return NotFound();
            }
            return View(org);
        }

        // POST: OrganizationController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, IFormCollection collection)
        {
            try
            {
                if (id > 0)
                {
                    var org = await _repoOrganization.GetById(id);
                    _repoOrganization.Delete(org);
                    await _repoOrganization.SaveChanges();
                }
                else {
                    return NotFound();
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
