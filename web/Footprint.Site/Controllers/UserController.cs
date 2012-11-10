using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Web.Http;
using Footprint.Common;
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
                        var hashenc = SecurityHelper.CalculateHash(login.Email);
                        return new LoginResponseModel
                         {
                             Token = hashenc,
                             UserName = login.Email
                         };
                    }

                }
            }
            return new LoginResponseModel();

        }

        
    }
}
