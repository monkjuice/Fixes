using Microsoft.EntityFrameworkCore;
using Model;
using Repository.Interfaces;
using Repository.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class UserRepository : FixesRepository, IUserRepository
    {

       async public Task<List<UserViewModel>> FindUsersByName(string name)
        {
            return await Context.User.Where(x => x.UserName.ToLower().Contains(name)).Select(x => new UserViewModel
            {
                Id = x.Id,
                UserName = x.UserName,
            }).ToListAsync();
        }

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

        async public Task<User> GetUser(int userId)
        {
            try
            {
                return await Context.User.Where(x => x.Id == userId).FirstOrDefaultAsync();
            }
            catch (Exception e)
            {
                // dev logger
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

        async public Task<UserViewModel> GetUserProfile(int userId)
        {
            try
            {
                var user = await Context.User.Where(x => x.Id == userId).FirstOrDefaultAsync();

                if(user != null)
                {
                    UserViewModel uvm = new UserViewModel();
                    uvm.UserName = user.UserName;
                    uvm.ProfilePicturePath = user.ProfilePicturePath;
                    return uvm;
                }

                return null;
            }
            catch (Exception e)
            {
                // dev logger
                return null;
            }
        }

        async public Task<bool> StoreProfilePicturePath(string path, User user)
        {
            try
            { 
                user.ProfilePicturePath = path;
                await Context.SaveChangesAsync();
                return true;
            }
            catch(Exception e)
            {
                //dev logger
                return false;
            }
        }
    }



}
