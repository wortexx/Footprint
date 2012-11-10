using System;
using System.Collections.Generic;
using System.Device.Location;
using Microsoft.Phone.Scheduler;
using Mobile.Common.Infrastructure;
using Mobile.Common.Model;
using System.Linq;

namespace Mobile.ScheduledAgentApp
{
    public class ScheduledAgent : ScheduledTaskAgent
    {
        protected override void OnInvoke(ScheduledTask task)
        {
            if (task is ResourceIntensiveTask)
            {
                StoreCoordinates();

            }

            NotifyComplete();
        }

        private void StoreCoordinates()
        {
            GeoCoordinateWatcher geoCoordinateWatcher = new GeoCoordinateWatcher();
            var currentPosition = geoCoordinateWatcher.Position;
            {
                if (currentPosition.Location.IsUnknown)
                {
                    geoCoordinateWatcher.PositionChanged += PositionChanged;
                    geoCoordinateWatcher.Start();
                }
                else
                {
                    UpdatePositionList(currentPosition);
                }
            }
        }

        private void PositionChanged(object sender, GeoPositionChangedEventArgs<GeoCoordinate> e)
        {
            UpdatePositionList(e.Position);
            var geoCoordinateWatcher = sender as GeoCoordinateWatcher;
            if (geoCoordinateWatcher != null)
            {
                geoCoordinateWatcher.PositionChanged -= PositionChanged;
            }
        }

        private void UpdatePositionList(GeoPosition<GeoCoordinate> currentPosition)
        {
            var positionList = IsolatedStorageHelper.GetValue<List<Position>>(IsolatedStorageHelper.PositionPointListKey);
            Position position = GetPosition(currentPosition);
            if (positionList != null)
            {
                positionList.Add(position);

                IsolatedStorageHelper.SetValue(IsolatedStorageHelper.PositionPointListKey, positionList);
                TryToPushData(positionList);
            }
        }

        private void TryToPushData(List<Position> positionList)
        {
            Position first = positionList.FirstOrDefault();
            while (first != null)
            {
                PushPosition(first);
                positionList.Remove(first);
                IsolatedStorageHelper.SetValue(IsolatedStorageHelper.PositionPointListKey, positionList);
            }
        }

        private void PushPosition(Position first)
        {
            throw new NotImplementedException();
        }

        private Position GetPosition(GeoPosition<GeoCoordinate> position)
        {
            if (position.Location.IsUnknown)
            {
                return null;
            }
            return new Position
                       {
                           Latitude = position.Location.Latitude,
                           Longitude = position.Location.Longitude,
                           Speed = position.Location.Speed,
                           UtcTicks = position.Timestamp.UtcTicks
                       };
        }
    }
}