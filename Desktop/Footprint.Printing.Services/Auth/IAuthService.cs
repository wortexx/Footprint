using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Footprint.Printing.Services.Auth
{
    public interface IAuthService
    {
        IEnumerable<ValidationResult> Login(string login, string password);
    }
}