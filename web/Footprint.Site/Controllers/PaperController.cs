using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Footprint.Site.Controllers
{
    public class PaperController : ApiController
    {
        // POST api/paper
        [HttpGet]
        [HttpPost]
        public void Add([FromUri]string token, [FromUri] string amount)
        {
            Debug.WriteLine(string.Format("{0} - {1}", token, amount));
        }
    }
}
