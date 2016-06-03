using webpac.Models;

namespace webpac.Interfaces
{
    public interface IAuthenticationService : IService
    {
        bool TryAuthorize(string username, string password, ref User user);
    }
}
