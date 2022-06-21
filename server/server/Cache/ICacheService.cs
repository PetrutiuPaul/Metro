namespace server.Cache
{
    public interface ICacheService
    {
        string Get(string key);
        void Set(string key, object data, long cacheTime);
        void Remove(string key);
        void Clear();
    }
}
