namespace Scrawler.Models.Services
{
    public interface IHashProvider
    {
        string GetSHA(string plaintext);
    }
}