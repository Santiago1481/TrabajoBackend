namespace WebApi.Jwt
{
    public interface ITokenService
    {
        string CreateToken(int userId, string Email);
    }
}
