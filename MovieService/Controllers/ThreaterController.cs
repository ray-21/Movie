using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MovieBusiness.Services;
using MovieEntity.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MovieApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ThreaterController : Controller
    {
        MovieBusiness.Services.ThreaterService _threaterService;

        public ThreaterController(ThreaterService threaterService)
        {
            _threaterService = threaterService;
        }

        [HttpGet("selectThreater")]
        public IActionResult selectThetre()
        {
            return Ok(_threaterService.SelectThreater());
        }

        [HttpPost("addThreater")]
        public IActionResult addThetre(ThreaterModel thetreModel)
        {
            return Ok(_threaterService.AddThetre(thetreModel));
        }
        
    }
}

