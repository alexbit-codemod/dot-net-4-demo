using Newtonsoft.Json;

namespace LegacyMigrationDemo.Core
{
    public sealed class UserSummary
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }
    }
}
