using System;
using System.ComponentModel.DataAnnotations;

namespace FixesAPI
{
    public class AcceptFriendshipViewModel
    {
        [Required]
        public int RequestId { get; set; } 
    }
}
