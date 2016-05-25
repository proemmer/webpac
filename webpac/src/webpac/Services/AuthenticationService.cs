using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using webpac.Controllers;
using webpac.Interfaces;
using Newtonsoft.Json;
using webpac.Models;

namespace webpac.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private IEnumerable<User> Users;

        public void Configure(IConfigurationSection config)
        {
            Users = config.Get<User[]>("Users");
        }

        public void Init()
        {
            
        }

        public void Release()
        {
        }

        public bool TryAuthorize(string username, string password, ref User user)
        {
            user = Users.FirstOrDefault(x => x.Username == username);
            if (user == null)
                return false;
            if (!string.Equals(password, user.Password))
                user = null;
            return user != null;
        }
    }
}
