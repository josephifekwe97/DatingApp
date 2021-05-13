using System.Threading.Tasks;
using DatingApp.Api.Models.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ValuesController : ControllerBase
    {
        private readonly ApplicationDbcontext _context;

        public ValuesController( ApplicationDbcontext context)
        {
            _context = context;
        }

         [HttpGet]
          public IActionResult GetValue()
         {
             var values =   _context.values.ToListAsync();
             return Ok (values);
         }
    }
}