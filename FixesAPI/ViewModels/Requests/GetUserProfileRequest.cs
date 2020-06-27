using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FixesAPI.ViewModels.Requests
{
    public class GetUserProfileRequest
    {
        [Required]
        public int UserId { get; set; }
    }
}
