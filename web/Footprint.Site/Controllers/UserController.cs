using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web.Http;
using Footprint.Domain;
using Footprint.Site.Models;
using WebMatrix.WebData;

namespace Footprint.Site.Controllers
{
    public class UserController : ApiController
    {
        [AcceptVerbs("Get")]
        public LoginResponseModel Login([FromUri] LoginRequestModel login)
        {
            if (login != null)
            {
                using (var db = new UsersContext())
                {
                    var profile = db.UserProfiles.FirstOrDefault(x => x.UserName == login.Email);

                    if (profile != null)
                    {
                        var tokenGenerator = new TokenGenerator();

                        return new LoginResponseModel
                                   {
                                       Token = tokenGenerator.Generate(login.Email),
                                       UserName = login.Email
                                   };
                    }
                }
            }
            return new LoginResponseModel();
        }
    }
}
