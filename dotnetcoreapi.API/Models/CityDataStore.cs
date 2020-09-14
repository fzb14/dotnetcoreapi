using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnetcoreapi.API.Models
{
    public class CityDataStore
    {
        public static CityDataStore InitialData { get; } = new CityDataStore();
        public List<CityDto> Cities { get; set; }

        public CityDataStore()
        {
            Cities = new List<CityDto>
            {
                new CityDto{
                    Id=1,
                    Name="new york", 
                    Description="largest city in the world", 
                    PointsOfInterest = new List<PointOfInterestDto>{ 
                        new PointOfInterestDto{Id=1,Name="Central Park",Description="beautiful"},
                        new PointOfInterestDto{Id=2,Name="Long Irland",Description="see sea"}
                    } },
                new CityDto{Id=2,Name="Beijing", Description="capital city in China",
                    PointsOfInterest = new List<PointOfInterestDto>{
                        new PointOfInterestDto{Id=3,Name="Great Wall",Description="long long wall"},
                        new PointOfInterestDto{Id=4,Name="Forbidden City",Description="large old palace"}
                    }
                },
                new CityDto{Id=3,Name="Tokyo", Description="biggest city in Japan",
                PointsOfInterest = new List<PointOfInterestDto>{
                        new PointOfInterestDto{Id=5,Name="Crowded Street",Description="many mamy people"},
                        new PointOfInterestDto{Id=6,Name="Sushi Bar",Description="Yummy freash sushi"}
                    }
                },
                new CityDto{Id=4,Name="Shanghai", Description="famous city in China",
                    PointsOfInterest = new List<PointOfInterestDto>{
                        new PointOfInterestDto{Id=7,Name="Oriental Peal Tower",Description="A tall radio and tv tower"},
                        new PointOfInterestDto{Id=8,Name="The Bund",Description="European style buildings"}
                    }
                },
                new CityDto{Id=5,Name="Fuzhou", Description="Capital city of Fujian Province"}
            };
        }
    }
}
