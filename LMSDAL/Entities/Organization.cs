using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Organization
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        [MinLength(2)]
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
        [Display(Name = "Address")]
        public string OrgAddress { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public virtual ICollection<Organization> organization { get; set; }
    }
}
