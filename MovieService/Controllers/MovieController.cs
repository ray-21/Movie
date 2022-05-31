using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using MovieBusiness.Services;
using MovieEntity;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MovieApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        MovieServices _movieService;

        public MovieController(MovieServices movieServices)
        {
            _movieService = movieServices;
        }

        [HttpGet("SelectMovie")]
        public IActionResult SelectMovie()
        {
            return Ok(_movieService.SelectMovie());
        }

        [HttpPost("AddMovie")]
        public IActionResult AddMovie(MovieModel movieModel)
        {
            return Ok(_movieService.AddMovie(movieModel));
        }

        [HttpDelete("DeleteMovie")]
        public IActionResult DeleteMovie(int id)
        {
            return Ok(_movieService.DeleteMovie(id));
        }
    }
}

