using dotnetcoreapi.API.Contexts;
using dotnetcoreapi.API.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnetcoreapi.API.Services
{
    public class CityInfoRepository : ICityInfoRepository
    {
        private readonly CityInfoContext cityInfoContext;

        public CityInfoRepository(CityInfoContext cityInfoContext)
        {
            this.cityInfoContext = cityInfoContext;
        }
        public IEnumerable<PointOfInterest> GetAllPois()
        {
            var result = cityInfoContext.pointOfInterests.ToList();
            return result;
        }

        public IEnumerable<City> GetCities()
        {
            return cityInfoContext.Cities.ToList();
        }
        public bool ExistsCity(int id)
        {
            return cityInfoContext.Cities.Any(c => c.Id == id);
        }
        public bool ExistsPoi(int id)
        {
            return cityInfoContext.pointOfInterests.Any(p => p.Id == id);
        }
        public City GetCity(int id, bool includePois)
        {
            if (includePois)
            {
                return cityInfoContext.Cities.Include(c => c.PointsOfInterest).FirstOrDefault(c => c.Id == id);
            }
            return cityInfoContext.Cities.FirstOrDefault(c => c.Id == id);
        }

        public PointOfInterest GetPoi(int cityId, int poiId)
        {
            return cityInfoContext.pointOfInterests.FirstOrDefault(p => p.CityId == cityId && p.Id == poiId);
        }

        public IEnumerable<PointOfInterest> GetPoisWithCityId(int cityId)
        {
            return cityInfoContext.pointOfInterests.Where(p => p.CityId == cityId).ToList();
        }

        public void AddPoiForCity(int cityId, PointOfInterest poi)
        {
            //poi.CityId = cityId;
            //cityInfoContext.pointOfInterests.Add(poi);
            var city = cityInfoContext.Cities.FirstOrDefault(c => c.Id == cityId);
            if (city != null)
            {
                city.PointsOfInterest.Add(poi);
            }
            //cityInfoContext.SaveChanges();
        }
        public void UpdatePoiForCity(int cityId, PointOfInterest poi)
        {

        }

        public bool Save()
        {
            return cityInfoContext.SaveChanges() >= 0;
        }
    }
}
