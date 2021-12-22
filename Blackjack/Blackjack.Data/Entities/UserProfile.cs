using System;

namespace Blackjack.Data.Entities
{
    public class UserProfile
    {
        public Guid PlayerId { get; set; }
        public string PlayerName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}