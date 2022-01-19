using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMSService.ViewModels
{
    public class vwOrganization
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        [MinLength(2,ErrorMessage ="Organization Name should be of atleast 2 characters ")]
        [Display(Name = "Organization Name")]
        public string OrgnizationName { get; set; }
        [Required]
        [MaxLength(50)]
        [Display(Name = "Contact Email")]
        public string ContactEmail { get; set; }
        [Required]
        [MaxLength(20)]
        [Display(Name = "Contact Number")]
        public string ContactNumber { get; set; }
        [Required]
        [Display(Name = "Organization Address")]
        public string OrgAddress { get; set; }
    }
}
