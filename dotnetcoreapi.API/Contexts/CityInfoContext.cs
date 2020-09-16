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
            Database.EnsureCreated();
        }
        DbSet<City> Cities { get; set; }
        DbSet<PointOfInterest> pointOfInterests { get; set; }
    }
}
