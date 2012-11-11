using System;
using System.Collections.Generic;
using Microsoft.Phone.Scheduler;
using Microsoft.Phone.Tasks;
using Mobile.Common.Infrastructure;
using Mobile.Common.Model;
using Mobile.PhoneApp.ViewModel;
using RestSharp;

namespace Mobile.PhoneApp.Commands
{
    public class PushDataCommand : BaseCommand<MainViewModel>
    {
        public PushDataCommand(MainViewModel viewModel)
            : base(viewModel)
        {
        }

        public override bool CanExecute(object parameter)
        {
            return true;
        }

        public override void Execute(object parameter)
        {
            var tempList = XmlHelper.DeSerialize<List<Temp>>(TempDataString);
            Temp previous = null;
            var positionList = new List<Position>();
            var beginning = new DateTime(2012, 11, 11, 12, 10, 0).ToUniversalTime();

            var random = new Random();

            double secondsCount = 0;

            foreach (var temp in tempList)
            {
                var position = new Position();
                position.Latitude = temp.Latitude;
                position.Longitude = temp.Longitude;
                position.Speed = 30 + (random.NextDouble() / 2.0);

                DateTime positionMoment = beginning;
                double seconds = temp.Seconds / 7.0;
                if (previous != null)
                {
                    positionMoment = positionMoment.AddSeconds(seconds);
                }

                secondsCount += seconds;

                position.UtcTicks = positionMoment.Ticks;
                positionList.Add(position);

                previous = temp;
            }


            foreach (var position in positionList)
            {
                RestClient restClient = WebApi.GetClient();
                var request = new RestRequest("api/position/add?token={token}", Method.POST);
                request.AddUrlSegment("token", "dummy@gmail.com");
                request.RequestFormat = DataFormat.Json;
                request.AddBody(position);
                restClient.ExecuteAsync(request, resonse => {});
            }

        }

        private const string TempDataString = @"<ArrayOfTemp xmlns='http://schemas.datacontract.org/2004/07/Mobile.PhoneApp.Commands' xmlns:i='http://www.w3.org/2001/XMLSchema-instance'><Temp><Latitude>50.436589321785</Latitude><Longitude>30.4918257473644</Longitude><Seconds>0</Seconds></Temp><Temp><Latitude>50.4362476437051</Latitude><Longitude>30.4888002155956</Longitude><Seconds>460</Seconds></Temp><Temp><Latitude>50.4372043361142</Latitude><Longitude>30.4884568928417</Longitude><Seconds>294</Seconds></Temp><Temp><Latitude>50.4390903302324</Latitude><Longitude>30.4860965489086</Longitude><Seconds>214</Seconds></Temp><Temp><Latitude>50.4372180030085</Latitude><Longitude>30.4866973637279</Longitude><Seconds>389</Seconds></Temp><Temp><Latitude>50.4349629120551</Latitude><Longitude>30.4902807949718</Longitude><Seconds>314</Seconds></Temp><Temp><Latitude>50.432885399869</Latitude><Longitude>30.4884998081859</Longitude><Seconds>431</Seconds></Temp></ArrayOfTemp>";
       
    }

    public class Temp
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public int Seconds { get; set; }
    }
}