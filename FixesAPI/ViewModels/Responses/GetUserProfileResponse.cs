using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FixesAPI.ViewModels.Response
{
    public class GetUserProfileResponse : APIResponseViewModel
    {

        public string Username { get; set; }

        public string ProfilePicturePath { get; set; }

    }
}
