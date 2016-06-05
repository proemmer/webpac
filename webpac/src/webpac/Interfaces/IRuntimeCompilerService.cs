using System;
using System.Collections.Generic;

namespace webpac.Interfaces
{
    /// <summary>
    /// Interface for runtime compiler service to get the dynamic compiled types
    /// </summary>
    public interface IRuntimeCompilerService : IService
    {
        /// <summary>
        /// Return all dynamic compiled types
        /// </summary>
        /// <returns></returns>
        IEnumerable<Type> GetTypes();
    }
}