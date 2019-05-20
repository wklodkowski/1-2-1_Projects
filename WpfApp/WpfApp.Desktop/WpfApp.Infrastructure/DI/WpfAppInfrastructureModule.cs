﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;

namespace WpfApp.Infrastructure.DI
{
    public class WpfAppInfrastructureModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule(new WpfAppDalModule());
            builder.RegisterModule(new WpfAppBllModule());
        }
    }
}
