using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using metro.Initialize;
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
        [HttpGet("transfer/{start}/{end}")]
        public async Task<IActionResult> getTransferAsync(string start,string end)
        {
            var transfer = await AzureStorageHelper.AzureStorageHelper.RetrieveEntityUsingPointQueryAsync(start, end);
            return Ok(transfer.route);
        }

        [HttpGet("metro/{metroId}/{start}/{end}")]
        public IActionResult getStationsBetween(string metroId,int start,int end)
        {
            return Ok(EntityFactory.metros
                .FirstOrDefault(u => u.Id == metroId)
                .GetStationsBetween(start, end));
        }
    }
}
