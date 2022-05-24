using LWAJWTLOG.Models;
using Microsoft.EntityFrameworkCore;


namespace LWAJWTLOG.Model
{
    public class DatabaseContext_2 : DbContext
    {
        public DatabaseContext_2(DbContextOptions options)
            : base(options)
        {
        }
        public DbSet<CodeFirst> Codefirsts { get; set; }

    }
}
