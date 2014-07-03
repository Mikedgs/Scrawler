namespace Scrawler.Models
{
    public interface IResponseProxy
    {
        void AddHeader(string header, string value);
    }
}