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
    [Authorize(Roles = "Admin")]
    public class WorkLocationController : Controller
    {
        private readonly IWorkLocationRepository _repoWorkLocation;
        private readonly IEmployeeRepository _repoEmployee;
        public WorkLocationController(IWorkLocationRepository repoWorkLocation, IEmployeeRepository repoEmployee)
        {
            _repoWorkLocation = repoWorkLocation;
            _repoEmployee = repoEmployee;
        }
        // GET: WorkLocationController
        public async Task<IActionResult> Index()
        {
            return View(await _repoWorkLocation.GetWorkLocationList());
        }


        // GET: WorkLocationController/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: WorkLocationController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name", "Address", "ContactNumber")] WorkLocation location)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);// will give the user's userId
                    location.OrgnizationId = _repoEmployee.GetCurrentOrgId(userId);
                    location.CreatedDate = DateTime.UtcNow;
                    location.UpdatedDate = DateTime.UtcNow;

                    await _repoWorkLocation.Add(location);
                    await _repoWorkLocation.SaveChanges();
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(location);
            }
        }

        // GET: WorkLocationController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id > 0)
            {
                var location = await _repoWorkLocation.GetById(id);
                if (location == null)
                    return NotFound();
                return View(location);
            }
            else
            {
                return NotFound();
            }
            //return View();
        }

        // POST: WorkLocationController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, IFormCollection collection)
        {
            try
            {
                var location = new WorkLocation();
                int count = 0;
                await TryUpdateModelAsync<WorkLocation>(location);
                if (id != location.Id)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    location.UpdatedDate = DateTime.UtcNow;
                    _repoWorkLocation.Update(location);
                    count = await _repoWorkLocation.SaveChanges();
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: WorkLocationController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id > 0)
            {
                var location = await _repoWorkLocation.GetById(id);
                if (location == null)
                    return NotFound();
                //return View(location);
            }
            else
            {
                return NotFound();
            }
            return View();
        }

        // POST: WorkLocationController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, IFormCollection collection)
        {
            try
            {
                if (id > 0)
                {
                    var location = await _repoWorkLocation.GetById(id);
                    _repoWorkLocation.Delete(location);
                    await _repoWorkLocation.SaveChanges();
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
