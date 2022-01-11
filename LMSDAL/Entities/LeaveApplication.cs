using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class LeaveApplication
    {
        public int Id { get; set; }
        [Required]
        public string UserId { get; set; }//FK
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        public bool FirstDayHalf { get; set; }
        public bool LastDayHalf { get; set; }
        [Required]
        public double NoOfLeaves { get; set; }
        //public string RptManagerId { get; set; }//FK
        public string LeaveReason { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        //[ForeignKey("EmployeeId")]
        ////[InverseProperty("EmployeeInfo")]
        //public Employee Employee { get; set; }
        //[ForeignKey("RptManagerId")]
        ////[InverseProperty("EmployeeInfo")]
        //public Employee Employee2 { get; set; }
    }
}
