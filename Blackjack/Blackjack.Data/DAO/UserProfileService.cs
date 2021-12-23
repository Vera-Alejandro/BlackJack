using System;
using System.Linq;
using System.Threading.Tasks;
using Blackjack.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Blackjack.Data.DAO
{
    public class UserProfileService
    {
        private readonly BlackjackContext _context;

        public UserProfileService()
        {
            _context = new BlackjackContext();
        }

        public bool DoesPlayerExist(string Username)
        {
            return _context.UserProfile.Any(u => u.Username == Username);
        }

        public async Task<UserProfile> SignUp(UserProfile UserProfile)
        {
            _context.UserProfile.Add(UserProfile);

            await _context.SaveChangesAsync();
            
            return await _context.UserProfile.Where(u => u.Username == UserProfile.Username).FirstOrDefaultAsync();
        }

        public async Task<UserProfile> LogIn(UserProfile UserProfile)
        {
            //TODO: this could be more secure, but this will work for now
            var playerProfile = await _context.UserProfile.SingleAsync(u => u.Username == UserProfile.Username);

            if (playerProfile.Password != UserProfile.Password)
                throw new InvalidPasswordException();

            return playerProfile;
        }
    }

    public class InvalidPasswordException : Exception
    { }
}