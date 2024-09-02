namespace EfCoreUsage.WebApi.Entities;

public class CrdCardMiscAuthProfileDef
{
    // Birincil anahtar (primary key)
    public Guid Guid { get; set; }

    public string Description { get; set; }
    public bool IsValid { get; set; }
    public int Code { get; set; }

    // Bire bir ilişki için navigasyon özelliği
    public CrdCardMiscAuthProfileDet CrdCardMiscAuthProfileDet { get; set; }
}