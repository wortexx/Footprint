using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Footprint.Common;
using Footprint.Domain.Model;
using Footprint.Domain.Model.Membership;
using Footprint.Domain.Model.Printing;
using Footprint.Domain.Model.Statistics;

namespace Footprint.Printing
{
    public class PrintingModule
    {
        private readonly FootprintContext _db = new FootprintContext();

        
        public bool Process(string token, int pagesPrinted)
        {
            var user = _db.UserProfiles.FirstOrDefault(u => u.Token == token);
            if (user == null)
            {
                return false;
            }

            var item = new PrintingItem
                           {
                               Id = Guid.NewGuid(),
                               UserProfile = user,
                               TimeStamp = DateTime.UtcNow,
                               PagesPrinted = pagesPrinted
                           };
            _db.PrintingItems.Add(item);

            UpdateStatistics(user, pagesPrinted);

            return _db.SaveChanges() > 0;
        }

        private void UpdateStatistics(UserProfile user, int pagesPrinted)
        {
            var today = DateTime.UtcNow.Date;
            var item = _db.Statistics.FirstOrDefault(x => x.UserProfile.UserId == user.UserId && x.Day == today && x.Consumer == Consumers.Printing);
            if (item == null)
            {
                item = new StatisticsItem
                           {
                               Id = Guid.NewGuid(),
                               Consumer = Consumers.Printing,
                               Day = today,
                               UserProfile = user,
                               Value = PrintingCalculator.Calculate(pagesPrinted)
                           };
                _db.Statistics.Add(item);
                return;
            }

            item.Value += PrintingCalculator.Calculate(pagesPrinted);
            return;
        }
    }
}
