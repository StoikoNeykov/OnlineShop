using System;
using OnlineShop.ConfigurationProviders.Contracts;
using System.Configuration;

namespace OnlineShop.ConfigurationProviders
{
    public class EnvoirmentProvider : IEnvoirmentProvider
    {
        public string Envoirment
        {
            get
            {
                var result = ConfigurationManager.AppSettings;

                return ConfigurationManager.AppSettings["Envoirment"];
            }
        }
    }
}
