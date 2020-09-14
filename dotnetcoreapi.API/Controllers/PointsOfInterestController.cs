using dotnetcoreapi.API.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnetcoreapi.API.Controllers
{
    [ApiController]
    [Route("api/cities/{cityId}/pointsofinterest")]
    public class PointsOfInterestController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetPointsOfInterest(int cityId)
        {
            var city = CityDataStore.InitialData.Cities.FirstOrDefault(c => c.Id == cityId);
            if (city == null)
                return NotFound();
            return Ok(city.PointsOfInterest);
        }
        [HttpGet("{id}")]
        public IActionResult GetPointOfInterest(int cityId, int id)
        {
            var city = CityDataStore.InitialData.Cities.FirstOrDefault(c => c.Id == cityId);
            if (city == null)
                return NotFound();
            var pi = city.PointsOfInterest.FirstOrDefault(p => p.Id == id);
            if (pi == null)
                return NotFound();
            return Ok(pi);
        }

    }
}
