using Entities;
using LMSService.Enums;
using LMSService.Interfaces;
using LMSWebApp.Areas.Identity.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace LMSWebApp.Controllers
{
    [Authorize(Roles ="Admin")]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository _repoEmployee;
        private readonly IDesignationRepository _repoDesignation;
        private readonly IWorkLocationRepository _repoWorkLocation;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<EmployeeController> _logger;
        public EmployeeController(IEmployeeRepository repoEmployee,
            IDesignationRepository repoDesignation,
            IWorkLocationRepository repoWorkLocation,
            UserManager<ApplicationUser> userManager,
            ILogger<EmployeeController> logger)
        {
            _repoEmployee = repoEmployee;
            _repoDesignation = repoDesignation;
            _repoWorkLocation = repoWorkLocation;
            _userManager = userManager;
            _logger = logger;
        }
        // GET: EmployeeController
        public async Task<ActionResult> Index()
        {
            return View(await _repoEmployee.GetvwEmployeeList());
        }

        //// GET: EmployeeController/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        // GET: EmployeeController/Create
        public ActionResult Create()
        {
            ViewBag.designations = _repoDesignation.GetList().Result.ToList().Select(s => new { DesignationId = s.Id, Name = s.Name }).ToList();
            ViewBag.workLocations = _repoWorkLocation.GetList().Result.ToList().Select(s => new { WorkLocationId = s.Id, Name = s.Name }).ToList();
            var mgrs = _repoEmployee.GetManagersList().Result.ToList().Select(s => new { ReportingManagerId = s.Id, Name = (s.FirstName + " " + s.LastName) }).ToList();
            if (mgrs.Count() == 0)
            {
                mgrs.Add(new { ReportingManagerId = 0, Name = "Not Assigned" });
            }
            ViewBag.managers = mgrs;
            return View();
        }

        // POST: EmployeeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind("FirstName", "LastName", "EmailId", "DesignationId", "Dob", "JoiningDate", "WorkLocationId", "Gender", "MaritalSatus", "Address", "emergencyContactNo", "Skillset", "ReportingManagerId", "Status")] Employee employee)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                    var IsExist = _repoEmployee.GetList().Result.Where(e => e.EmailId == employee.EmailId).ToList().Count() > 0 ? true : false;
                    if (IsExist)
                    {
                        ModelState.AddModelError("error", "User Already Exist.");
                    }
                    employee.OrgnizationId = _repoEmployee.GetCurrentOrgId(userId);
                    employee.UserId = "";
                    string acronym = string.Join(string.Empty, _repoEmployee.GetCurrentOrg(userId)[1].ToString().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(s => s[0]));
                    employee.EmpCode = acronym + "00" + _repoEmployee.GetList().Result.Count();
                    employee.CreatedDate = DateTime.UtcNow;
                    employee.UpdatedDate = DateTime.UtcNow;
                    //employee.ReportingManagerId = 0;
                    employee.Status = (int)EmployeeStatusEnum.ACTIVE;
                    //add employee 
                    await _repoEmployee.Add(employee);
                    var empCount = await _repoEmployee.SaveChanges();
                    if (empCount > 0)
                    {
                        _logger.LogInformation("added employee successfully.");
                    }
                    else
                    {
                        //write code to delete employee
                        ModelState.AddModelError("error", "Something went wrong.");
                        return View(employee);
                    }
                    //add create login user & get userId

                    var user = new ApplicationUser { UserName = employee.EmailId, Email = employee.EmailId, FirstName = employee.FirstName, LastName = employee.LastName };
                    var result = await _userManager.CreateAsync(user, "Password@123");
                    if (result.Succeeded)
                    {
                        _logger.LogInformation("login user created successfully.");
                        //update employee with userId
                        employee.UserId = user.Id;
                        _repoEmployee.Update(employee);
                        var count = await _repoEmployee.SaveChanges();
                        if (count <= 0)
                        {
                            //write code to delete employee
                            ModelState.AddModelError("error", "Something went wrong.");
                            return View(employee);
                        }
                        var resultUserRole = await _userManager.AddToRoleAsync(user, "User");
                        //code to set mgr role
                        if (employee.ReportingManagerId > 0)
                        {
                            var MgrUserId = _repoEmployee.GetById(employee.ReportingManagerId).Result.UserId;
                            var MgrLoginUser = _userManager.FindByIdAsync(MgrUserId).Result;
                            var HasMgrRole = _userManager.IsInRoleAsync(MgrLoginUser, "ReportingMgr").Result;
                            if (!HasMgrRole)
                            {
                                var resultRoles = await _userManager.AddToRoleAsync(MgrLoginUser, "ReportingMgr");
                            }
                        }

                    }

                }
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                _logger.LogError(ex.InnerException.Message);
                ViewBag.designations = _repoDesignation.GetList().Result.ToList().Select(s => new { DesignationId = s.Id, Name = s.Name }).ToList();
                ViewBag.workLocations = _repoWorkLocation.GetList().Result.ToList().Select(s => new { WorkLocationId = s.Id, Name = s.Name }).ToList();
                var mgrs = _repoEmployee.GetManagersList().Result.ToList().Select(s => new { ReportingManagerId = s.Id, Name = (s.FirstName + " " + s.LastName) }).ToList();
                if (mgrs.Count == 0)
                {
                    mgrs.Add(new { ReportingManagerId = 0, Name = "Not Assigned" });
                }
                ViewBag.managers = mgrs;
                ModelState.AddModelError("error", "Something went wrong.");
                return View(employee);
            }
        }

        // GET: EmployeeController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            if (id > 0)
            {
                var employee = await _repoEmployee.GetById(id);
                if (employee == null)
                    return NotFound();
                ViewBag.designations = _repoDesignation.GetList().Result.ToList().Select(s => new { DesignationId = s.Id, Name = s.Name }).ToList();
                ViewBag.workLocations = _repoWorkLocation.GetList().Result.ToList().Select(s => new { WorkLocationId = s.Id, Name = s.Name }).ToList();
                var mgrs = _repoEmployee.GetManagersList().Result.ToList().Select(s => new { ReportingManagerId = s.Id, Name = (s.FirstName + " " + s.LastName) }).ToList();
                if (mgrs.Count == 0)
                {
                    mgrs.Add(new { ReportingManagerId = 0, Name = "Not Assigned" });
                }
                ViewBag.managers = mgrs;
                return View(employee);
            }
            else
            {
                return NotFound();
            }
            //return View();
        }

        // POST: EmployeeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, IFormCollection collection)
        {
            try
            {
                var employee = new Employee();
                int count = 0;
                await TryUpdateModelAsync<Employee>(employee);
                if (id != employee.Id)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    employee.UpdatedDate = DateTime.UtcNow;
                    _repoEmployee.Update(employee);
                    count = await _repoEmployee.SaveChanges();
                    if (count > 0)
                    {
                        var user = _userManager.FindByIdAsync(employee.UserId).Result;
                        if (employee.FirstName != user.FirstName)
                        {
                            user.FirstName = employee.FirstName;
                        }
                        if (employee.LastName != user.LastName)
                        {
                            user.LastName = employee.LastName;
                        }
                        if (employee.Status != (int)EmployeeStatusEnum.ACTIVE)
                        {
                            user.LockoutEnabled = true;
                        }
                        var result = await _userManager.UpdateAsync(user);
                        //code to set mgr role
                        var MgrUserId = _repoEmployee.GetById(employee.ReportingManagerId).Result.UserId;
                        var MgrLoginUser = _userManager.FindByIdAsync(MgrUserId).Result;
                        var HasMgrRole = _userManager.IsInRoleAsync(MgrLoginUser, "ReportingMgr").Result;
                        if (!HasMgrRole)
                        {
                            var resultRoles = await _userManager.AddToRoleAsync(MgrLoginUser, "ReportingMgr");
                        }

                        if (result.Succeeded)
                        {
                            _logger.LogInformation("login user updated successfully.");
                        }
                        else
                        {
                            _logger.LogInformation(result.Errors.Select(err => new { msg = err.Code + " : " + err.Description }).FirstOrDefault().msg);
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("error", "Something went wrong.");
                        return View(employee);
                    }

                }
                ViewBag.designations = _repoDesignation.GetList().Result.ToList().Select(s => new { DesignationId = s.Id, Name = s.Name }).ToList();
                ViewBag.workLocations = _repoWorkLocation.GetList().Result.ToList().Select(s => new { WorkLocationId = s.Id, Name = s.Name }).ToList();
                var mgrs = _repoEmployee.GetManagersList().Result.ToList().Select(s => new { ReportingManagerId = s.Id, Name = (s.FirstName + " " + s.LastName) }).ToList();
                if (mgrs.Count == 0)
                {
                    mgrs.Add(new { ReportingManagerId = 0, Name = "Not Assigned" });
                }
                ViewBag.managers = mgrs;
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ViewBag.designations = _repoDesignation.GetList().Result.ToList().Select(s => new { DesignationId = s.Id, Name = s.Name }).ToList();
                ViewBag.workLocations = _repoWorkLocation.GetList().Result.ToList().Select(s => new { WorkLocationId = s.Id, Name = s.Name }).ToList();
                var mgrs = _repoEmployee.GetManagersList().Result.ToList().Select(s => new { ReportingManagerId = s.Id, Name = (s.FirstName + " " + s.LastName) }).ToList();
                return View();
            }
        }

        //// GET: EmployeeController/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: EmployeeController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
