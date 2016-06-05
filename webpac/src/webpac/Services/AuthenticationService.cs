using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Configuration;
using webpac.Interfaces;
using webpac.Models;

namespace webpac.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private IEnumerable<User> users;
        public int ValidationTimeInMin { get; private set; }

        public void Configure(IConfigurationSection config)
        {
            users = config.Get<User[]>("Users");
            ValidationTimeInMin = config.Get<int>("TokenValidatenTimeinMinutes");
        }

        public void Init()
        {
            
        }

        public void Release()
        {
        }

        public bool TryAuthorize(string username, string password, ref User user)
        {
            user = users.FirstOrDefault(x => x.Username == username);
            if (user == null)
                return false;
            if (!string.Equals(password, user.Password))
                user = null;
            return user != null;
        }
    }
}
