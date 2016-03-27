using Microsoft.Owin.Hosting;
using NLog;
using System;
using System.Collections.Generic;
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
            app = WebApp.Start<Startup>(url: "http://+:8081");
            _log.Info("WSWC Service has started");
        }

        public void Stop()
        {
            app.Dispose();
        }

    }
}
