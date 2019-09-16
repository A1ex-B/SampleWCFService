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
        private readonly string _repositoryType;
        private readonly string _pathToFake;

        public DBModule(string connectionString, string repositoryType, string pathToFake)
        {
            _connectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));
            _repositoryType = repositoryType ?? throw new ArgumentNullException(nameof(repositoryType));
            _pathToFake = pathToFake ?? throw new ArgumentNullException(nameof(pathToFake));
        }

        protected override void Load(ContainerBuilder builder)
        {
            switch (_repositoryType)
            {
                case "Real":
                    builder.RegisterType<ReceiptsRepository>().AsImplementedInterfaces().
                            WithParameter(new NamedParameter("connectionString", _connectionString));
                    break;
                case "Fake":
                    builder.RegisterType<FakeRepository>().WithParameter(new NamedParameter("pathToRepo", _pathToFake)).AsImplementedInterfaces();
                    Console.WriteLine("Attention! Registered fake repository!");
                    break;
                default:
                    throw new ArgumentException(
                        $"Bad repository type! Setup un App.config/AppSettings, key is \"RepositoryType\", " +
                        "value can be \"Real\" or \"Fake\"");
            }
        }
    }
}
