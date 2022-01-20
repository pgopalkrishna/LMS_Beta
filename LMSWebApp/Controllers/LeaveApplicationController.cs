using Entities;
using LMSService.Enums;
using LMSService.Interfaces;
using LMSService.ViewModels;
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
    [Authorize(Roles = "User,Admin,ReportingMgr")]
    public class LeaveApplicationController : Controller
    {
        private readonly ILeaveApplicationRepository _repoLeaveApplicationRepository;
        private readonly ILeaveApplicationDetailRepository _repoleaveApplicationDetailRepository;
        private readonly ILeaveTypeRepository _repoLeaveTypeRepository;
        private readonly IEmployeeRepository _repoEmployeeRepository;
        private readonly ILeaveTransactionRepository _repoLeaveTransactionRepository;
        public LeaveApplicationController(ILeaveApplicationRepository repoLeaveApplicationRepository,
            ILeaveApplicationDetailRepository repoleaveApplicationDetailRepository,
            ILeaveTypeRepository repoLeaveTypeRepository,
            IEmployeeRepository repoEmployeeRepository,
            ILeaveTransactionRepository repoLeaveTransactionRepository)
        {
            _repoLeaveApplicationRepository = repoLeaveApplicationRepository;
            _repoleaveApplicationDetailRepository = repoleaveApplicationDetailRepository;
            _repoLeaveTypeRepository = repoLeaveTypeRepository;
            _repoEmployeeRepository = repoEmployeeRepository;
            _repoLeaveTransactionRepository = repoLeaveTransactionRepository;
        }
        // GET: LeaveApplicationController
        public async Task<ActionResult> Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            ViewBag.HasReportingMgr = _repoEmployeeRepository.GetList().Result.ToList().Where(e => e.UserId == userId).FirstOrDefault().ReportingManagerId > 0 ? true : false;
            return View(await _repoLeaveApplicationRepository.GetVwLeaveApplication());
        }

        // GET: LeaveApplicationController/Create
        public ActionResult Create()
        {
            ViewBag.leaveTypes = _repoLeaveTypeRepository.GetList().Result.Select(s => new { LeaveTypeId = s.Id, Name = s.Name }).ToList();

            return View();
        }

        // POST: LeaveApplicationController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("LeaveTypeId", "StartDate", "EndDate", "FirstDayHalf", "LastDayHalf", "LeaveReason")] vwLeaveApplication leave)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var leaveApplication = new LeaveApplication();
                    var UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                    leaveApplication.EmployeeId = _repoEmployeeRepository.GetList().Result.Where(e => e.UserId == UserId).FirstOrDefault().Id;
                    leaveApplication.LeaveTypeId = leave.LeaveTypeId;
                    _repoLeaveApplicationRepository.Add(leaveApplication);
                    int leaveCount = _repoLeaveApplicationRepository.SaveChanges().Result;
                    if (leaveCount > 0)
                    {
                        //No Of leave calculation
                        var NOOfLeaves = 0.0;
                        var daysdiff = leave.EndDate.Subtract(leave.StartDate);
                        if (daysdiff.TotalDays+1 > 0)
                        {
                            NOOfLeaves = daysdiff.TotalDays+1;
                            if (leave.FirstDayHalf)
                                NOOfLeaves = NOOfLeaves - 0.5;
                            if (leave.LastDayHalf)
                                NOOfLeaves = NOOfLeaves - 0.5;
                        }
                        var applicationDetails = new LeaveApplicationDetail()
                        {
                            LeaveApplicationId = leaveApplication.Id,
                            StartDate = leave.StartDate,
                            EndDate = leave.EndDate,
                            FirstDayHalf = leave.FirstDayHalf,
                            LastDayHalf = leave.LastDayHalf,
                            NoOfLeaves = NOOfLeaves,
                            LeaveReason = leave.LeaveReason,
                            CreatedDate = DateTime.UtcNow,
                            CreatedBy = User.FindFirstValue(ClaimTypes.NameIdentifier),
                            UpdatedDate = DateTime.UtcNow
                        };

                        _repoleaveApplicationDetailRepository.Add(applicationDetails);
                        int leaveDetailCount = _repoLeaveApplicationRepository.SaveChanges().Result;
                        if (leaveDetailCount > 0)
                        {
                            var leaveRegister = new LeaveTransaction();
                            leaveRegister.LeaveApplicationId = leaveApplication.Id;
                            leaveRegister.LeaveStatus = (int)LeaveStatusEnum.APPLIED;
                            leaveRegister.OrgnanizationId = _repoEmployeeRepository.GetCurrentOrgId(UserId);
                            _repoLeaveTransactionRepository.Add(leaveRegister);
                            int LeaveRegrCount = _repoLeaveTransactionRepository.SaveChanges().Result;
                            if (LeaveRegrCount > 0) { }
                            else
                            {
                                ModelState.AddModelError("error", "Something went wrong.");
                                return View(leave);
                            }
                        }
                        else
                        {
                            //write code to delete leave application
                            ModelState.AddModelError("error", "Something went wrong.");
                            return View(leave);
                        }
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            catch(Exception e)
            {
                ViewBag.leaveTypes = _repoLeaveTypeRepository.GetList().Result.Select(s => new { LeaveTypeId = s.Id, Name = s.Name }).ToList();
                ModelState.AddModelError("error", "Something went wrong.");
                return View(leave);
            }
        }

        // GET: LeaveApplicationController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: LeaveApplicationController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: LeaveApplicationController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: LeaveApplicationController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
