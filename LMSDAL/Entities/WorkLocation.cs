using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class WorkLocation
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        [MinLength(2)]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        [MaxLength(20)]
        [MinLength(10)]
        public string ContactNumber { get; set; }
        [Required]
        public int OrgnizationId { get; set; }//FK
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        [ForeignKey("OrgnizationId")]
        //[InverseProperty("OrganizationInfo")]
        public virtual Organization Organization { get; set; }
        public virtual ICollection<WorkLocation> WorkLocations { get; set; }
    }
}
