using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMSService.ViewModels
{
    public class vwLeaveType
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(80)]
        public string Name { get; set; }
        public bool IsActive { get; set; }
        [Required]
        public int OrgnizationId { get; set; }
        public string OrgName { get; set; }
        
    }
}
