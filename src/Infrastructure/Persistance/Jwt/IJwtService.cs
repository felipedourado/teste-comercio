using TesteComercio.Domain.Entities.Users;
using System.Threading.Tasks;

namespace TesteComercio.Persistence.Jwt
{
    public interface IJwtService
    {
        Task<AccessToken> GenerateAsync(User user);
        int? ValidateJwtAccessTokenAsync(string token);
    }
}
