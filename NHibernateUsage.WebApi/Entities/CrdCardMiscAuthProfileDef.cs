namespace NHibernateUsage.WebApi.Entities;

public class CrdCardMiscAuthProfileDef
{
    public virtual Guid Guid { get; set; }
    public virtual string Description { get; set; }
    public virtual bool IsValid { get; set; }
    public virtual int Code { get; set; }
    public virtual CrdCardMiscAuthProfileDet CrdCardMiscAuthProfileDet { get; set; }
}
