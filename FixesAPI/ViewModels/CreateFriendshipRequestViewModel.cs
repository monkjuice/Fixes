using System;
using System.ComponentModel.DataAnnotations;

namespace FixesAPI
{
    public class CreateFriendshipRequestViewModel
    {
        [Required]
        public int ToUserId { get; set; } 
    }
}
