using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

namespace Footprint.TestConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                RestClient restClient = new RestClient("http://localhost:2887");
                var request = new RestRequest("api/position/add?token={token}", Method.POST);
                request.AddUrlSegment("token", "dummy@gmail.com");
                request.RequestFormat = DataFormat.Json;
                var position = new Position();
                var random = new Random();
                position.Latitude = 40.0 + random.NextDouble()/1000;
                position.Longitude = 41.0 + random.NextDouble()/1000;
                position.Speed = 8;
                DateTime dateTime = DateTime.UtcNow;
                position.UtcTicks = dateTime.Ticks;
                request.AddBody(position);
                restClient.Execute(request);

                Console.Out.WriteLine("Done");
                Console.In.ReadLine();
            }
        }
    }

    public class Position
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public double Speed { get; set; }
        public long UtcTicks { get; set; }
    }
}
