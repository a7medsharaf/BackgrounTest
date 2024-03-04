using BackgrounTest.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackgrounTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JokesController : ControllerBase
    {
        private readonly IJokeService _joke;

        public JokesController(IJokeService jokeService)
        {
            _joke=jokeService;
        }

        [Route("~/GetJokes")]
        [HttpGet]
        public IActionResult GetJokes()
        {
            var x = _joke.GetJokes();
            return Ok(x);
        }

        [Route("~/UpdateJokes")]
        [HttpPost]
        public IActionResult UpdateJokes()
        {
            _joke.UpdateJokes();
            return Ok();
        }
    }
}
