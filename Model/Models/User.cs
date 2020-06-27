using System;
using System.Diagnostics;

namespace Model
{
    public class User
    {
        public int Id { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public string ProfilePicturePath { get; set; }

        public string Salt { get; set; }

        public DateTime CreatedAt { get; set; }
    }

}
