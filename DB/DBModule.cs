using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;

namespace DB
{
    public class DBModule : Module
    {
        private readonly string _connectionString;

        public DBModule(string connectionString)
        {
            _connectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ReceiptsRepository>().AsImplementedInterfaces().
                WithParameter(new NamedParameter("connectionString", _connectionString));

        }
    }
}
