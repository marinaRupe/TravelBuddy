using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using TravelBuddy.Models;

namespace TravelBuddy.DAL.Mappings
{
    public class TravelItemMap : ClassMap<TravelItem>
    {
        public TravelItemMap()
        {
            Id(x => x.Id).GeneratedBy.Guid();
            Map(x => x.Name);
            Map(x => x.Description);
            Map(x => x.IsTaken);
            Map(x => x.Label);
        }
    }
}
