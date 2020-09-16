using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnetcoreapi.API.Contexts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace dotnetcoreapi.API.Controllers
{
    [Route("api/testdatabase")]
    [ApiController]
    public class DummyController : ControllerBase
    {
        private readonly CityInfoContext dbContext;

        public DummyController(CityInfoContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpGet]
        public IActionResult TestDatabase()
        {
            return Ok();
        }
    }
}
