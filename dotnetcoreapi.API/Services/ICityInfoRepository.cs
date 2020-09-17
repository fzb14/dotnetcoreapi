using dotnetcoreapi.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnetcoreapi.API.Services
{
    public interface ICityInfoRepository
    {
        IEnumerable<City> GetCities();
        City GetCity(int id, bool includePois);
        public bool ExistsCity(int id);
        IEnumerable<PointOfInterest> GetAllPois();
        IEnumerable<PointOfInterest> GetPoisWithCityId(int cityId);
        PointOfInterest GetPoi(int cityId, int poiId);
    }
}
