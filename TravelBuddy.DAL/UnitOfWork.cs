using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using TravelBuddy.DAL.Mappings;

namespace TravelBuddy.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private static readonly ISessionFactory _sessionFactory;
        private ITransaction _transaction;

        public ISession Session { get; private set; }

        static UnitOfWork()
        {
            // Initialise singleton instance of ISessionFactory, static constructors are only executed once during the
            // application lifetime - the first time the UnitOfWork class is used
            const string databaseName = "TravelBuddy.db";
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
            _sessionFactory = nhConfiguration.BuildSessionFactory();
        }

        public UnitOfWork()
        {
            Session = _sessionFactory.OpenSession();
        }

        public void BeginTransaction()
        {
            _transaction = Session.BeginTransaction();
        }

        public void Commit()
        {
            try
            {
                // commit transaction if there is one active
                if (_transaction != null && _transaction.IsActive)
                    _transaction.Commit();
            }
            catch
            {
                // rollback if there was an exception
                if (_transaction != null && _transaction.IsActive)
                    _transaction.Rollback();

                throw;
            }
            finally
            {
                Session.Dispose();
            }
        }

        public void Rollback()
        {
            try
            {
                if (_transaction != null && _transaction.IsActive)
                    _transaction.Rollback();
            }
            finally
            {
                Session.Dispose();
            }
        }
    }
}
