using Model;
using Repository.Interfaces;
using Repository.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FixesBusiness
{
    public class FriendshipService : IFriendshipService
    {
        private readonly IUserRepository userRepository;
        private readonly IFriendshipRepository friendshipRepository;

        public FriendshipService()
        {
            userRepository = new UserRepository();
            friendshipRepository = new FriendshipRepository();
        }

        async public Task<FriendshipRequest> GetFriendshipRequest(int requestId)
        {
            return await friendshipRepository.GetFriendshipRequest(requestId);
        }

        async public Task<List<FriendshipRequest>> GetFriendshipRequestList(int userId)
        {
            var user = await userRepository.GetUser(userId);

            return await friendshipRepository.GetFriendshipRequestList(user);
        }

        async public Task<bool> CreateRequest(int fromUserId, int toUserId)
        {
            if (await CheckExistingRequest(fromUserId, toUserId) || await CheckExistingFriendship(fromUserId, toUserId))
                return false;

            var fromUser = await userRepository.GetUser(fromUserId);

            if(fromUser == null)
                return false;
            
            var toUser = await userRepository.GetUser(toUserId);

            if(toUser == null)
                return false;

            var request = new FriendshipRequest();
            request.FromUserId = fromUser.Id;
            request.ToUserId = toUser.Id;

            await friendshipRepository.SaveRequest(request);

            return true;
        }

        async public Task<bool> AcceptRequest(int requestId)
        {

            FriendshipRequest request = await friendshipRepository.GetFriendshipRequest(requestId);

            if (request == null || await CheckExistingFriendship(request.FromUserId, request.ToUserId))
                return false;

            Friendship friendship = new Friendship();
            friendship.UserAId = request.FromUserId;
            friendship.UserBId = request.ToUserId;

            var success = await friendshipRepository.SaveFriendship(friendship);

            if (success)
            {
                friendshipRepository.DeleteRequest(request);
                return true;
            }

            return false;
        }

        async public Task<bool> DeleteRequest(int requestId)
        {
            var request = await friendshipRepository.GetFriendshipRequest(requestId);

            if(request != null)
            {
                friendshipRepository.DeleteRequest(request);
                return true;
            }

            return false;
        }

        async public Task<bool> CheckExistingRequest(int fromId, int toId)
        {
            return await friendshipRepository.CheckExistingRequest(fromId, toId);
        }

        async public Task<bool> CheckExistingFriendship(int aId, int bId)
        {
            return await friendshipRepository.CheckExistingFriendship(aId, bId);
        }

    }
}



