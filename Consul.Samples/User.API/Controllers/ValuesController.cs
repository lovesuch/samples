using System;
using System.Globalization;
using Microsoft.AspNetCore.Mvc;

namespace User.API.Controllers
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
                $"User API: {DateTime.Now.ToString(CultureInfo.InvariantCulture)} {Environment.MachineName + " OS:" + Environment.OSVersion.VersionString}";
        }
    }
}