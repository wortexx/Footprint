using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Spatial;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Authentication;
using System.Web;
using System.Web.Http;
using Footprint.Domain.Model.Membership;
using Footprint.Domain.Model.Tracking;
using Footprint.Domain.Model;
using Footprint.Site.Models;

namespace Footprint.Site.Controllers
{
    public class PositionController : ApiController
    {
        private readonly FootprintContext _db = new FootprintContext();

        // POST api/Default1
        public HttpResponseMessage Add([FromBody] Position position, [FromUri]  string token)
        {
            if (string.IsNullOrWhiteSpace(token))
                throw new AuthenticationException();
            
            if (ModelState.IsValid)
            {
                _db.LocationTracks.Add(CreateLocationTrack(position, token));
                _db.SaveChanges();

                var response = Request.CreateResponse(HttpStatusCode.Created, position);
                //response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = positio }));
                return response;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        private static readonly DateTime unixEpoch = new DateTime(1970, 1, 1, 0, 0, 0,
                                                          DateTimeKind.Utc);

        private LocationTrack CreateLocationTrack(Position position, string token)
        {
            User user = _db.Users.First(u => u.Email == token);
            var locationTrack = new LocationTrack();
            locationTrack.User = user;
            locationTrack.TimeStamp = unixEpoch.AddTicks(position.UtcTicks);
            locationTrack.Location = DbGeography.FromText(string.Format("POINT ({0} {1})",position.Latitude, position.Longitude));
            return locationTrack;
        }

        protected override void Dispose(bool disposing)
        {
            _db.Dispose();
            base.Dispose(disposing);
        }
    }
}