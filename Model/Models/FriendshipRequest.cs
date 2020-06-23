using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace Model
{
    public class FriendshipRequest
    {
        public int Id { get; set; }

        [ForeignKey("FromUser")]
        public int FromUserId { get; set; }
        [Required]
        public virtual User FromUser { get; set; }

        [ForeignKey("ToUser")]
        public int ToUserId { get; set; }
        [Required]
        public virtual User ToUser { get; set; }

    }

}
