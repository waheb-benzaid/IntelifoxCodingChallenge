using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntelifoxCodingChallenge.Core.Models
{
    public class User
    {   
        public int UserId { get; set; }
        [Required]
        public string Firstname { get; set; }
        public string Lastname { get; set; }

        [Required,EmailAddress]
        public string Email { get; set; }
        public string Password { get; set; }
        [Required]
        public string Address { get; set; }

        // A user has one-to-many relationship with "Article", that means a user can have multiple articles
        // so I defined a list of articles in the user model! 
       // public List<Article> Articles { get; set; }

    }
}
