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
                .Select(x => new StatisticItemModel
                                 {
                                     Consumer = x.Key, 
                                     TotalUsage = x.Sum(i => i.Value), 
                                     Days = x.Count()
                                 })
                .ToList();

            var norms = _db.Statistics.GroupBy(x => x.Consumer).Select(x =>
                new { Consumer = x.Key, Norm = x.Sum(i => i.Value)/x.Count()}).ToDictionary(x => x.Consumer, y => y.Norm);

            items.ForEach(x => x.Norm = norms[x.Consumer]);

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