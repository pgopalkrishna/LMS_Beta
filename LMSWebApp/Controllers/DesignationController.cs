using Entities;
using LMSService.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace LMSWebApp.Controllers
{
    [Authorize(Roles ="Admin")]
    public class DesignationController : Controller
    {
        private readonly IDesignationRepository _repoDesignation;
        private readonly IEmployeeRepository _repoEmployee;
        public DesignationController(IDesignationRepository repoDesignation, IEmployeeRepository repoEmployee)
        {
            _repoDesignation = repoDesignation;
            _repoEmployee = repoEmployee;
        }
        // GET: DesignationController
        public async Task<IActionResult> Index()
        {
            return View(await _repoDesignation.GetDesignationList());
        }

        // GET: DesignationController/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DesignationController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name")] Designation designation)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);// will give the user's userId
                    designation.OrgnizationId = _repoEmployee.GetCurrentOrgId(userId);
                    designation.CreatedDate = DateTime.UtcNow;
                    designation.UpdatedDate = DateTime.UtcNow;

                    await _repoDesignation.Add(designation);
                    await _repoDesignation.SaveChanges();
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(designation);
            }
        }

        // GET: DesignationController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id > 0)
            {
                var designation = await _repoDesignation.GetById(id);
                if (designation == null)
                    return NotFound();
                return View(designation);
            }
            else
            {
                return NotFound();
            }
            //return View();
        }

        // POST: DesignationController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, IFormCollection collection)
        {
            try
            {
                var designation = new Designation();
                int count = 0;
                await TryUpdateModelAsync<Designation>(designation);
                if (id != designation.Id)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    designation.UpdatedDate = DateTime.UtcNow;
                    _repoDesignation.Update(designation);
                    count = await _repoDesignation.SaveChanges();
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DesignationController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            if (id > 0)
            {
                var designation = await _repoDesignation.GetById(id);
                if (designation == null)
                    return NotFound();
            }
            else
            {
                return NotFound();
            }
            return View();
        }

        // POST: DesignationController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, IFormCollection collection)
        {
            try
            {
                if (id > 0)
                {
                    var designation = await _repoDesignation.GetById(id);
                    _repoDesignation.Delete(designation);
                    await _repoDesignation.SaveChanges();
                }
                else
                {
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
