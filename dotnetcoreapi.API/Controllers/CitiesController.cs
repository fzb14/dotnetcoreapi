using dotnetcoreapi.API.Models;
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
        [HttpGet]
        public IActionResult GetCities()
        {
            return Ok(
                CityDataStore.InitialData.Cities
            );
        }
        [HttpGet("{id}")]
        public IActionResult GetCity(int id)
        {
            var result = CityDataStore.InitialData.Cities.FirstOrDefault<CityDto>(c => c.Id == id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }
    }
}
