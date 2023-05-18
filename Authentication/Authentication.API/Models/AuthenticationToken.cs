namespace Authentication.API.Models
{
    public class AuthenticationToken
    {        

        public AuthenticationToken(string token, int expiresIn)
        {
            Token = token;
            ExpiresIn = expiresIn;
        }
        public string Token { get; set; }

        public int ExpiresIn { get; set; }
    }
}
