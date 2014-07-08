namespace Scrawler.Plumbing.Interfaces
{
    public interface IConfiguration
    {
        string GetBaseUrl(string hiddenUrl);
        string ConnectionString { get; }
    }
}