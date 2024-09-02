namespace EfCoreUsage.WebApi.Contexts;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<CrdCardMiscAuthProfileDef> CrdCardMiscAuthProfileDefs { get; set; }
    public DbSet<CrdCardMiscAuthProfileDet> CrdCardMiscAuthProfileDets { get; set; }
}