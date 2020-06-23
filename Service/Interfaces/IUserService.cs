using Model;
using Repository.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FixesBusiness
{
    public interface IUserService
    {
        public Task<List<UserViewModel>> FindUsersByName(string name);
    }
}
