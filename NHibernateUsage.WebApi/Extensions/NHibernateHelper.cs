namespace NHibernateUsage.WebApi.Extensions;

public static class NHibernateHelper
{
    private static ISessionFactory _sessionFactory;
    private static NHibernate.ISession _session;

    public static ISessionFactory CreateSessionFactory()
    {
        if (_sessionFactory != null)
            return _sessionFactory;

        // NHibernate yapılandırma nesnesi
        var configuration = Fluently.Configure()
            .Database(SQLiteConfiguration.Standard.InMemory().ShowSql())
            .Mappings(m => m.FluentMappings.AddFromAssemblyOf<CrdCardMiscAuthProfileDefMap>())
            .ExposeConfiguration(cfg =>
            {
                // Şema oluşturmayı yapılandırma aşamasında yap
                new SchemaExport(cfg).Create(false, true);
            })
            .BuildConfiguration();

        // Oturum fabrikası oluştur
        _sessionFactory = configuration.BuildSessionFactory();

        // Oturumu aç ve şemayı uygula
        _session = _sessionFactory.OpenSession();
        using (var transaction = _session.BeginTransaction())
        {
            new SchemaExport(configuration).Execute(true, true, false, _session.Connection, null);
            transaction.Commit();
        }

        return _sessionFactory;
    }

    public static NHibernate.ISession GetCurrentSession()
    {
        if (_session == null || !_session.IsOpen)
        {
            _session = _sessionFactory.OpenSession();
        }
        return _session;
    }
}
