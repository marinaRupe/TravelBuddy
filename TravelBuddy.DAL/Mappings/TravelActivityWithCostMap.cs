using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using TravelBuddy.Models;

namespace TravelBuddy.DAL.Mappings
{
    public class TravelActivityWithCostMap : SubclassMap<TravelActivityWithCost>
    {
        public TravelActivityWithCostMap()
        {
            // DiscriminatorValue("TRAVEL_ACTIVITY_WITH_COST");

            Component(x => x.Location,
                mapping =>
                {
                    mapping.Map(y => y.Country);
                    mapping.Map(y => y.Town);
                    mapping.Map(y => y.Street);
                    mapping.Map(y => y.FullName);
                    mapping.Map(y => y.Latitude);
                    mapping.Map(y => y.Longitude);
                });

            Component(x => x.Cost,
                mapping =>
                {
                    mapping.Map(y => y.Value);
                    mapping.References(y => y.Currency).Not.LazyLoad();
                }).Not.LazyLoad();
        }
    }
}
