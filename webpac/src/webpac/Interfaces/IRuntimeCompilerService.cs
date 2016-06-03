using System;
using System.Collections.Generic;

namespace webpac.Interfaces
{
    public interface IRuntimeCompilerService : IService
    {
        IEnumerable<Type> GetTypes();
    }
}