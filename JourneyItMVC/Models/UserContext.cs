using Microsoft.EntityFrameworkCore;

namespace JourneyItMVC.Models
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options)
                : base(options)
            {
            }
            public DbSet<UserContext> user { get; set; }
            
            //protected override void OnConfiguring(DbContextOptionsBuilder options)
            //{
            //    options.UseSqlite("Data Source=Bank.db");
            //}

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                modelBuilder.Entity<User>()
                    .HasIndex(e => e.Id)
                    .IsUnique();
            }
        }
    }

