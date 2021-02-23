using System.Collections.Generic;

namespace PingCommand.Infrastructure
{
    public interface ICacheProvider<T>
    {
        List<T> GetAll(string key);

        void AddAll(string key, List<T> values);
    }
}
