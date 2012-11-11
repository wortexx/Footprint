﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Footprint.Common;
using Footprint.Domain.Model;
using Footprint.Domain.Model.Membership;
using Footprint.Domain.Model.Printing;

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

            return _db.SaveChanges() > 0;
        }
    }
}
