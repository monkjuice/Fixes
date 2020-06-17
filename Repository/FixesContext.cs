using Microsoft.EntityFrameworkCore;
using Model;

namespace Repository
{
    public class FixesContext : DbContext
    {
        public DbSet<Model.User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=DESKTOP-FMK5R8I;Database=Fixes;Trusted_Connection=True;");
            }
        }

    }
}
