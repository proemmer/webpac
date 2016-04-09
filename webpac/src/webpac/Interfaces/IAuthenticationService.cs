using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webpac.Models;

namespace webpac.Interfaces
{
    public interface IAuthenticationService : IService
    {
        bool TryAuthorize(string username, string password, ref User user);
    }
}
