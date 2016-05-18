using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;

namespace webpac.Interfaces
{
    public interface IMappingService : IService, IDisposable
    {
        IEnumerable<string> GetDataBlocks();
        IEnumerable<string> GetSymbols();
        Dictionary<string, object> Read(string mapping, params string[] vars);
        bool Write(string mapping, Dictionary<string, object> values);
    }
}
