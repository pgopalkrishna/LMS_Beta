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
        public string OrgnizationName { get; set; }
        [Required]
        [MaxLength(50)]
        public string ContactEmail { get; set; }
        [Required]
        [MaxLength(20)]
        public string ContactNumber { get; set; }
        [Required]
        public string OrgAddress { get; set; }
    }
}
