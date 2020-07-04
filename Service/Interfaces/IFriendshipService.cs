using Model;
using Repository.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FixesBusiness
{
    public interface IFriendshipService
    {
        public Task<List<UserViewModel>> GetFriendsList(int userId);
        public Task<FriendshipRequest> GetFriendshipRequest(int requestId);
        public Task<List<FriendshipRequest>> GetFriendshipRequestList(int userId);
        public Task<bool> CreateRequest(int fromUserId, int toUserId);
        public Task<bool> AcceptRequest(int requestId);
        public Task<bool> DeleteRequest(int requestId);

    }
}
