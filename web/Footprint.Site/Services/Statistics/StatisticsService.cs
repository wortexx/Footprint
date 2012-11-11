using System;
using System.Linq;
using Footprint.Domain.Model;
using Footprint.Domain.Services;
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
            var assumptions = new AssumptionService();
            var assumed = assumptions.Get(user.Country ?? "Ukraine");
            items.AddRange(assumed.Select(row => new StatisticItemModel
                                                     {
                                                         Consumer = row.Key, 
                                                         Usage = Convert.ToDecimal(row.Value),
                                                         Norm = Convert.ToDecimal(row.Value)
                                                     }));
            return new Consumer
                       {
                           Statistic = items                           
                       };
        }
    }
}