using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using Footprint.Domain.Model.Tracking;
using Footprint.Domain.Model;

namespace Footprint.Site.Controllers
{
    public class LocationTrackController : ApiController
    {
        private readonly FootprintContext _db = new FootprintContext();

        // POST api/Default1
        public HttpResponseMessage Add(LocationTrack locationtrack)
        {
            if (ModelState.IsValid)
            {
                _db.LocationTracks.Add(locationtrack);
                _db.SaveChanges();

                var response = Request.CreateResponse(HttpStatusCode.Created, locationtrack);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = locationtrack.Id }));
                return response;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        protected override void Dispose(bool disposing)
        {
            _db.Dispose();
            base.Dispose(disposing);
        }
    }

    public class AuthController : ApiController
    {
        public bool IsValid([FromBody] string email)
        {
            return true;
        }
    }
}