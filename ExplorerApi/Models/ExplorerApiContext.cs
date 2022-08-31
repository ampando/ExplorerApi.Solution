using Microsoft.EntityFrameworkCore;

namespace ExplorerApi.Models
{
    public class ExplorerApiContext : DbContext
    {
        public ExplorerApiContext(DbContextOptions<ExplorerApiContext> options)
            : base(options)
        {
        }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      builder.Entity<Place>()
        .HasData(
          new Place { PlaceId = 1, Name = "Adrienne", Country = "France", City = "Paris", Rating = 5  },
          new Place { PlaceId = 2, Name = "Royal", Country = "USA", City = "Portland", Rating = 5 },
          new Place { PlaceId = 3, Name = "Pancake", Country = "South America", City = "El Salvador", Rating = 3 },
          new Place { PlaceId = 4, Name = "Adrienne", Country = "Spain", City = "Madrid", Rating = 4 },
          new Place { PlaceId = 5, Name = "Pancake", Country = "Italy",City = "Milan", Rating  = 5 }
      );
    }
        public DbSet<Place> Places { get; set; }
    }
  }
