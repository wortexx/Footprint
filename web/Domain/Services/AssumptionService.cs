using System.Collections.Generic;
using Footprint.Domain.Model;

namespace Footprint.Domain.Services
{
    public class AssumptionService
    {
        public Dictionary<string, double> Get(string country)
        {
            var profile = CountryData.Items.Find(x => x.Name == country);
            return new Dictionary<string, double>
                       {
                           {"Electricity", profile.ElectricityPercent*profile.TotalFootprint},
                           {"Cooling", profile.CoolingPercent*profile.TotalFootprint},
                           {"Heating", profile.HeatingPercent*profile.TotalFootprint},
                           {"Water", profile.WaterPercent*profile.TotalFootprint},
                       };
        }
    }
}