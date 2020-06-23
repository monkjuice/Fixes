using Microsoft.EntityFrameworkCore;
using Model;
using System.Configuration;

namespace Repository
{
    public class FixesContext : DbContext
    {
        public DbSet<Model.User> User { get; set; }

        public DbSet<Friendship> Friendship { get; set; }

        public DbSet<FriendshipRequest> FriendshipRequest { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var s = ConfigurationManager.AppSettings["ConnectionString"];
                optionsBuilder.UseSqlServer(s);
            }
        }

    }
}
