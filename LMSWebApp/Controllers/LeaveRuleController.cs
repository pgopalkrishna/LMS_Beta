using Entities;
using LMSService.Enums;
using LMSService.Interfaces;
using LMSService.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace LMSWebApp.Controllers
{
    [Authorize(Roles = "Admin")]
    public class LeaveRuleController : Controller
    {
        private readonly ILeaveRuleRepository _repoleaveRule;
        private readonly IEmployeeRepository _repoEmployee;
        private readonly ILeaveTypeRepository _repoLeaveType;
        public LeaveRuleController(ILeaveRuleRepository repoleaveRule, IEmployeeRepository repoEmployee, ILeaveTypeRepository repoLeaveType)
        {
            _repoleaveRule = repoleaveRule;
            _repoEmployee = repoEmployee;
            _repoLeaveType = repoLeaveType;
        }
        // GET: LeaveRuleController
        public async Task<ActionResult> Index()
        {
            return View(await _repoleaveRule.GetLeaveRuleList());
        }


        // GET: LeaveRuleController/Create
        public async Task<ActionResult> Create()
        {
            List<LeaveType> leaves = (List<LeaveType>)await _repoLeaveType.GetList();
            ViewBag.leaves = leaves.Select(s => new { LeaveId = s.Id, Name = s.Name }).ToList();
            ViewBag.leaveValidity = new SelectList((from LeaveValidityEnum v in Enum.GetValues(typeof(LeaveValidityEnum)) select new { LeaveValidity = (int)v, Name = v.ToString() }), "LeaveValidity", "Name");
            return View();
        }

        // POST: LeaveRuleController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind("LeaveTypeId", "NoOfLeaves", "LeaveValidity", "IsCarryForward", "CarryForwardCap")] LeaveRule leaveRule)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);// will give the user's userId
                    leaveRule.OrganizationId = _repoEmployee.GetCurrentOrgId(userId);
                    leaveRule.CreatedDate = DateTime.UtcNow;
                    leaveRule.UpdatedDate = DateTime.UtcNow;
                    leaveRule.CarryForwardCap = leaveRule.CarryForwardCap > 0 ? leaveRule.CarryForwardCap : 0;
                    await _repoleaveRule.Add(leaveRule);
                    int result = await _repoleaveRule.SaveChanges();
                }
                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                ModelState.AddModelError("errorMsg", "Something went wrong");
                return View(leaveRule);
            }

        }

        // GET: LeaveRuleController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            if (id > 0)
            {
                var leaveRule = await _repoleaveRule.GetById(id);
                List<LeaveType> leaves = (List<LeaveType>)await _repoLeaveType.GetList();
                ViewBag.leaves = leaves.Select(s => new { LeaveId = s.Id, Name = s.Name }).ToList();
                //ViewBag.leaveValidity = new SelectList((from LeaveValidityEnum v in Enum.GetValues(typeof(LeaveValidityEnum)) select new { LeaveValidity = (int)v, Name = v.ToString() }), "LeaveValidity", "Name");
                if (leaveRule == null)
                    return NotFound();
                return View(leaveRule);
            }
            else
            {
                return NotFound();
            }
            //return View();
        }

        // POST: LeaveRuleController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, IFormCollection collection)
        {
            List<LeaveType> leaves = (List<LeaveType>)await _repoLeaveType.GetList();
            ViewBag.leaves = leaves.Select(s => new { LeaveId = s.Id, Name = s.Name }).ToList();
            try
            {
                var leaveRule = new LeaveRule();
                int count = 0;
                await TryUpdateModelAsync<LeaveRule>(leaveRule);
                if (id != leaveRule.Id)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    leaveRule.UpdatedDate = DateTime.UtcNow;
                    _repoleaveRule.Update(leaveRule);
                    count = await _repoleaveRule.SaveChanges();
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: LeaveRuleController/Delete/5
        public ActionResult Delete(int id)
        {
            if (id > 0)
            {
                var leaveRule =  _repoleaveRule.GetvwLeaveRuleById(id);
                if (leaveRule == null)
                    return NotFound();
                return View(leaveRule);
            }
            else
            {
                return NotFound();
            }

            //return View();
        }

        // POST: LeaveRuleController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, IFormCollection collection)
        {
            try
            {
                if (id > 0)
                {
                    var leaveRule = await _repoleaveRule.GetById(id);
                    _repoleaveRule.Delete(leaveRule);
                    await _repoleaveRule.SaveChanges();
                }
                else
                {
                    return NotFound();
                }
                //List<LeaveType> leaves = (List<LeaveType>)await _repoLeaveType.GetList();
                //ViewBag.leaves = leaves.Select(s => new { LeaveId = s.Id, Name = s.Name }).ToList();
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                return View();
            }
        }
    }
}
