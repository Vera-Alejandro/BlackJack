using System;
using System.Threading.Tasks;
using Blackjack.Data;
using Blackjack.Data.DAO;
using Microsoft.Data.SqlClient;

namespace Blackjack.GamePlay
{
    public partial class GameInstance
    {
        private UserProfileService UserProfileService { get; set; } = new UserProfileService();
        
        public async Task<UserProfile> SignUpPlayer(UserProfile UserProfile)
        {
            var newPlayer = await UserProfileService.SignUp(UserProfile);

            if (String.IsNullOrEmpty(newPlayer.Id.ToString()))
            {
                throw new Exception("Player returned with an invalid ID");
            }

            return newPlayer;
        }

        public bool IfPlayerExists(string Username)
        {
            return UserProfileService.DoesPlayerExist(Username);
        }
    }
}