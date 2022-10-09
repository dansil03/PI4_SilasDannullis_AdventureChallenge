using AdventureChallenge.Models;
using Microsoft.EntityFrameworkCore;

namespace AdventureChallenge.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> contextOptions)
            : base(contextOptions)
        {

        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<UserChallenge>()
                .HasKey(uc => new
                {
                    uc.UserChallengeId
                    //uc.UserId,
                    //uc.ChallengeId
                });
            modelBuilder.Entity<UserChallenge>()
                .HasOne(c => c.Challenge)
                .WithMany(uc => uc.User)
                .HasForeignKey(uc => uc.ChallengeId);

            modelBuilder.Entity<UserChallenge>()
                .HasOne(u => u.User)
                .WithMany(uc => uc.UserChallenges)
                .HasForeignKey(u => u.UserId);

        }
        public DbSet<Challenge> challenges { get; set; }
        public DbSet<UserChallenge> userChallenges { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
