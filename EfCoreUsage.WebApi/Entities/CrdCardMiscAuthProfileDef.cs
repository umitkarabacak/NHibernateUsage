namespace EfCoreUsage.WebApi.Entities;

public class CrdCardMiscAuthProfileDef
{
    public Guid Guid { get; set; }
    public string Description { get; set; }
    public bool IsValid { get; set; }
    public int Code { get; set; }
    public CrdCardMiscAuthProfileDet CrdCardMiscAuthProfileDet { get; set; }
}
