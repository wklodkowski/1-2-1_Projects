using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using WpfApp.DAL;

namespace WpfApp.Infrastructure.DI
{
    public class WpfAppDalModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<WpfAppContext>().AsSelf().InstancePerLifetimeScope();
        }
    }
}
