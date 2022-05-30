using ApriCode.Dal.Entities;
using Microsoft.EntityFrameworkCore;

namespace ApriCode.Dal
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {

        }

        public DbSet<Game> Game { get; set; }
        public DbSet<Genre> Genre { get; set; }
    }
}
