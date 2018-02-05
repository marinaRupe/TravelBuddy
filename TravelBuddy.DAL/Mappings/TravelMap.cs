using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using TravelBuddy.Models;

namespace TravelBuddy.DAL.Mappings
{
    public class TravelMap : ClassMap<Travel>
    {
        public TravelMap()
        {
            Id(x => x.Id).GeneratedBy.Guid();
            Map(x => x.Name);
            Map(x => x.DateStart);
            Map(x => x.DateEnd);
            Map(x => x.Description);
            Map(x => x.IsArchived);

            Component(x => x.Budget,
                mapping =>
                {
                    mapping.Map(y => y.Value);
                    mapping.References(y => y.Currency).Not.LazyLoad();
                }).Not.LazyLoad();

            References(x => x.Traveller);

            HasMany(x => x.ActivityList)
                .Cascade.All();

            HasMany(x => x.CostList)
                .Cascade.All();

            HasMany(x => x.PreliminaryActivityList)
                .Cascade.All();

            HasMany(x => x.ItemList)
                .Cascade.All();
        }
    }
}
