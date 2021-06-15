using System.Linq;

namespace Blackjack.Data.DAO
{
    public class UserProfileService
    {
        private readonly BlackjackContext context;

        public UserProfileService(BlackjackContext _context)
        {
            context = _context;
        }

        public bool DoesPlayerExist(string Username)
        {
            return context.UserProfile.Any(u => u.Username == Username);
        }
    }
}