using System.Collections.Generic;

namespace Footprint.Domain.Model
{
    public class CountryData
    {
        public static readonly List<CountryProfile> Items = new List<CountryProfile>();
        static CountryData()
        {

            Items.Add(new CountryProfile
                          {
                              Name = "United States", TotalFootprint = 40.00,
                              CoolingPercent = 0.25,
                              ElectricityPercent = 0.25,
                              HeatingPercent = 0.25,
                              WaterPercent = 0.25,
                          });
            Items.Add(new CountryProfile
            {
                Name = "United Kingdom",
                TotalFootprint = 27.89,
                CoolingPercent = 0.25,
                ElectricityPercent = 0.25,
                HeatingPercent = 0.25,
                WaterPercent = 0.25,
            });
            Items.Add(new CountryProfile
            {
                Name = "Russia",
                TotalFootprint = 22.41,
                CoolingPercent = 0.05,
                ElectricityPercent = 0.40,
                HeatingPercent = 0.33,
                WaterPercent = 0.22,
            });
            Items.Add(new CountryProfile
            {
                Name = "Ukraine",
                TotalFootprint = 14.90,
                CoolingPercent = 0.15,
                ElectricityPercent = 0.35,
                HeatingPercent = 0.28,
                WaterPercent = 0.22,
            });
            Items.Add(new CountryProfile
            {
                Name = "Belarus",
                TotalFootprint = 15.80,
                CoolingPercent = 0.05,
                ElectricityPercent = 0.40,
                HeatingPercent = 0.33,
                WaterPercent = 0.22,
            });
            Items.Add(new CountryProfile
            {
                Name = "Kazakhstan",
                TotalFootprint = 22.54,
                CoolingPercent = 0.05,
                ElectricityPercent = 0.32,
                HeatingPercent = 0.33,
                WaterPercent = 0.30,
            });
            Items.Add(new CountryProfile
            {
                Name = "Switzerland",
                CoolingPercent = 0.05,
                ElectricityPercent = 0.40,
                HeatingPercent = 0.33,
                WaterPercent = 0.22,
            });
            Items.Add(new CountryProfile
            {
                Name = "Sweden",
                TotalFootprint = 25.88,
                CoolingPercent = 0.01,
                ElectricityPercent = 0.25,
                HeatingPercent = 0.59,
                WaterPercent = 0.15,
            });
            Items.Add(new CountryProfile
            {
                Name = "Germany",
                TotalFootprint = 45.48,
                CoolingPercent = 0.04,
                ElectricityPercent = 0.37,
                HeatingPercent = 0.37,
                WaterPercent = 0.22,
            });
            Items.Add(new CountryProfile
            {
                Name = "Hungary",
                TotalFootprint = 14.95,
                CoolingPercent = 0.05,
                ElectricityPercent = 0.40,
                HeatingPercent = 0.33,
                WaterPercent = 0.22,
            });
            Items.Add(new CountryProfile
            {
                Name = "Poland",
                TotalFootprint = 21.75,
                CoolingPercent = 0.05,
                ElectricityPercent = 0.36,
                HeatingPercent = 0.38,
                WaterPercent = 0.21,
            });
        }

    }
}