using Microsoft.Extensions.Configuration;

namespace webpac.Interfaces
{
    public interface IService
    {
        void Configure(IConfigurationSection config);
        void Init();
        void Release();

    }
}
