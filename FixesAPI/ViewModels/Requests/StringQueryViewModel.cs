using System;
using System.ComponentModel.DataAnnotations;

namespace FixesAPI
{
    public class StringQueryViewModel
    {
        [Required]
        [MaxLength(30)]
        public string SearchParam { get; set; } 
    }
}
