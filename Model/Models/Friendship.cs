using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace Model
{
    public class Friendship
    {
        public int Id { get; set; }

        [ForeignKey("UserA")]
        public int UserAId { get; set; }
        [Required]
        public virtual User UserA { get; set; }

        [ForeignKey("UserB")]
        public int UserBId { get; set; }
        [Required]
        public virtual User UserB { get; set; }

    }

}
