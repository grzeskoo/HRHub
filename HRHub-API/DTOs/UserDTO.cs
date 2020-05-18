using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HRHub_API.DTOs
{
    public class UserDTO
    {
        [Required]
        [EmailAddress]
        public string EmailAddress { get; set; }
        [Required]
        [StringLength(50, ErrorMessage ="limited to 50", MinimumLength  = 8)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
