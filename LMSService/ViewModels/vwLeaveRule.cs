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
        public string LeaveTypeName { get; set; }//FK
       // [Required]
        public double NoOfLeaves { get; set; }
        //[Required]
        public string LeaveValidity { get; set; }//Enum
        public bool IsCarryForward { get; set; }
        public int CarryForwardCap { get; set; }
    }
}
