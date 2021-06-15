using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Blackjack.Data.DAO
{
    public class UserProfileService
    {
        private readonly BlackjackContext context;

        public UserProfileService()
        {
            context = new BlackjackContext();
        }

        public bool DoesPlayerExist(string Username)
        {
            return context.UserProfile.Any(u => u.Username == Username);
        }

        public async Task<UserProfile> SignUp(UserProfile UserProfile)
        {
            using (var c = new BlackjackContext())
            {
                c.UserProfile.Add(UserProfile);
            }

            return await context.UserProfile.Where(u => u.Username == UserProfile.Username).FirstOrDefaultAsync();
        }
    }
}