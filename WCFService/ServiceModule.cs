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
        private readonly string _testField;

        public ServiceModule(string testField)
        {
            _testField = testField ?? throw new ArgumentNullException(nameof(testField));
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<Service>().As<IService>().WithParameter(new NamedParameter("testField", _testField));//.InstancePerDependency();
        }
    }
}
