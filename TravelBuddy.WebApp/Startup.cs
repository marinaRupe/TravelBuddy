﻿using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TravelBuddy.WebApp.Startup))]
namespace TravelBuddy.WebApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
