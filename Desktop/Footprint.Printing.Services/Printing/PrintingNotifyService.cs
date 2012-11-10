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

            var request = new RestRequest("login", Method.POST);
            request.AddParameter("UserName", Settings.Default.UserName); // adds to POST or URL querystring based on Method
            request.AddParameter("Token", Settings.Default.Token); // adds to POST or URL querystring based on Method
            request.AddParameter("PagesPrinted", pagesPrinted); // adds to POST or URL querystring based on Method



            // or automatically deserialize result
            // return content type is sniffed but can be explicitly set via RestClient.AddHandler();
            IRestResponse<PrintingNotifyResult> response = client.Execute<PrintingNotifyResult>(request);
            if (response.Data.Result)
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