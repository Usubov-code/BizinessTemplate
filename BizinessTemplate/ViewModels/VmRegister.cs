using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BizinessTemplate.ViewModels
{
    public class VmRegister
    {
        [MaxLength(50),Required]
        public string FullName { get; set; }
        [MaxLength(50), Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public string UserName { get; set; }

        [MaxLength(50), Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [MaxLength(50), Required]
        [DataType(DataType.Password)]
        [Compare(nameof(Password))]
        public string RePassword { get; set; }
    }
}
