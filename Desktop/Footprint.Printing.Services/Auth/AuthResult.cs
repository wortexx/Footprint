namespace Footprint.Printing.Services.Auth
{
    public class AuthResult
    {
        public bool Result;
        public string UserName;
        public string Token;
        public string Error { get; set; }
    }
}