using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace metro.Controllers
{
    [Route("[controller]")]
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult getAllMetros()
        {
            return Ok(EntityFactory.metros);
        }
        [HttpGet("metro/{metroId}")]
        public IActionResult getStationName(string metroId)
        {
            return Ok(EntityFactory.metros
                .FirstOrDefault(u => u.Id == metroId)
                .GetStations()
                .Select(s => s.Name)
                .ToList());
        }
    }
}
