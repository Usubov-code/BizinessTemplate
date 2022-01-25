using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BizinessTemplate.Models
{
    public class Service
    {
        [Key]
        public int Id { get; set; }
        
        public string Icon { get; set; }
        [MaxLength(50)]
        public string Title { get; set; }
        [MaxLength(250)]
        public string Content { get; set; }
    }
}
