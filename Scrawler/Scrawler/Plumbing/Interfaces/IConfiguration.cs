namespace Scrawler.Plumbing.Interfaces
{
    public interface IConfiguration
    {
        string GetBaseUrl(string hiddenUrl = "funroom");
        string ConnectionString { get; }
    }
}