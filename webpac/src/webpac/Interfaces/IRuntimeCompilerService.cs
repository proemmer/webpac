using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webpac.Interfaces
{
    public interface IRuntimeCompilerService : IService
    {
        IEnumerable<Type> GetTypes();
    }
}