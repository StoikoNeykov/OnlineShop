using System;
using OnlineShop.ConfigurationProviders.Contracts;
using System.Configuration;
using Bytes2you.Validation;

namespace OnlineShop.ConfigurationProviders
{
    public class ConnectionStringProvider : IConnectionStringProvider
    {
        private IEnvoirmentProvider envoirmentProvider;

        public ConnectionStringProvider(IEnvoirmentProvider envoirmentProvider)
        {
            Guard.WhenArgument(envoirmentProvider, nameof(envoirmentProvider)).IsNull().Throw();

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
