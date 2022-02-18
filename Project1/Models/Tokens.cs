namespace Project1.Models
{
    public class Tokens
    {
        public string Token { get; set; }
        public string RefreshToken { get; set; }
    }

    public interface IJWTManager
    {
        Tokens Authenticate(Users users);
    }
}
