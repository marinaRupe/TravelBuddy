using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using NHibernate.Mapping;
using TravelBuddy.Models;

namespace TravelBuddy.DAL.Mappings
{
    public class TravelActivityMap : SubclassMap<TravelActivity>
    {
        public TravelActivityMap()
        {
            // DiscriminatorValue("TRAVEL_ACTIVITY");

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
        }
    }
}
