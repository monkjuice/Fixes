using System;
using System.Collections.Generic;
using System.Text;

namespace FixesBusiness.ViewModels
{
    public class MessageViewModel
    {
        public int UserId { get; set; }

        public string Body { get; set; }

        public DateTime CreatedAt { get; set; }

    }
}
