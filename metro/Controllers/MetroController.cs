using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace metro.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        [HttpGet("getStationName/{id}")]
        public ActionResult<List<string>> Get(string metroId)
        {
            return EntityFactory.metroDic[metroId].GetStations().Select(u => u.Name).ToList();
        }

        [HttpGet("getTransfer/{begin}/{end}")]
        public ActionResult<List<List<string>>> Get(string begin,string end)
        {
            return null;
        }
    }
}
