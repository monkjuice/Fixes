using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Service;
using Service.Interfaces;
using FixesAPI.Mappers;

namespace FixesAPI.Validators
{
    public class LoginValidator
    {

        private readonly IAuthenticationService authService;

        public LoginValidator()
        {
            authService = new AuthenticationService();
        }

        public ValidatorViewModel IsValid(AuthenticationViewModel loginForm)
        {
            ValidatorViewModel validator = new ValidatorViewModel();

            if (authService.CheckCredentials(UserMapper.Map(loginForm)))
            {
                validator.Error = false;
                validator.ErrorList = null;
            }
            else
            {
                validator.Error = true;
                validator.ErrorList = new Dictionary<string, string>();
                validator.ErrorList.Add("invalidLogin", "The username/password is invalid");
            }

            return validator;

        }

    }
}
