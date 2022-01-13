using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class LeaveTransaction
    {
        public int Id { get; set; }
        [Required]
        public int LeaveApplicationId { get; set; }//FK
        public int LeaveStatus { get; set; }//Enum
        public string Remark { get; set; }
        public string Description { get; set; }
        public DateTime ApprovalDate { get; set; }
        public DateTime RejectionDate { get; set; }
        public string AprrovedBy { get; set; }
        public string RejectedBy { get; set; }
        [ForeignKey("LeaveApplicationId")]
        //[InverseProperty("LeaveApplicationInfo")]
        public virtual LeaveApplication  LeaveApplication { get; set; }
    }
}
