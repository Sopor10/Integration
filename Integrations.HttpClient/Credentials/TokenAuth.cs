namespace Integrations.HttpClient.Credentials
{
    public record TokenAuth(string Token, string Prefix)
    {
        
    }

    public class TokenAuthProvider
    {
        public TokenAuth FromLiteral(string token, string prefix)
        {
            return new(token, prefix);
        }

        public TokenAuth Bearer(string token)
        {
            return new("Bearer", token);
        }
        
    }
}