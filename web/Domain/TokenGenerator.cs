using System;
using System.Security.Cryptography;
using System.Text;

namespace Footprint.Domain
{
    public class TokenGenerator
    {
         public string Generate(string username)
         {
             var hash = Encoding.UTF8.GetBytes(username);
             var md5 = new MD5CryptoServiceProvider();
             var hashenc = Convert.ToBase64String(md5.ComputeHash(hash));

             return hashenc;
         }
    }
}