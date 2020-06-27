using System;
using System.ComponentModel.DataAnnotations;

namespace FixesAPI
{
    public class AuthenticationViewModel
    {
        [Required]
        public string UserName { get; set; }
     
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } 
    }
}
