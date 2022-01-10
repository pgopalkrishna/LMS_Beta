using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class LeaveApplication
    {
        public int Id { get; set; }
        public string UserId { get; set; }//FK
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool FirstDayHalf { get; set; }
        public bool LastDayHalf { get; set; }
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
