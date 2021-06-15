using System;
using Blackjack.Data;
using Blackjack.Data.DAO;

namespace Blackjack.GamePlay
{
    public partial class GameInstance
    {
        private UserProfileService UserProfileService { get; set; } = new UserProfileService(new BlackjackContext());
        
        public void SignUpPlayer(UserProfile UserProfile)
        {
            if (UserProfile == null) throw new ArgumentNullException(nameof(UserProfile));
            throw new NotImplementedException();
        }

        public bool IfPlayerExists(string Username)
        {
            return UserProfileService.DoesPlayerExist(Username);
        }
    }
}