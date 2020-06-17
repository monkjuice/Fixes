using Repository.Interfaces;
using Repository.Repositories;

namespace FixesBusiness
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;

        public UserService()
        {
            userRepository = new UserRepository();
        }

    }
}



