using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Footprint.Printing;

namespace Footprint.Site.Controllers
{
    public class PrintingController : ApiController
    {
        // POST api/paper
        [HttpPost]
        public bool Add(string token, int pages)
        {
            var module = new PrintingModule();
            return module.Process(token, pages);
        }
    }
}
