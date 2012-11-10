using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Linq;
using RestSharp;

namespace Footprint.Printing.Services.Auth
{
    public class AuthService : IAuthService
    {
        protected string AuthUri
        {
            get { return ConfigurationManager.AppSettings["AuthUri"]; }
        }

        public IEnumerable<ValidationResult> Login(string login, string password)
        {
            return Enumerable.Empty<ValidationResult>();

            
            var client = new RestClient(this.AuthUri);
            // client.Authenticator = new HttpBasicAuthenticator(username, password);

            var request = new RestRequest("login", Method.POST);
            request.AddParameter("Login", login); // adds to POST or URL querystring based on Method
            request.AddParameter("Password", password); // adds to POST or URL querystring based on Method
            
                       

            // or automatically deserialize result
            // return content type is sniffed but can be explicitly set via RestClient.AddHandler();
            IRestResponse<AuthResult> response = client.Execute<AuthResult>(request);
            if (response.Data.Result)
            {
                return Enumerable.Empty<ValidationResult>();
            }

            return new List<ValidationResult> {new ValidationResult(response.Data.Error)};
        }
    }
}
