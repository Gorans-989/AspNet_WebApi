using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEDC.WebApi.Class01.Controllers
{
    [ApiController]// atribut , tag koj oznacuva deka e API controler. Toa znaci deka e kontroler za HTTP response t.e.
                   // nema view support
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase // se koristi CONTROLLER BASE  bidejki e kontroler klasa bez view support
                                                            // i ne vrakja view
    {
        

        [HttpGet]
        public List<string> Get()
        {

            return new List<string>() { "Web api", "SECD", "G3"};
        }
    }
}
