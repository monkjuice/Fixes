using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Interfaces
{
    public interface IAuthenticationService
    {
        public User Register(User mappedRegisterForm);

        public User Login(User mappedLoginForm);

        public bool UserNameExists(string UserName);

        public bool CheckCredentials(User mappedLoginForm);
    }
}
