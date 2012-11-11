using System.Linq;
using Footprint.Common;
using Footprint.Domain.Model;
using Footprint.Domain.Model.Membership;
using Footprint.Site.Models;

namespace Footprint.Site.Services.Statistics
{
    public class StatisticsService
    {
        private FootprintContext _db = new FootprintContext();

        public Consumer  GetStatisticsForUser(string userName)
        {
            var user = _db.UserProfiles.FirstOrDefault(u => u.UserName == userName);


            var items = _db.Statistics.Where(x => x.UserProfile.UserName == userName).GroupBy(x => x.Consumer)
                .Select(x => new StatisticItemModel {Consumer = x.Key, Usage = x.Sum(i => i.Value)})
                .ToList();
            return new Consumer
                       {
                           Statistic = items                           
                       };
        }
    }
}