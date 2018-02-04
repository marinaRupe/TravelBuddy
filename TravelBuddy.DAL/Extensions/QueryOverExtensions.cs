using NHibernate;
using NHibernate.Criterion;
using System;
using System.Linq.Expressions;

namespace TravelBuddy.DAL.Extensions
{
    public static class QueryOverExtensions
    {
        /// <summary>
        /// This method is used in cases where the root type is required
        /// Example: .WhereEqualInsensitive(t => t.Property, stringValue)
        /// </summary>
        public static IQueryOver<T, TU> WhereEqualInsensitive<T, TU>(this IQueryOver<T, TU> queryOver, Expression<Func<T, object>> path, string value)
        {
            return queryOver.Where(Restrictions.Eq(Projections.SqlFunction("lower", NHibernateUtil.String, Projections.Property(path)), value.ToLower()));
        }
    }
}
