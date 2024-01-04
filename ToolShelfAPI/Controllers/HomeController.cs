using Microsoft.AspNetCore.Mvc;
using ToolShelfAPI.Data;
using ToolShelfAPI.Services;

namespace ToolShelfAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        private readonly IHomeService _homeService;
        public HomeController(IHomeService homeService) {
            _homeService = homeService;
        }
        //public IActionResult Index()
        //{
        //    return View();
        //}

        [HttpGet(Name = "GetToolList")]
        public IEnumerable<ToolList> Get()
        {
            return _homeService.GetToolsList();
            //return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            //{
            //    Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            //    TemperatureC = Random.Shared.Next(-20, 55),
            //    Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            //})
            //.ToArray();
        }
    }
}
