namespace EfCoreUsage.WebApi.Contexts;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<CrdCardMiscAuthProfileDef> CrdCardMiscAuthProfileDefs { get; set; }
    public DbSet<CrdCardMiscAuthProfileDet> CrdCardMiscAuthProfileDets { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // CrdCardMiscAuthProfileDef için birincil anahtar tanımla
        modelBuilder.Entity<CrdCardMiscAuthProfileDef>()
            .HasKey(p => p.Guid);

        // CrdCardMiscAuthProfileDet için birincil anahtar tanımla
        modelBuilder.Entity<CrdCardMiscAuthProfileDet>()
            .HasKey(d => d.CardMiscAuthProfileGuid);

        // Bire bir ilişkiyi tanımlayın
        modelBuilder.Entity<CrdCardMiscAuthProfileDef>()
            .HasOne(p => p.CrdCardMiscAuthProfileDet)
            .WithOne(d => d.CrdCardMiscAuthProfileDef)
            .HasForeignKey<CrdCardMiscAuthProfileDet>(d => d.CrdCardMiscAuthProfileDefId)
            .OnDelete(DeleteBehavior.Cascade) // İlişkili veriyi silerken davranış ayarlama
            .IsRequired(); // Bu ilişkinin gerekli olduğunu belirtir
    }
}