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
                new CityDto{Id=1,Name="new york", Description="largest city in the world", PointsOfInterest=9},
                new CityDto{Id=2,Name="Beijing", Description="capital city in China", PointsOfInterest=8},
                new CityDto{Id=3,Name="Tokyo", Description="biggest city in Japan", PointsOfInterest=8},
                new CityDto{Id=4,Name="Shanghai", Description="famous city in China", PointsOfInterest=7}
            };
        }
    }
}
