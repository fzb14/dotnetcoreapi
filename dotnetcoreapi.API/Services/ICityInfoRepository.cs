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
        bool ExistsCity(int id);
        bool ExistsPoi(int id);
        IEnumerable<PointOfInterest> GetAllPois();
        IEnumerable<PointOfInterest> GetPoisWithCityId(int cityId);
        PointOfInterest GetPoi(int cityId, int poiId);
        void AddPoiForCity(int cityId, PointOfInterest poi);
        void UpdatePoiForCity(int cityId, PointOfInterest poi);
        bool Save();
    }
}
