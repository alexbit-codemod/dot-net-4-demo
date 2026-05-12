using Microsoft.EntityFrameworkCore;

namespace DemoApp.Legacy.Data;

public sealed class LegacyOrder
{
    public int Id { get; set; }

    public string Name { get; set; } = "";
}

public sealed class LegacyCatalogContext : DbContext
{
    // TODO(dotnet-appconfig-to-appsettings): connection string "LegacyCatalog" needs to move to appsettings.json (ConnectionStrings:LegacyCatalog) and be injected via DI.
    public LegacyCatalogContext(DbContextOptions<LegacyCatalogContext> options)
        : base(options)
    {
    }

    public DbSet<LegacyOrder> Orders { get; set; }
}
