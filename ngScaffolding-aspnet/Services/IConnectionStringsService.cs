namespace ngScaffolding.Services
{
    public interface IConnectionStringsService
    {
        void Add(string Name, string Value);
        string Get(string Name);
    }
}