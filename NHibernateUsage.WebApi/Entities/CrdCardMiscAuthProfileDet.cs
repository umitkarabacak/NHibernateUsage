namespace NHibernateUsage.WebApi.Entities;

public class CrdCardMiscAuthProfileDet
{
    public virtual Guid CardMiscAuthProfileGuid { get; set; }
    public virtual decimal FallbackAmount { get; set; }
    public virtual CrdCardMiscAuthProfileDef CrdCardMiscAuthProfileDef { get; set; }
}