using System;
using System.Configuration;
using System.Linq;
using LegacyMigrationDemo.Core;
using LegacyMigrationDemo.Integrations;

namespace LegacyMigrationDemo
{
    internal static class Program
    {
        private static int Main()
        {
            var baseUrlSetting = ConfigurationManager.AppSettings["ApiBaseUrl"];
            if (string.IsNullOrWhiteSpace(baseUrlSetting))
            {
                Console.Error.WriteLine("Missing AppSettings key ApiBaseUrl.");
                return 1;
            }

            var catalogConnection = ConfigurationManager.ConnectionStrings["CatalogDatabase"];
            if (catalogConnection == null || string.IsNullOrWhiteSpace(catalogConnection.ConnectionString))
            {
                Console.Error.WriteLine("Missing connectionStrings name CatalogDatabase.");
                return 1;
            }

            // Demonstrates classic configuration surface area (not used by this sample’s HTTP path).
            Console.WriteLine("Catalog connection string is configured (length {0}).", catalogConnection.ConnectionString.Length);

            Uri baseUri;
            try
            {
                baseUri = new Uri(baseUrlSetting, UriKind.Absolute);
            }
            catch (UriFormatException)
            {
                Console.Error.WriteLine("ApiBaseUrl is not a valid absolute URI.");
                return 1;
            }

            IUserCatalogClient client = new WebClientUserCatalogClient(baseUri);

            string json;
            try
            {
                json = client.DownloadUsersJson();
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine("HTTP request failed: {0}", ex.Message);
                return 2;
            }

            var users = UserCatalogResponseParser.Parse(json);
            foreach (var line in users.Take(5).Select(u => string.Format("{0}: {1} <{2}>", u.Id, u.Name, u.Email)))
            {
                Console.WriteLine(line);
            }

            Console.WriteLine("Total users parsed: {0}", users.Count);
            return 0;
        }
    }
}
