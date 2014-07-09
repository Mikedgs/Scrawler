namespace Scrawler.Models.Services
{
    public interface IHashProvider
    {
        string GetSha(string plaintext);
    }
}