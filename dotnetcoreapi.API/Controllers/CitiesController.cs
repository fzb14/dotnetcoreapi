﻿using dotnetcoreapi.API.Models;
using dotnetcoreapi.API.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnetcoreapi.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CitiesController : ControllerBase
    {
        private readonly ICityInfoRepository cityInfoRepository;

        public CitiesController(ICityInfoRepository cityInfoRepository)
        {
            this.cityInfoRepository = cityInfoRepository;
        }

        public IActionResult Cities()
        {
            var cityEntities = cityInfoRepository.GetCities();
            var result = new List<CityWithoutPoisDto>();
            foreach(var city in cityEntities)
            {
                result.Add(new CityWithoutPoisDto { 
                    Id=city.Id,
                    Name=city.Name,
                    Description=city.Description
                });
            }
            return Ok(result);
        }
        [HttpGet("{id}")]
        public IActionResult GetCity(int id, bool includePoi = false)
        {
            var cityEntiy = cityInfoRepository.GetCity(id, includePoi);
            if (cityEntiy == null)
                return NotFound();
            if (includePoi)
            {
                var cityResult = new CityDto
                {
                    Id = cityEntiy.Id,
                    Name = cityEntiy.Name,
                    Description = cityEntiy.Description
                };
                foreach(var poi in cityEntiy.PointsOfInterest)
                {
                    cityResult.PointsOfInterest.Add(new PointOfInterestDto
                    {
                        Id = poi.Id,
                        Name = poi.Name,
                        Description = poi.Description
                    });
                }
                return Ok(cityResult);
            }
            var result = new CityWithoutPoisDto
            {
                Id = cityEntiy.Id,
                Name = cityEntiy.Name,
                Description = cityEntiy.Description
            };
            return Ok(result);
        }
        [HttpGet("fakeData")]
        public IActionResult GetFakeCities()
        {
            return Ok(
                CityDataStore.InitialData.Cities
            );
        }
        [HttpGet("fakeData/{id}")]
        public IActionResult GetFakeCity(int id)
        {
            var result = CityDataStore.InitialData.Cities.FirstOrDefault<CityDto>(c => c.Id == id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }
    }
}
