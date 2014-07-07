using System;
using System.Configuration;

namespace Scrawler.Plumbing
{
    public class Configuration : IConfiguration
    {
        public string GetBaseUrl(string hiddenUrl)
        {
            return String.Concat(ConfigurationManager.AppSettings["FrontEndBaseUrl"],hiddenUrl);
        }

        public string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }
    }
}