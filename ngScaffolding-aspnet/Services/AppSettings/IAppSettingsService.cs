namespace ngScaffolding.Services
{
    public interface IAppSettingsService
    {
        string AuthEndpoint { get; set; }
        string AuthAudience { get; set; }
        string UserInfoEndpoint { get; set; }
    }
}