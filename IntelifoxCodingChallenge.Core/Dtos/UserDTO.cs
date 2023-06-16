using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntelifoxCodingChallenge.Core.Dtos
{
    public class UserDTO
    {
        public int UserId { get; set; }
        [Required]
        public string Firstname { get; set; }
        public string Lastname { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }
        public string Password { get; set; }
        [Required]
        public string Address { get; set; }
    }
}
