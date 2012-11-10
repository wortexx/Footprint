using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Footprint.Site.Models;

namespace Footprint.Site.Controllers
{
    public class UserController : ApiController
    {
        [AcceptVerbs("Get")]
        public LoginResponseModel Login([FromUri] LoginRequestModel login)
        {
            if (login != null)
            {
                return new LoginResponseModel
                           {
                               Token = "dsfdlkflkjqlwejrweqlkrjlkwejrkweqjr ljiqwerjn ,mdfn idasjf ",
                               UserName = "Vasua Pupkin"
                           };
            }
            return new LoginResponseModel();
        }
    }
}
