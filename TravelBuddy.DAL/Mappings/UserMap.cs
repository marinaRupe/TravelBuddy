using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using TravelBuddy.Models;

namespace TravelBuddy.DAL.Mappings
{
    public class UserMap : ClassMap<User>
    {
        public UserMap()
        {
            Id(x => x.Id).GeneratedBy.Native();
            Map(x => x.Username);
            Map(x => x.Email);
            Map(x => x.Password);
            HasMany(x => x.Travels);
        }
    }
}
