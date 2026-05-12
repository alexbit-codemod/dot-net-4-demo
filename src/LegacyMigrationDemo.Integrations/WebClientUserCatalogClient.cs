using System;
using System.Net;
using LegacyMigrationDemo.Core;

namespace LegacyMigrationDemo.Integrations
{
    public sealed class WebClientUserCatalogClient : IUserCatalogClient
    {
        private readonly Uri _baseAddress;

        public WebClientUserCatalogClient(Uri baseAddress)
        {
            _baseAddress = baseAddress ?? throw new ArgumentNullException(nameof(baseAddress));
        }

        public string DownloadUsersJson()
        {
            using (var client = new WebClient())
            {
                client.BaseAddress = _baseAddress.ToString();
                return client.DownloadString(new Uri("/users", UriKind.Relative));
            }
        }
    }
}
