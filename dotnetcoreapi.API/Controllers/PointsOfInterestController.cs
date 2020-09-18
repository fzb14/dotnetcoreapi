using AutoMapper;
using dotnetcoreapi.API.Entities;
using dotnetcoreapi.API.Models;
using dotnetcoreapi.API.Services;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
        //private List<CityDto> FakeCities;
        private readonly ILogger<PointsOfInterestController> logger;
        private readonly IMailService mailService;
        private readonly ICityInfoRepository cityInfoRepository;
        private readonly IMapper mapper;

        public PointsOfInterestController(ILogger<PointsOfInterestController> logger, IMailService mailService,ICityInfoRepository cityInfoRepository,IMapper mapper) : base()
        {
            //FakeCities = CityDataStore.InitialData.Cities.ToList();
            this.logger = logger;
            this.mailService = mailService;
            this.cityInfoRepository = cityInfoRepository;
            this.mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetPointsOfInterest(int cityId)
        {
            try
            {
                //throw new Exception("test exception.");
                //var city = FakeCities.FirstOrDefault(c => c.Id == cityId);
                if (!cityInfoRepository.ExistsCity(cityId))
                {
                    logger.LogInformation($"the city with id {cityId} is not found.");
                    return NotFound();
                }
                var pois = cityInfoRepository.GetPoisWithCityId(cityId);
                //var result = new List<PointOfInterestDto>();
                //foreach(var p in pois)
                //{
                //    result.Add(new PointOfInterestDto { 
                //        Id=p.Id,
                //        Name= p.Name,
                //        Description=p.Description
                //    });
                //}
                var result = mapper.Map<IEnumerable<PointOfInterestDto>>(pois);
                return Ok(result);
            }
            catch(Exception ex)
            {
                logger.LogCritical(ex,$"Exception happened when get points of interest of city with id {cityId}");
                return StatusCode(500, "There is a problem when handling your request.");
            }
            
        }
        [HttpGet("{id}",Name = "GetPointOfInterest")]
        public IActionResult GetPointOfInterest(int cityId, int id)
        {
            //var city = FakeCities.FirstOrDefault(c => c.Id == cityId);
            if (!cityInfoRepository.ExistsCity(cityId))
            {
                logger.LogInformation($"the city with id {cityId} is not found.");
                return NotFound();
            }
                
            var pi = cityInfoRepository.GetPoi(cityId,id);
            if (pi == null)
                return NotFound();
            //var result = new PointOfInterestDto
            //{
            //    Id = pi.Id,
            //    Name = pi.Name,
            //    Description = pi.Description
            //};
            var result = mapper.Map<PointOfInterestDto>(pi);
            return Ok(result);
        }
        [HttpPost]
        public IActionResult CreatePointOfIntest(int cityId, [FromBody] PointOfInterestForCreateDto poi)
        {
            if (poi.Name == poi.Description)
            {
                ModelState.AddModelError("description", "description must be different from name.");
            }
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            //var city = FakeCities.FirstOrDefault(c => c.Id == cityId);
            if (!cityInfoRepository.ExistsCity(cityId))
            {
                return NotFound();
            }
            //var maxPoiId = FakeCities.SelectMany(c => c.PointsOfInterest).Max(p => p.Id);
            if (poi == null)
            {
                return BadRequest();
            }
            //var newPoi = new PointOfInterestDto
            //{
            //    Id = ++maxPoiId,
            //    Name = poi.Name,
            //    Description = poi.Description
            //};
            var newPoi = mapper.Map<PointOfInterest>(poi);
            cityInfoRepository.AddPoiForCity(cityId, newPoi);
            cityInfoRepository.Save();
            //city.PointsOfInterest.Add(newPoi);
            var createdPoi = mapper.Map<PointOfInterestDto>(newPoi);
            return CreatedAtRoute("GetPointOfInterest", new { cityId, id = createdPoi.Id }, createdPoi);
        }
        //[HttpPut("{id}")]
        //public IActionResult UpdatePointOfInterest(int cityId, int id, [FromBody] PointOfInterestDto poi)
        //{
        //    var city = FakeCities.FirstOrDefault(c => c.Id == cityId);
        //    if (city == null)
        //    {
        //        return BadRequest();
        //    }
        //    var targetPoi = city.PointsOfInterest.FirstOrDefault(p => p.Id == id);
        //    if (targetPoi == null)
        //        return NotFound();
        //    targetPoi.Name = poi.Name;
        //    targetPoi.Description = poi.Description;

        //    return RedirectToAction("GetPointOfInterest", new { cityId, id });
        //}
        //[HttpPatch("{id}")]
        //public IActionResult PartiallyUpdatePointOfInterest(int cityId, int id, [FromBody] JsonPatchDocument<PointOfInterestForCreateDto> patchDoc)
        //{
        //    var city = FakeCities.FirstOrDefault(c => c.Id == cityId);
        //    if (city == null)
        //    {
        //        return BadRequest();
        //    }
        //    var targetPoi = city.PointsOfInterest.FirstOrDefault(p => p.Id == id);
        //    if (targetPoi == null)
        //        return NotFound();
        //    var poiToPatch = new PointOfInterestForCreateDto(){ Name=targetPoi.Name,Description=targetPoi.Description};
        //    patchDoc.ApplyTo(poiToPatch,ModelState);
        //    if (!ModelState.IsValid)
        //        return BadRequest(ModelState);
        //    if (!TryValidateModel(poiToPatch))
        //        return BadRequest(ModelState);
        //    targetPoi.Name = poiToPatch.Name;
        //    targetPoi.Description = poiToPatch.Description;
        //    return NoContent();

        //}
        //[HttpDelete("{id}")]
        //public IActionResult DeletePointOfInterest(int cityId, int id)
        //{
        //    var city = FakeCities.FirstOrDefault(c => c.Id == cityId);
        //    if (city == null)
        //    {
        //        return BadRequest();
        //    }
        //    var targetPoi = city.PointsOfInterest.FirstOrDefault(p => p.Id == id);
        //    if (targetPoi == null)
        //        return NotFound();
        //    city.PointsOfInterest.Remove(targetPoi);
        //    mailService.Send("point of interest deleted.", $"point of interest {targetPoi.Name} in city {city.Name} is deleted.");
        //    return NoContent();
        //}

    }
}
