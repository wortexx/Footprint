using System;
using System.Collections.Generic;
using System.Device.Location;
using System.Threading;
using Microsoft.Phone.Scheduler;
using Mobile.Common.Infrastructure;
using Mobile.Common.Model;
using System.Linq;
using RestSharp;

namespace Mobile.ScheduledAgentApp
{
    public class ScheduledAgent : ScheduledTaskAgent
    {
        private readonly ManualResetEvent waitHandle = new ManualResetEvent(false);

        protected override void OnInvoke(ScheduledTask task)
        {
            if (task is ResourceIntensiveTask)
            {
                if (IsolatedStorageHelper.GetValue<bool>(IsolatedStorageHelper.IsTrackingRunningKey))
                {
                    StoreCoordinates();
                }

            }

            NotifyComplete();
        }

        private void StoreCoordinates()
        {
            GeoCoordinateWatcher geoCoordinateWatcher = new GeoCoordinateWatcher();
            var currentPosition = geoCoordinateWatcher.Position;
            if (currentPosition.Location.IsUnknown)
            {
                bool tryStart = geoCoordinateWatcher.TryStart(true, TimeSpan.FromSeconds(10));
                UpdatePositionList(geoCoordinateWatcher.Position);

//                geoCoordinateWatcher.PositionChanged += PositionChanged;
//                geoCoordinateWatcher.Start();
            }
            else
            {
                UpdatePositionList(currentPosition);
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
            if (positionList == null)
            {
                positionList = new List<Position>();
            }
            Position position = GetPosition(currentPosition);
            if (position != null)
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
                first = positionList.FirstOrDefault();
            }
        }

        private void PushPosition(Position position)
        {
            RestClient restClient = WebApi.GetClient();
            var request = new RestRequest("api/position/add?token={token}", Method.POST);
            request.AddUrlSegment("token", GetToken());
            request.RequestFormat = DataFormat.Json;
            request.AddBody(position);
            restClient.ExecuteAsync(request, response => waitHandle.Set());
            waitHandle.WaitOne();
        }

        private static string GetToken()
        {
            var token = IsolatedStorageHelper.GetValue<string>(IsolatedStorageHelper.AuthenticationTokenKey);
            if (string.IsNullOrWhiteSpace(token))
            {
                return "ChuckNorrisDoesNotNeedToken";
            }
            return token;
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