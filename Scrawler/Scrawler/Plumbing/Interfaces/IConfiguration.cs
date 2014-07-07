namespace Scrawler.Plumbing
{
    public interface IConfiguration
    {
        string GetBaseUrl(string hiddenUrl);
        string GetConnectionString();
    }
}