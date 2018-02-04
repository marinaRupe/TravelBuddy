using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using TravelBuddy.DAL.Mappings;
using NHibernate.Tool.hbm2ddl;
using System.IO;

namespace TravelBuddy.DAL
{
    public class SessionFactory
    {
        private static SessionFactory _instance;
        private readonly ISessionFactory _factory;

        private SessionFactory()
        {
            var databaseName = "TravelBuddy.db";
            var fluentConfig = Fluently.Configure()
                .Database(SQLiteConfiguration.Standard.ConnectionString("Data Source=" + databaseName + ";Version=3").AdoNetBatchSize(1)
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
            if (!File.Exists(databaseName))
            {
                var schemaExport = new SchemaExport(nhConfiguration);
                schemaExport.Create(false, true);
            }
            _factory = nhConfiguration.BuildSessionFactory();
        }

        public static ISessionFactory GetSessionFactory()
        {
            if (_instance == null)
            {
                _instance = new SessionFactory();
            }
            return _instance._factory;
        }
    }
}
