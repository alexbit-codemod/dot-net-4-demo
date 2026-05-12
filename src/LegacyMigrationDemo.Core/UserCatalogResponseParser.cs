using System.Collections.Generic;
using Newtonsoft.Json;

namespace LegacyMigrationDemo.Core
{
    public static class UserCatalogResponseParser
    {
        public static IReadOnlyList<UserSummary> Parse(string json)
        {
            return JsonConvert.DeserializeObject<List<UserSummary>>(json)
                   ?? new List<UserSummary>();
        }
    }
}
