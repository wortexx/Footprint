using System;
using System.Collections.Generic;
using System.Linq;
using Footprint.Domain.Model.Statistics;
using Footprint.Domain.Model.Tracking;

namespace Footprint.Domain.Tracking
{
    public static class LocationCalculator
    {
        private static readonly IDictionary<decimal, decimal> co2IndexMap = new Dictionary<decimal, decimal>();

        static LocationCalculator()
        {
            co2IndexMap.Add(10, 210);
            co2IndexMap.Add(20, 144);
            co2IndexMap.Add(30, 108);
            co2IndexMap.Add(40, 100);
            co2IndexMap.Add(50, 92);
            co2IndexMap.Add(60, 89);
            co2IndexMap.Add(70, 87);
            co2IndexMap.Add(80, 89);
            co2IndexMap.Add(90, 94);
            co2IndexMap.Add(100, 105);
        }

        public static void CalculateStatistics(this StatisticsItem item, List<LocationTrack> dayTrackList, LocationTrack lastTrack)
        {
            LocationTrack lastSaved = dayTrackList.LastOrDefault();
            if (lastSaved == null)
            {
                return;
            }

            if (lastSaved.TimeStamp.AddMinutes(20) < lastTrack.TimeStamp)
            {
                //Difference too much
                return;
            }

            double? distance = lastTrack.Location.Distance(lastSaved.Location);
            if (!distance.HasValue)
            {
                return;
            }

            decimal co2Index = GetCo2Index(lastTrack.Speed);
            decimal distanceValue = Convert.ToDecimal(distance.Value);
            decimal co2InKilograms = 150.0m * co2Index / (distanceValue / 1000.0m);
            const decimal co2RecycleInOneDay = 44.0m / 365.0m;

            decimal result = co2InKilograms/co2RecycleInOneDay;
            item.Day = lastTrack.TimeStamp.Date;
            item.UserProfile = lastTrack.UserProfile;
            item.Value = result;
        }

        private static decimal GetCo2Index(double speed)
        {
            decimal decimalSpeed = Convert.ToDecimal(speed);

            decimal lowLimit = 0;
            foreach (var pair in co2IndexMap)
            {
                decimal highLimit = pair.Key / 3.6m;

                if (decimalSpeed >= lowLimit)
                {
                    if (decimalSpeed <= highLimit)
                    {
                        return pair.Value / 100.0m;
                    }
                }

                lowLimit = highLimit;
            }

            return co2IndexMap.Last().Value / 100.0m;
        }
    }
}