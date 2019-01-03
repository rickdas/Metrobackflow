using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace HylanderManagement.Controllers
{
    [Produces("text/plain")]
    [Route(".well-known")]
    public class wellknownController : Controller
    {
        public wellknownController(IHostingEnvironment env)
        {
            Env = env;
        }

        private IHostingEnvironment Env { get; }

        [HttpGet("acme-challenge/{id}")]
        [Produces("text/plain")]
        public IActionResult Get(string id)
        {
            return Ok("dZoZdzKcYu7YVwittVVHI0W4OpUpR6mXFFoMmqnqvLo.TMv_ZG7WmqTHcTVqqzsl5bHV24P-j295TZ9WcaNagSQ");
        }
    }
}