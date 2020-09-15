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
        private List<CityDto> Cities;
        public PointsOfInterestController() : base()
        {
            Cities = CityDataStore.InitialData.Cities.ToList();
        }
        [HttpGet]
        public IActionResult GetPointsOfInterest(int cityId)
        {
            var city = Cities.FirstOrDefault(c => c.Id == cityId);
            if (city == null)
                return NotFound();
            return Ok(city.PointsOfInterest);
        }
        [HttpGet("{id}",Name = "GetPointOfInterest")]
        public IActionResult GetPointOfInterest(int cityId, int id)
        {
            var city = Cities.FirstOrDefault(c => c.Id == cityId);
            if (city == null)
                return NotFound();
            var pi = city.PointsOfInterest.FirstOrDefault(p => p.Id == id);
            if (pi == null)
                return NotFound();
            return Ok(pi);
        }
        [HttpPost]
        public IActionResult PostPointOfIntest(int cityId, [FromBody]PointOfInterestForCreateDto poi)
        {
            if (poi.Name == poi.Description)
            {
                ModelState.AddModelError("description", "description must be different from name.");
            }
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var city = Cities.FirstOrDefault(c => c.Id == cityId);
            if (city == null)
            {
                return BadRequest();
            }
            var maxPoiId = Cities.SelectMany(c => c.PointsOfInterest).Max(p => p.Id);
            if (poi == null)
            {
                return BadRequest();
            }
            var newPoi = new PointOfInterestDto
            {
                Id = ++maxPoiId,
                Name = poi.Name,
                Description = poi.Description
            };
            city.PointsOfInterest.Add(newPoi);
            return CreatedAtRoute("GetPointOfInterest", new { cityId, id = maxPoiId }, newPoi);
        }


    }
}
