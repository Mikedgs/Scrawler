namespace Scrawler.Plumbing.Interfaces
{
    public interface IConfiguration
    {
        string ConnectionString { get; }
        string GetBaseUrl(string hiddenUrl = "funroom");
        string GetSplashUrl();
    }
}