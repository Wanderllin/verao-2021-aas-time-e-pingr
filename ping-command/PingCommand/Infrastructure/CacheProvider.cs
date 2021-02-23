using StackExchange.Redis;
using System.Collections.Generic;
using System.Text.Json;

namespace PingCommand.Infrastructure
{
    public class CacheProvider<T> : ICacheProvider<T>
    {
        private readonly IDatabase Redis;

        public CacheProvider()
        {
            Redis = ConnectionMultiplexer.Connect("localhost:6379").GetDatabase();
        }

        public void AddAll(string key, List<T> values)
        {
            Redis.StringSet(key, JsonSerializer.Serialize(values));
        }

        public List<T> GetAll(string key)
        {
            try
            {
                return JsonSerializer.Deserialize<List<T>>(Redis.StringGet(key));
            }
            catch
            {
                return new List<T>();
            }
        }
    }
}
