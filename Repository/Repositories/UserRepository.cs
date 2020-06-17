using Model;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.Repositories
{
    public class UserRepository : FixesRepository, IUserRepository
    {
       public User Register(User user)
       {
            try
            {
                Context.User.Add(user);

                Context.SaveChanges();

                return user;
            }
            catch(Exception e)
            {
                // we need the logger
                return null;
            }
       }


        public User GetUserByUserName(string username)
        {
            try
            {
                return Context.User.Where(x => x.UserName == username).FirstOrDefault();
            }
            catch(Exception e)
            {
                // dev logger
                return null;
            }
        }
    }



}
