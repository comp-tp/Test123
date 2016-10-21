using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accela.Infrastructure.Configurations
{
    public interface IConfigurationReader
    {
        string Get(string key);

        string Get(string key, string defaultValue);

        string Get(string key, bool throwKeyNotFoundException);

        T Get<T>(string key) where T : struct, IConvertible;

        T Get<T>(string key, T defaultValue) where T : struct, IConvertible;

        T Get<T>(string key, bool throwKeyNotFoundException) where T : struct, IConvertible;

     }


    public interface IConfigurationReaderAsync : IConfigurationReader
    {
        Task<T> GetAsync<T>(string key) where T : IConvertible;

        Task<T> GetAsync<T>(string key, T defaultValue) where T : IConvertible;

        Task<T> GetAsync<T>(string key, bool throwKeyNotFoundException) where T : IConvertible;
    }
}
    