namespace NHibernateUsage.WebApi.Mappings;

public class CrdCardMiscAuthProfileDefMap : ClassMap<CrdCardMiscAuthProfileDef>
{
    public CrdCardMiscAuthProfileDefMap()
    {
        Table("CRD_CARD_MISC_AUTH_PROFILE_DEF");
        Id(x => x.Guid).GeneratedBy.GuidComb();
        Map(x => x.Description).Length(4000);
        Map(x => x.IsValid);
        Map(x => x.Code).Precision(4);

        HasOne(x => x.CrdCardMiscAuthProfileDet)
            .Cascade.All();
    }
}
