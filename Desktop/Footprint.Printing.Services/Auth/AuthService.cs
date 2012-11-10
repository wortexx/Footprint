using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Linq;
using Footprint.Printing.Services.Properties;
using NLog;
using RestSharp;

namespace Footprint.Printing.Services.Auth
{
    public class AuthService : IAuthService
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        protected string AuthUri
        {
            get { return ConfigurationManager.AppSettings["AuthUri"]; }
        }
        
        public AuthService()
        {
        
        }

        public IEnumerable<ValidationResult> Login(string login, string password)
        {
            Logger.Info(string.Format("Trying to login user {0}", login));
            
            if (password == null)
            {
                password = string.Empty;
            }

            var client = new RestClient(this.AuthUri);
            // client.Authenticator = new HttpBasicAuthenticator(username, password);

            var request = new RestRequest("api/user/login", Method.GET);
            request.AddParameter("email", login); // adds to POST or URL querystring based on Method
            request.AddParameter("password", password); // adds to POST or URL querystring based on Method
            

            // or automatically deserialize result
            // return content type is sniffed but can be explicitly set via RestClient.AddHandler();
            IRestResponse<LoginResponseModel> response = client.Execute<LoginResponseModel>(request);
            if (!string.IsNullOrEmpty(response.Data.UserName))
            {
                Settings.Default.UserName = response.Data.UserName;
                Settings.Default.Token = response.Data.Token;
                return Enumerable.Empty<ValidationResult>();
            }

            return new List<ValidationResult> {new ValidationResult("Login or password is wrong")};
        }
    }
}
