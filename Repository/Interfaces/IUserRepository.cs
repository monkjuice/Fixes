using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Interfaces
{
    public interface IUserRepository
    {
        public User Register(User user);

        public User GetUserByUserName(string username);
    }
}
