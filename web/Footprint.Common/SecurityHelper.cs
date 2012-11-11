using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Footprint.Common
{
    public static class SecurityHelper
    {
        public static string CalculateHash(string login)
        {            
            var hash = Encoding.UTF8.GetBytes(login);
            var md5 = new MD5CryptoServiceProvider();
            var hashenc = Convert.ToBase64String(md5.ComputeHash(hash));
            return hashenc;
        }
    }
}
