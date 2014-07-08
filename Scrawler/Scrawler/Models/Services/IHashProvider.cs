namespace Scrawler.Models.Services
{
    public interface IHashProvider
    {
        string GetSha(string plaintext); // TODO BA move to tinterfaces
    }
}