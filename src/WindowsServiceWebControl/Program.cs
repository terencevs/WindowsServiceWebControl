using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;

namespace WindowsServiceWebControl
{
    class Program
    {
        static void Main(string[] args)
        {
            HostFactory.Run(serviceConfig =>
            {
                serviceConfig.UseNLog();

                serviceConfig.Service<WSWCService>(serviceInstance =>
                {
                    serviceInstance.ConstructUsing(() => new WSWCService());

                    serviceInstance.WhenStarted(execute => execute.Start());

                    serviceInstance.WhenStopped(execute => execute.Stop());
                });

                serviceConfig.SetServiceName("WSWCService");
                serviceConfig.SetDisplayName("Windows Sevice Web Control");
                serviceConfig.SetDescription("Control Windows services on any host that the user running the service has access to.");

                serviceConfig.StartAutomatically();
            });
        }
    }
}
