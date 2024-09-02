namespace NHibernateUsage.WebApi.Mappings;

public class CrdCardMiscAuthProfileDetMap : ClassMap<CrdCardMiscAuthProfileDet>
{
    public CrdCardMiscAuthProfileDetMap()
    {
        Table("CRD_CARD_MISC_AUTH_PROFILE_DET");
        Id(x => x.CardMiscAuthProfileGuid).GeneratedBy.Foreign("CrdCardMiscAuthProfileDef");
        Map(x => x.FallbackAmount).Precision(17).Scale(2);
        References(x => x.CrdCardMiscAuthProfileDef)
            .Column("GUID")
            .Cascade.None();
    }
}
