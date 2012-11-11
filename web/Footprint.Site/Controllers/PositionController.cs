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
using Footprint.Domain.Model.Statistics;
using Footprint.Domain.Model.Tracking;
using Footprint.Domain.Model;
using Footprint.Domain.Tracking;
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
                LocationTrack locationTrack = CreateLocationTrack(position, token);
                DateTime trackDate = locationTrack.TimeStamp.Date;
                var locationTracks = _db.LocationTracks.Where(l => l.TimeStamp > trackDate).ToList();
                StatisticsItem statisticsItem = _db.Statistics.FirstOrDefault(s => s.Day == trackDate);
                if (statisticsItem == null)
                {
                    statisticsItem = new StatisticsItem();
                    _db.Statistics.Add(statisticsItem);
                }
                statisticsItem.CalculateStatistics(locationTracks, locationTrack);
                _db.LocationTracks.Add(locationTrack);

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
            UserProfile user = _db.UserProfiles.First(u => u.UserName == token);
            var locationTrack = new LocationTrack();
            locationTrack.UserProfile = user;
            locationTrack.TimeStamp = DateTime.MinValue.Add(TimeSpan.FromTicks(position.UtcTicks));
            locationTrack.Location = DbGeography.FromText(string.Format("POINT ({0} {1})",position.Latitude, position.Longitude));
            locationTrack.Speed = position.Speed;
            locationTrack.Id = Guid.NewGuid();
            return locationTrack;
        }

        protected override void Dispose(bool disposing)
        {
            _db.Dispose();
            base.Dispose(disposing);
        }
    }
}