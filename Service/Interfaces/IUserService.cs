using Model;
using Repository.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace FixesBusiness
{
    public interface IUserService
    {
        public Task<UserViewModel> GetUserProfile(int userId);
        public Task<List<UserViewModel>> FindUsersByName(string name);
        public Task<bool> UploadProfilePicture(Stream file, int userId);
    }
}
