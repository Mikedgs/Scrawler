using System;
using System.Configuration;
using Scrawler.Plumbing.Interfaces;

namespace Scrawler.Plumbing
{
    public class Configuration : IConfiguration
    {
        public string GetBaseUrl(string hiddenUrl)
        {
            return String.Concat(ConfigurationManager.AppSettings["FrontEndBaseUrl"], hiddenUrl);
        }

        public string GetSplashUrl()
        {
            return ConfigurationManager.AppSettings["SplashPageUrl"];
        }

        public string ConnectionString
        {
            get { return ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString; }
        }
    }
}