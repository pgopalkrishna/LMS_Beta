using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Designation
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        [MinLength(2)]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Organization Id")]
        public int OrgnizationId { get; set; }//FK
        
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        [ForeignKey("OrgnizationId")]
        //[InverseProperty("OrganizationInfo")]
        public virtual Organization Organization { get; set; }
        public virtual ICollection<Designation> Designations { get; set; }
    }
}
