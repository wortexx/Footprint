using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Linq;
using Footprint.Printing.Services.Auth;
using Footprint.Printing.Services.Properties;
using RestSharp;

namespace Footprint.Printing.Services.Printing
{
    public class PrintingNotifyService : IPrintingNotifyService
    {
        public void OnPrinted(int pagesPrinted)
        {
            var client = new RestClient(this.PrintingNotifyUri);

            var request = new RestRequest("api/printing/add", Method.GET);
            request.AddParameter("token", Settings.Default.Token); // adds to POST or URL querystring based on Method
            request.AddParameter("pages", pagesPrinted); // adds to POST or URL querystring based on Method



            // or automatically deserialize result
            // return content type is sniffed but can be explicitly set via RestClient.AddHandler();
            IRestResponse<bool> response = client.Execute<bool>(request);
            if (response.Data)
            {
                return;
            }
            
            return;
        }

        protected string PrintingNotifyUri
        {
            get { return ConfigurationManager.AppSettings["PrintingNotifyUri"]; }
        }
    }
}