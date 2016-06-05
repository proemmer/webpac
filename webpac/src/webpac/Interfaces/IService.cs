using Microsoft.Extensions.Configuration;

namespace webpac.Interfaces
{
    /// <summary>
    /// Service interface
    /// </summary>
    public interface IService
    {
        void Configure(IConfigurationSection config);
        void Init();
        void Release();

    }
}
