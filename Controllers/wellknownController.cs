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

        /// <summary>
        /// for certification verification -- this is a temp file adding another change
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("acme-challenge/{id}")]
        [Produces("text/plain")]
        public IActionResult Get(string id)
        {
            return Ok("kSUxP6TjgUqVHadXzo8-r8KdXShgj7g7s84KH1Bsi-Y.TMv_ZG7WmqTHcTVqqzsl5bHV24P-j295TZ9WcaNagSQ");
        }
    }