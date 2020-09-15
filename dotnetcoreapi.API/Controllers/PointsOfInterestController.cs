using dotnetcoreapi.API.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.NewtonsoftJson;
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
        public IActionResult CreatePointOfIntest(int cityId, [FromBody]PointOfInterestForCreateDto poi)
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
        [HttpPut("{id}")]
        public IActionResult UpdatePointOfInterest(int cityId, int id, [FromBody] PointOfInterestDto poi)
        {
            var city = Cities.FirstOrDefault(c => c.Id == cityId);
            if (city == null)
            {
                return BadRequest();
            }
            var targetPoi = city.PointsOfInterest.FirstOrDefault(p => p.Id == id);
            if (targetPoi == null)
                return NotFound();
            targetPoi.Name = poi.Name;
            targetPoi.Description = poi.Description;

            return RedirectToAction("GetPointOfInterest", new { cityId, id });
        }
        [HttpPatch("{id}")]
        public IActionResult PartiallyUpdatePointOfInterest(int cityId, int id, [FromBody] JsonPatchDocument<PointOfInterestForCreateDto> patchDoc)
        {
            var city = Cities.FirstOrDefault(c => c.Id == cityId);
            if (city == null)
            {
                return BadRequest();
            }
            var targetPoi = city.PointsOfInterest.FirstOrDefault(p => p.Id == id);
            if (targetPoi == null)
                return NotFound();
            var poiToPatch = new PointOfInterestForCreateDto(){ Name=targetPoi.Name,Description=targetPoi.Description};
            patchDoc.ApplyTo(poiToPatch,ModelState);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            targetPoi.Name = poiToPatch.Name;
            targetPoi.Description = poiToPatch.Description;
            return NoContent();

        }

    }
}
