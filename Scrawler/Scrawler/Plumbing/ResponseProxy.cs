using System.Web;
using Scrawler.Plumbing.Interfaces;

namespace Scrawler.Plumbing
{
    public class ResponseProxy : IResponseProxy
    {
        public void AddHeader(string header, string value)
        {
            HttpContext.Current.Response.Headers.Add(header,value);
        }
    }
}