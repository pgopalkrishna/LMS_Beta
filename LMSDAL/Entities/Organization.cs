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
        public string OrgnizationName { get; set; }
        [Required]
        [MaxLength(50)]
        public string ContactEmail { get; set; }
        [Required]
        [MaxLength(20)]
        public string ContactNumber { get; set; }
        [Required]
        public string OrgAddress { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public virtual ICollection<Organization> organization { get; set; }
    }
}
