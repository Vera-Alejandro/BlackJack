using System;
using System.Threading.Tasks;
using Blackjack.Data.DAO;
using Blackjack.Data.Entities;

namespace Blackjack.GamePlay
{
    public class ProfileInteractions
    {
        private UserProfileService UserProfileService { get; set; } = new UserProfileService();
        
        public async Task<UserProfile> SignUpPlayer(UserProfile UserProfile)
        {
            var newPlayer = await UserProfileService.SignUp(UserProfile);
            
            if (newPlayer == null)
                throw new PlayerNotFoundException("There was an issue signing the user up.");

            return newPlayer;
        }

        public bool PlayerExists(string Username)
        {
            return UserProfileService.DoesPlayerExist(Username);
        }

        public async Task<UserProfile> LogInPlayer(UserProfile Player)
        {
            if (!PlayerExists(Player.Username))
            {
                throw new PlayerNotFoundException();
            }

            try
            {
                return await UserProfileService.LogIn(Player);
            }
            catch (InvalidPasswordException)
            {
                throw new FailedLoginException();
            }
            catch (Exception)
            {
                throw new Exception("There was an error logging you in");
            }
        }
    }

    public class FailedLoginException : Exception
    { }

    public class PlayerNotFoundException : Exception
    {
        public PlayerNotFoundException()
        { }
        public PlayerNotFoundException(string message) : base(message)
        { }
    }
}