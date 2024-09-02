namespace EfCoreUsage.WebApi.Entities;

public class CrdCardMiscAuthProfileDet
{
    // Bu varlık için birincil anahtar tanımla
    public Guid CardMiscAuthProfileGuid { get; set; }
    public decimal FallbackAmount { get; set; }

    // Bire bir ilişki için navigasyon özelliği
    public CrdCardMiscAuthProfileDef CrdCardMiscAuthProfileDef { get; set; }

    // Yabancı anahtar (foreign key)
    public Guid CrdCardMiscAuthProfileDefId { get; set; }
}