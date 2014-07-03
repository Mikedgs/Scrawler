using System.Web;

namespace Scrawler.Models
{
    public class ResponseProxy : IResponseProxy
    {
        public void AddHeader(string header, string value)
        {
            HttpContext.Current.Response.Headers.Add(header,value);
        }
    }
}