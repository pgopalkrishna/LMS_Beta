using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class LeaveRule
    {
        public int Id { get; set; }
        public int LeaveTypeId { get; set; }//FK
        public double NoOfLeaves { get; set; }
        public int LeaveValidity { get; set; }//Enum
        public bool IsCarryForward { get; set; }
        public int CarryForwardCap { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        [ForeignKey("LeaveTypeId")]
        //[InverseProperty("LeaveTypeInfo")]
        public LeaveType LeaveType { get; set; }

    }
}
