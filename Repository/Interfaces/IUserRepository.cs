using Model;
using Repository.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IUserRepository
    {
        public Task<List<UserViewModel>> FindUsersByName(string name);

        public User Register(User user);

        public Task<User> GetUser(int userId);

        public User GetUserByUserName(string username);
    }
}
