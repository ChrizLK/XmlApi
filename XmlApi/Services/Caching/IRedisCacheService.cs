namespace XmlApi.Services.Caching
{
    public interface IRedisCacheService
    {
        T? Get<T>(string key);
        void SetData<T>(string key, T data);
    }
}
