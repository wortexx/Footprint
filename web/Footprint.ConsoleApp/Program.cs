using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Footprint.Site.Models;
using RestSharp;

namespace Footprint.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var restClient = new RestClient("http://localhost:2877");
            var request = new RestRequest("api/position/add?token={token}", Method.POST);
            request.AddUrlSegment("token", "dummy@gmail.com");
            request.RequestFormat = DataFormat.Json;
            var position = new Position();
            position.Latitude = 42.245;
            position.Longitude = 34.534;
            position.Speed = 10.343;
            position.UtcTicks = DateTime.UtcNow.Ticks;
            request.AddBody(position);
            restClient.Execute(request);
            Console.Out.WriteLine("Done");
            Console.In.ReadLine();
        }
    }
}
