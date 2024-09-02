namespace NHibernateUsage.WebApi.Extensions;

public static class NHibernateHelper
{
    public static ISessionFactory CreateSessionFactory()
    {
        return Fluently.Configure()
            .Database(SQLiteConfiguration.Standard.InMemory().ShowSql())
            .Mappings(m => m.FluentMappings.AddFromAssemblyOf<CrdCardMiscAuthProfileDefMap>())
            .ExposeConfiguration(cfg => new SchemaExport(cfg).Create(false, true))
            .BuildSessionFactory();
    }
}