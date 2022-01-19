using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMSService.ViewModels
{
    public class vwLeaveRule
    {
        public int Id { get; set; }
        //[Required]
        [Display(Name = "Leave Type Name")]
        public string LeaveTypeName { get; set; }//FK
                                                 // [Required]
        [Display(Name = "No Of Leaves")]
        public double NoOfLeaves { get; set; }
        //[Required]
        [Display(Name = "Leave Validity")]
        public string LeaveValidity { get; set; }//Enum
        public bool IsCarryForward { get; set; }
        [Display(Name = "Carryforword Cap")]
        public int CarryForwardCap { get; set; }
    }
}
