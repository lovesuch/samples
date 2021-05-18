using System;
using System.Globalization;
using Microsoft.AspNetCore.Mvc;

namespace Gateway.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET: api/<ValuesController>
        [HttpGet]
        public object Get()
        {
            return
                $"Gateway API: {DateTime.Now.ToString(CultureInfo.InvariantCulture)} {Environment.MachineName + " OS:" + Environment.OSVersion.VersionString}";
        }
    }
}