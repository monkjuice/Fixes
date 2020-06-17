using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Model;

namespace FixesAPI.Mappers
{
    public class UserMapper
    {

        public static User Map(AuthenticationViewModel viewModel)
        {
            var user = new User();
            user.UserName = viewModel.UserName;
            user.Password = viewModel.Password;
            return user;
        }

    }
}
