using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using TravelBuddy.DAL.Mappings;

namespace TravelBuddy.DAL
{
    public class SessionFactory
    {
        private static SessionFactory _instance;
        private readonly ISessionFactory _factory;

        private SessionFactory()
        {
            var fluentConfig = Fluently.Configure()
                .Database(SQLiteConfiguration.Standard.InMemory()
                .ShowSql().FormatSql())
                .Mappings(m =>
                    {
                        m.FluentMappings.Add<UserMap>();
                        m.FluentMappings.Add<TravelMap>();
                        m.FluentMappings.Add<ActivityMap>();
                        m.FluentMappings.Add<PreliminaryActivityMap>();
                        m.FluentMappings.Add<TravelActivityMap>();
                        m.FluentMappings.Add<TravelActivityWithCostMap>();
                        m.FluentMappings.Add<TravelItemMap>();
                        m.FluentMappings.Add<CurrencyMap>();
                    });

            var nhConfiguration = fluentConfig.BuildConfiguration();
            _factory = nhConfiguration.BuildSessionFactory();
        }

        public ISessionFactory GetSessionFactory()
        {
            if (_instance == null)
            {
                _instance = new SessionFactory();
            }
            return _instance._factory;
        }
    }
}
