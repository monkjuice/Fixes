using Microsoft.EntityFrameworkCore;
using Model;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class FriendshipRepository : FixesRepository, IFriendshipRepository
    {

        async public Task<FriendshipRequest> GetFriendshipRequest(int requestId)
        {
            try
            {
                var request = await Context.FriendshipRequest.FirstOrDefaultAsync(x => x.Id == requestId);

                if(request != null)
                {
                    return request;
                }

                return null;
            }
            catch(Exception e)
            {
                return null;
            }
        }

        async public Task<List<FriendshipRequest>> GetFriendshipRequestList(User user)
        {
            try
            {
                return await Context.FriendshipRequest.Where(x => x.ToUser.Id == user.Id).ToListAsync();
            }
            catch (Exception e)
            {
                return null;
            }
        }

        async public Task<bool> SaveRequest(FriendshipRequest request)
        {
            try
            {
                Context.FriendshipRequest.Add(request);

                await Context.SaveChangesAsync();

                return true; 
            }
            catch (Exception e)
            {
                // we need the logger
                return false;
            }
        }

        public string DeleteRequest(FriendshipRequest request)
        {
            try
            {
                Context.FriendshipRequest.Remove(request);

                Context.SaveChanges();

                return "Ok";
            }
            catch (Exception e)
            {
                // we need the logger
                return null;
            }
        }

        async public Task<Friendship> GetFriendship(int friendshipId)
        {
            try
            {
                var friendship = await Context.Friendship.FirstOrDefaultAsync(x => x.Id == friendshipId);

                if (friendship != null)
                {
                    return friendship;
                }

                return null;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        async public Task<bool> SaveFriendship(Friendship friendship)
        {
            try
            {
                Context.Friendship.Add(friendship);

                await Context.SaveChangesAsync();

                return true;
            }
            catch (Exception e)
            {
                // we need the logger
                return false;
            }
        }

        public string DeleteFriendship(Friendship friendship)
        {
            return "Ok";
        }

        public List<User> GetFriendList(User user)
        {
            return null;
        }


        async public Task<bool> CheckExistingRequest(int userAId, int userBId)
        {
            var existing = await Context.FriendshipRequest.Where(x =>
            (x.FromUserId == userAId && x.ToUserId == userBId) || (x.FromUserId == userBId && x.ToUserId == userAId)).FirstOrDefaultAsync();

            if (existing == null)
                return false;

            return true;
        }

        async public Task<bool> CheckExistingFriendship(int userAId, int userBId)
        {
            var existing = await Context.Friendship.Where(x =>
            (x.UserAId == userAId && x.UserBId == userBId) || (x.UserAId == userBId && x.UserBId == userAId)).FirstOrDefaultAsync();

            if (existing == null)
                return false;

            return true;
        }

    }



}
