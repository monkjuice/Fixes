using Model;
using Repository.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IFriendshipRepository
    {
        public Task<FriendshipRequest> GetFriendshipRequest(int requestId);
        public Task<List<FriendshipRequest>> GetFriendshipRequestList(User user);
        public Task<bool> SaveRequest(FriendshipRequest request);
        public string DeleteRequest(FriendshipRequest request);
        public Task<Friendship> GetFriendship(int friendshipId);
        public Task<bool> SaveFriendship(Friendship friendship);
        public string DeleteFriendship(Friendship friendship);
        public Task<List<UserViewModel>> GetFriendsList(int userId);
        public Task<bool> CheckExistingRequest(int userAId, int userBId);
        public Task<bool> CheckExistingFriendship(int userAId, int userBId);
    }
}
