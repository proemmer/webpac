﻿using Webpac.Models;

namespace Webpac.Interfaces
{
    public interface IAuthenticationService : IService
    {
        bool TryAuthorize(string username, string password, ref User user);
        int ValidationTimeInMin { get;  }
    }
}
