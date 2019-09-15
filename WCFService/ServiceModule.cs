using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;

namespace WCFService
{
    public class ServiceModule: Module
    {
        public ServiceModule()
        {
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<Service>().As<IService>();//.InstancePerDependency();
        }
    }
}
