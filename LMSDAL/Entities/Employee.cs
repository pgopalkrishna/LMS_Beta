using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string EmpCode { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int DesignationId { get; set; }//FK
        public DateTime Dob { get; set; }
        public DateTime JoiningDate { get; set; }
        public DateTime LastWorkingDate { get; set; }
        public int WorkLocationId { get; set; }//FK
        public int Gender { get; set; }
        public int MaritalSatus { get; set; }
        public string Address { get; set; }
        public string emergencyContactNo { get; set; }
        public string Skillset { get; set; }
        public int ReportingManagerId { get; set; }
        public int OrgnizationId { get; set; }//FK
        public int Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }

        [ForeignKey("DesignationId")]
        //[InverseProperty("DesignationInfo")]
        public Designation Designation { get; set; }

        [ForeignKey("WorkLocationId")]
        //[InverseProperty("WorkLocationInfo")]
        public WorkLocation workLocation { get; set; }
        [ForeignKey("OrgnizationId")]
        //[InverseProperty("OrganizationInfo")]
        public Organization Organization { get; set; }



    }
}
