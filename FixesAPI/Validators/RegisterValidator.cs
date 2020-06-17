using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Service;
using Service.Interfaces;

namespace FixesAPI.Validators
{
    public class RegisterValidator
    {

        private readonly IAuthenticationService authService;

        public RegisterValidator()
        {
            authService = new AuthenticationService();
        }

        public ValidatorViewModel IsValid(AuthenticationViewModel registerForm)
        {
            ValidatorViewModel validator = new ValidatorViewModel();

            if (!authService.UserNameExists(registerForm.UserName))
            {
                validator.Error = false;
                validator.ErrorList = null;
            }
            else
            {
                validator.Error = true;
                validator.ErrorList = new Dictionary<string, string>();
                validator.ErrorList.Add("username", "The username already exists");
            }

            return validator;

        }

    }
}
