using System.Collections.Generic;

namespace PingQuery.Infrastructure
{
    public interface ICacheProvider<T>
    {
        List<T> GetAll(string key);
    }
}
