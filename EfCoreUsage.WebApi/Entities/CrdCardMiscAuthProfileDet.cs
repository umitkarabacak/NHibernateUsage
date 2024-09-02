namespace EfCoreUsage.WebApi.Entities;

public class CrdCardMiscAuthProfileDet
{
    public Guid CardMiscAuthProfileGuid { get; set; }
    public decimal FallbackAmount { get; set; }
    public CrdCardMiscAuthProfileDef CrdCardMiscAuthProfileDef { get; set; }
}