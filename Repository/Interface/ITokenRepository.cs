using Microsoft.AspNetCore.Identity;

namespace CodePulseAPI.Repository.Interface
{
    public interface ITokenRepository
    {
        string CreateJwtToken(IdentityUser user, List<string> roles);
    }
}
