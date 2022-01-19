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
        [Display(Name = "User Id")]
        public string UserId { get; set; }
        public string EmpCode { get; set; }
        [Required]
        [MaxLength(50)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(50)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        [Display(Name = "Email Id")]
        public string EmailId { get; set; }
        [Required]
        [Display(Name = "Designation Id")]
        public int DesignationId { get; set; }//FK
        [Required]
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        [DataType(DataType.Date, ErrorMessage = "Date only")]
        [Display(Name = "Date of Birth")]
        //[DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Dob { get; set; }
        [Required]
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        [DataType(DataType.Date, ErrorMessage = "Date only")]
        [Display(Name = "Joining Date")]
        //[DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime JoiningDate { get; set; }
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        [DataType(DataType.Date, ErrorMessage = "Date only")]
        [Display(Name = "Last Working Date")]
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]

        public DateTime LastWorkingDate { get; set; }
        [Display(Name = "Work Location Id")]
        public int WorkLocationId { get; set; }//FK
        [Required]
        public int Gender { get; set; }
        [Display(Name = "Marital Status")]
        public int MaritalSatus { get; set; }//Enum
        public string Address { get; set; }
        [MaxLength(20)]
        [MinLength(10)]
        [Display(Name = "Emergency Contact No")]
        public string EmergencyContactNo { get; set; }

        public string Skillset { get; set; }
        [Display(Name = "Reporting Manager ")]
        public int ReportingManagerId { get; set; }
        [Required]
        [Display(Name = "Organization")]
        public int OrgnizationId { get; set; }//FK
        public int Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public virtual ICollection<LeaveType> LeaveTypes { get; set; }
        //public virtual ICollection<Employee> employee { get; set; }
        [ForeignKey("DesignationId")]
        //[InverseProperty("DesignationInfo")]
        public virtual Designation Designation { get; set; }

        [ForeignKey("WorkLocationId")]
        //[InverseProperty("WorkLocationInfo")]
        public virtual WorkLocation workLocation { get; set; }
        [ForeignKey("OrgnizationId")]
        //[InverseProperty("OrganizationInfo")]
        public virtual Organization Organization { get; set; }



    }
}
