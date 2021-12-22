using Blackjack.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Blackjack.Data
{
    public class BlackjackContext : DbContext
    {
        public DbSet<UserProfile> UserProfile { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(
                @"Data Source=(localdb)\ProjectsV13;Initial Catalog=Players;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            base.OnConfiguring(options);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserProfile>()
                .ToTable("ProfileInfo")
                .HasKey("PlayerId");

            modelBuilder.Entity<UserProfile>()
                .Property("PlayerId")
                .ValueGeneratedOnAdd();
        }
    }
}