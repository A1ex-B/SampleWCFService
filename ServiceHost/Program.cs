using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Description;
using Autofac;
using WCFService;
using Autofac.Integration.Wcf;

namespace WCFServiceHost
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create a URI to serve as the base address
            var builder = new ContainerBuilder();
            builder.RegisterModule(new ServiceModule("TEST"));
            using (var container = builder.Build())
            {
                //AutofacHostFactory.Container = container;
                Uri httpUrl = new Uri("http://localhost:8090/ReceiptService/Service");
                //Create ServiceHost
                using (var host = new ServiceHost(typeof(Service), httpUrl))
                {
                    //Add a service endpoint
                    host.AddServiceEndpoint(typeof(IService)
                    , new WSHttpBinding(), "");

                    host.AddDependencyInjectionBehavior<IService>(container); // Зависимости

                    //Enable metadata exchange
                    host.Description.Behaviors.Add(new ServiceMetadataBehavior
                    {
                        HttpGetEnabled = true,
                        HttpGetUrl = httpUrl // не было
                    });
                    //Start the Service
                    ;
                    host.Open();

                    Console.WriteLine("Service is host at " + DateTime.Now.ToString());
                    Console.WriteLine("Host is running... Press <Enter> key to stop");
                    Console.ReadLine();
                    host.Close();
                    Environment.Exit(0);
                }
            }
        }
    }
}