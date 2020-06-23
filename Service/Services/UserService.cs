using Model;
using Repository.Interfaces;
using Repository.Repositories;
using Repository.ViewModels;
using System.Collections.Generic;
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

    }
}



