using System;
using OnlineShop.ConfigurationProviders.Contracts;
using System.Configuration;

namespace OnlineShop.ConfigurationProviders
{
    public class ConnectionStringProvider : IConnectionStringProvider
    {
        private IEnvoirmentProvider envoirmentProvider;

        public ConnectionStringProvider(IEnvoirmentProvider envoirmentProvider)
        {
            if (envoirmentProvider == null)
            {
                throw new ArgumentNullException("EnvoirmentProvider");
            }

            this.envoirmentProvider = envoirmentProvider;
        }

        public string ConnectionString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings[envoirmentProvider.Envoirment].ConnectionString;
            }
        }
    }
}
