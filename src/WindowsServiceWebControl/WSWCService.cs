using Microsoft.Owin.Hosting;
using NLog;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsServiceWebControl
{
    class WSWCService
    {
        private static Logger _log = LogManager.GetCurrentClassLogger();
        private IDisposable app;

        public void Start()
        {
            string port = ConfigurationManager.AppSettings["port"];
            app = WebApp.Start<Startup>(url: "http://+:" + port);
            _log.Info("WSWC Service has started");
        }

        public void Stop()
        {
            app.Dispose();
        }

    }
}
