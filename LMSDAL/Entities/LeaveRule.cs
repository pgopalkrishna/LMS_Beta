using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class LeaveRule
    {
        public int Id { get; set; }
        [Required]
        public int LeaveTypeId { get; set; }//FK
        [Required]
        public double NoOfLeaves { get; set; }
        [Required]
        public int LeaveValidity { get; set; }//Enum
        public bool IsCarryForward { get; set; }
        public int CarryForwardCap { get; set; }
        public int OrganizationId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        [ForeignKey("LeaveTypeId")]
        //[InverseProperty("LeaveTypeInfo")]
        public virtual LeaveType  LeaveType { get; set; }
        [ForeignKey("OrganizationId")]
        //[InverseProperty("LeaveTypeInfo")]
        public virtual Organization Organizations { get; set; }

    }
}
