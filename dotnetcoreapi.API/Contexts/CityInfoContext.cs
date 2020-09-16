using dotnetcoreapi.API.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnetcoreapi.API.Contexts
{
    public class CityInfoContext : DbContext
    {
        public CityInfoContext(DbContextOptions<CityInfoContext> options): base(options)
        {
            //Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<City>().HasData(
                new City
                {
                    Id = 1,
                    Name = "new york",
                    Description = "largest city in the world"
                },
                new City
                {
                    Id = 2,
                    Name = "Beijing",
                    Description = "capital city in China"
                },
                new City
                {
                    Id = 3,
                    Name = "Tokyo",
                    Description = "biggest city in Japan"
                },
                new City
                {
                    Id = 4,
                    Name = "Shanghai",
                    Description = "famous city in China"
                },
                new City { Id = 5, Name = "Fuzhou", Description = "Capital city of Fujian Province" }
                );
            modelBuilder.Entity<PointOfInterest>().HasData(
                new PointOfInterest { Id = 1, Name = "Central Park", Description = "beautiful",CityId=1},
                        new PointOfInterest { Id = 2, Name = "Long Irland", Description = "see sea",CityId=1 },
                        new PointOfInterest { Id = 3, Name = "Great Wall", Description = "long long wall",CityId=2 },
                        new PointOfInterest { Id = 4, Name = "Forbidden City", Description = "large old palace",CityId=2 },
                        new PointOfInterest { Id = 5, Name = "Crowded Street", Description = "many mamy people",CityId=3 },
                        new PointOfInterest { Id = 6, Name = "Sushi Bar", Description = "Yummy freash sushi",CityId=3 },
                        new PointOfInterest { Id = 7, Name = "Oriental Peal Tower", Description = "A tall radio and tv tower",CityId=4 },
                        new PointOfInterest { Id = 8, Name = "The Bund", Description = "European style buildings",CityId=4 }

                );
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<City> Cities { get; set; }
        public DbSet<PointOfInterest> pointOfInterests { get; set; }
    }
}
