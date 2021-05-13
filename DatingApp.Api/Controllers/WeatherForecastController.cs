using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatingApp.Api.Models.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DatingApp.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly ApplicationDbcontext _context;

        public WeatherForecastController(ILogger<WeatherForecastController> logger , ApplicationDbcontext context )
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        //public IEnumerable<WeatherForecast> Get()
        //{
        //    var rng = new Random();
         //   return Enumerable.Range(1, 5).Select(index => new WeatherForecast
         //   {
          //      Date = DateTime.Now.AddDays(index),
           //     TemperatureC = rng.Next(-20, 55),
            //    Summary = Summaries[rng.Next(Summaries.Length)]
           /// })
          //  .ToArray();
       // }
          [HttpGet]
          public async Task<IActionResult> GetValue()
         {
             var values =  await _context.values.ToListAsync();
             return Ok (values);
         }

      
    }
}
