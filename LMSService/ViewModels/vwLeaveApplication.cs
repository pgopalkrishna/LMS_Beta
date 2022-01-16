using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMSService.ViewModels
{
    public class vwLeaveApplication
    {
        public int Id { get; set; }
        [Required]
        public int EmployeeId { get; set; }//FK
        
        [Display(Name = "Employee Name")]
        public string EmployeeName { get; set; }
        [Required]
        public int LeaveTypeId { get; set; }//FK
        
        [Display(Name = "Leave Type Name")]
        public string LeaveTypeName { get; set; }
        [Required]
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }
        [Required]
        [Display(Name = "End Date")]
        public DateTime EndDate { get; set; }
        [Display(Name = "First Day Half")]
        public bool FirstDayHalf { get; set; }
        [Display(Name = "Last Day Half")]
        public bool LastDayHalf { get; set; }
        [Display(Name = "No Of Leaves")]
        [Required]
        public double NoOfLeaves { get; set; }
        //public int RptManagerId { get; set; }//FK
        [Display(Name = "Leave Reason")]
        public string LeaveReason { get; set; }
        
        public int Status { get; set; }

    }
}
