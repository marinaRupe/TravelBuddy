﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using TravelBuddy.Models;

namespace TravelBuddy.DAL.Mappings
{
    public class ActivityMap : ClassMap<Activity>
    {
        public ActivityMap()
        {
            DiscriminateSubClassesOnColumn("type");
        }
    }
}