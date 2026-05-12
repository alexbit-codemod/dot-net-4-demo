using System.Data.Entity;

namespace DemoApp.Legacy.Data;

public sealed class LegacyOrder
{
    public int Id { get; set; }

    public string Name { get; set; } = "";
}

public sealed class LegacyCatalogContext : DbContext
{
    public LegacyCatalogContext()
        : base("name=LegacyCatalog")
    {
    }

    public DbSet<LegacyOrder> Orders { get; set; }
}
