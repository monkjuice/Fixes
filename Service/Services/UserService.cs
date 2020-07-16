using FixesBusiness.Utils;
using Model;
using Repository.Interfaces;
using Repository.Repositories;
using Repository.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FixesBusiness
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;

        public UserService()
        {
            userRepository = new UserRepository();
        }

        async public Task<List<UserViewModel>> FindUsersByName(string name)
        {
            if (Regex.IsMatch(name, "^[a-zA-Z0-9_]*$")) 
            { 
                return await userRepository.FindUsersByName(name.ToLower().Trim());
            }

            return null;
        }

        async public Task<UserViewModel> GetUserProfile(int userId)
        {
            return await userRepository.GetUserProfile(userId);
        }

        async public Task<string> UploadProfilePicture(Stream file, int userId)
        {
            try
            {
                var user = await userRepository.GetUser(userId);

                if(user != null)
                {
                    string fileName = Guid.NewGuid().ToString() + ".jpg";

                    string path = "https://fixesblob.blob.core.windows.net/profilepictures/" + fileName;

                    var storedFile = await FileStorage.UploadBlob(file, "profilepictures", fileName);

                    if (!storedFile)
                        return null;

                    var storedReference = await userRepository.StoreProfilePicturePath(path, user);

                    if (storedReference)
                        return path;
                }

                return null;

            }
            catch(Exception e)
            {
                return null;
            }
        }
    }
}



