using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FixesAPI.ViewModels.Requests
{
    public class UploadProfilePicture
    {
        [Required]
        public IFormFile Image { get; set; }
    }
}
