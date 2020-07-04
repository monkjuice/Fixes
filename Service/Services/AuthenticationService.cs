using Model;
using Repository.Interfaces;
using Repository.Repositories;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using FixesBusiness.Utils;
using System.Text;
using Repository.ViewModels;

namespace Service
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IUserRepository userRepository;

        public AuthenticationService()
        {
            userRepository = new UserRepository();
        }

        public User Register(User registerForm)
        {

            User user = new User();

            user.UserName = registerForm.UserName;

            user.Salt = Convert.ToBase64String(Crypto.GetRandomSalt(32));

            user.Password = Convert.ToBase64String(Crypto.EncryptPassword(Encoding.ASCII.GetBytes(registerForm.Password), Convert.FromBase64String(user.Salt)));

            user.CreatedAt = DateTime.Now;

            return userRepository.Register(user);
        }

        public UserViewModel Login(User loginForm)
        {

            var user = userRepository.GetUserByUserName(loginForm.UserName);

            return new UserViewModel()
            {
                UserId = user.Id,
                ProfilePicturePath = user.ProfilePicturePath,
                Username = user.UserName,
            };
        }

    public bool CheckCredentials(User loginForm)
        {

            User user = userRepository.GetUserByUserName(loginForm.UserName);

            if (user == null)
                return false;

            string passwordAttempt = Convert.ToBase64String(Crypto.EncryptPassword(Encoding.ASCII.GetBytes(loginForm.Password), Convert.FromBase64String(user.Salt)));

            if (user.Password == passwordAttempt)
                return true;
            else
                return false;
        }

        public bool UserNameExists(string _username)
        {
            if (userRepository.GetUserByUserName(_username) == null)
                return false;
            else
                return true;
        }

    }
}



