using Microsoft.EntityFrameworkCore;

namespace ExplorerApi.Models
{
    public class ExplorerApiContext : DbContext
    {
        public ExplorerApiContext(DbContextOptions<ExplorerApiContext> options)
            : base(options)
        {
        }

        public DbSet<Place> Places { get; set; }
    }
}