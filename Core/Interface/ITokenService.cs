using WebStore.Core.Models;

namespace WebStore.Core.Interface;
public interface ITokenService
{
    string GenerateToken(AppUser user);
}
