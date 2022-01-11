using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Employee
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string EmpCode { get; set; }
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }
        [Required]
        public int DesignationId { get; set; }//FK
        [Required]
        public DateTime Dob { get; set; }
        [Required]
        public DateTime JoiningDate { get; set; }
        public DateTime LastWorkingDate { get; set; }
        public int WorkLocationId { get; set; }//FK
        [Required]
        public int Gender { get; set; }
        public int MaritalSatus { get; set; }//Enum
        public string Address { get; set; }
        [MaxLength(20)]
        [MinLength(10)]
        public string emergencyContactNo { get; set; }

        public string Skillset { get; set; }

        public int ReportingManagerId { get; set; }
        [Required]
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
