using Model;
using Repository.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Interfaces
{
    public interface IAuthenticationService
    {
        public User Register(User mappedRegisterForm);

        public UserViewModel Login(User mappedLoginForm);

        public bool UserNameExists(string UserName);

        public bool CheckCredentials(User mappedLoginForm);
    }
}
