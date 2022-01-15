using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMSService.ViewModels
{
    public class vwEmployee
    {
        public int Id { get; set; }
       [Display(Name = "Employee Code")]
        public string EmpCode { get; set; }
        [Required]
        [MaxLength(50)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(50)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        public string EmailId { get; set; }
        [Required]
        public string Designation { get; set; }
        [Required]
        public DateTime Dob { get; set; }
        [Required]
        [Display(Name = "Work Location")]
        public string WorkLocation { get; set; }
        [Required]
        [Display(Name = "Reporting Manager")]
        public string ReportingManager { get; set; }
        [Required]
        
        public string Status { get; set; }//Enum
    }
}
