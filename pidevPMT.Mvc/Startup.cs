﻿using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(pidevPMT.Mvc.Startup))]
namespace pidevPMT.Mvc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
