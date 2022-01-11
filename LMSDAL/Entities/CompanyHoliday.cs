using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class CompanyHoliday
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(80)]
        [MinLength(2)]
        public string HolidayName { get; set; }
        [Required]
        public DateTime HolidayDate { get; set; }
        [Required]
        public int OrgnizationId { get; set; }//FK
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        [ForeignKey("OrgnizationId")]
        //[InverseProperty("OrganizationInfo")]
        public Organization Organization { get; set; }
    }
}
