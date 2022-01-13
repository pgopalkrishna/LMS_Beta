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
    [Authorize]
    public class LeaveTypeController : Controller
    {
        private readonly ILeaveTypeRepository _repoLeaveType;
        private readonly IEmployeeRepository _repoEmployee;
        public LeaveTypeController(ILeaveTypeRepository repo, IEmployeeRepository repoEmployee)
        {
            _repoLeaveType = repo;
            _repoEmployee = repoEmployee;
        }
        // GET: LeaveTypeController
        public async Task<ActionResult> Index()
        {

            return View(await _repoLeaveType.GetLeaveTypeList());
        }

        //// GET: LeaveTypeController/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        // GET: LeaveTypeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LeaveTypeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind("Name", "IsActive")] LeaveType leaveType)
        {
            try
            {
                //leaveType.OrgnizationId = Convert.ToInt32(HttpContext.Session.GetInt32("OrgId"));
                //var UName = User.Identity.Name.ToString();
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);// will give the user's userId
                //var userName = User.FindFirstValue(ClaimTypes.Name);
                leaveType.OrgnizationId = _repoEmployee.GetCurrentOrgId(userId);
                leaveType.IsActive = true;
                leaveType.CreatedDate = DateTime.UtcNow;
                leaveType.UpdatedDate = DateTime.UtcNow;
                if (ModelState.IsValid)
                {
                    await _repoLeaveType.Add(leaveType);
                    await _repoLeaveType.SaveChanges();
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: LeaveTypeController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            if (id <= 0)
            {
                return NotFound();
            }
            var leaveType = await _repoLeaveType.GetById(id);
            if (leaveType == null)
                return NotFound();
            return View(leaveType);
        }

        // POST: LeaveTypeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, IFormCollection collection)
        {
            try
            {
                var leaveType = new LeaveType();
                int count = 0;
                await TryUpdateModelAsync<LeaveType>(leaveType);
                if (id != leaveType.Id)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    leaveType.UpdatedDate = DateTime.UtcNow;
                    _repoLeaveType.Update(leaveType);
                    count = await _repoLeaveType.SaveChanges();
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: LeaveTypeController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var leaveType = await _repoLeaveType.GetById(id);
            if (leaveType == null)
            {
                return NotFound();
            }
            return View(leaveType);
        }

        // POST: LeaveTypeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, IFormCollection collection)
        {
            try
            {
                if (id > 0)
                {
                    var leaveType = await _repoLeaveType.GetById(id);
                    _repoLeaveType.Delete(leaveType);
                    await _repoLeaveType.SaveChanges();
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
