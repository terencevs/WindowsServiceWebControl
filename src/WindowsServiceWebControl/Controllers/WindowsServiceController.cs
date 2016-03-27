using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.ServiceProcess;

namespace WindowsServiceWebControl.Controllers
{
    [RoutePrefix("service/{host}/{serviceName}")]
    public class WindowsServiceController : ApiController
    {
        private static Logger _log = LogManager.GetCurrentClassLogger();

        [Route("status")]
        [HttpGet]
        public IHttpActionResult Status(string host, string serviceName)
        {
            try
            {
                ServiceController sc = new ServiceController(serviceName, host);

                _log.Debug(String.Format("Getting status of service: {0} on host: {1}", serviceName, host));

                return Ok(String.Format("Service: {0} ({1}) state is: {2}", sc.DisplayName, sc.ServiceName, sc.Status.ToString()));
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [Route("start")]
        [HttpPost]
        public IHttpActionResult Start(string host, string serviceName)
        {
            try
            {
                ServiceController sc = new ServiceController(serviceName, host);

                _log.Debug(String.Format("Starting service: {0} on host: {1}", serviceName, host));

                sc.Start();

                sc.WaitForStatus(ServiceControllerStatus.Running, TimeSpan.FromMinutes(1));

                return Ok(String.Format("Service: {0} ({1}) state is: {2}", sc.DisplayName, sc.ServiceName, sc.Status.ToString()));
            }
            catch (System.ServiceProcess.TimeoutException)
            {
                _log.Error(String.Format("Timeout starting service: {0} on host: {1}", serviceName, host));
                return InternalServerError();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [Route("stop")]
        [HttpPost]
        public IHttpActionResult Stop(string host, string serviceName)
        {
            try
            {
                ServiceController sc = new ServiceController(serviceName, host);

                _log.Debug(String.Format("Stopping service: {0} on host: {1}", serviceName, host));

                sc.Stop();

                sc.WaitForStatus(ServiceControllerStatus.Stopped, TimeSpan.FromMinutes(1));

                return Ok(String.Format("Service: {0} ({1}) state is: {2}", sc.DisplayName, sc.ServiceName, sc.Status.ToString()));
            }
            catch (System.ServiceProcess.TimeoutException)
            {
                _log.Error(String.Format("Timeout stoping service: {0} on host: {1}", serviceName, host));
                return InternalServerError();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [Route("restart")]
        [HttpPost]
        public IHttpActionResult Restart(string host, string serviceName)
        {
            try
            {
                ServiceController sc = new ServiceController(serviceName, host);

                _log.Debug(String.Format("Restarting service: {0} on host: {1}", serviceName, host));
                sc.Stop();

                sc.WaitForStatus(ServiceControllerStatus.Stopped, TimeSpan.FromMinutes(1));
                _log.Debug(String.Format("Stopped service: {0} on host: {1}", serviceName, host));

                sc.Start();
                _log.Debug(String.Format("Starting service: {0} on host: {1}", serviceName, host));

                sc.WaitForStatus(ServiceControllerStatus.Running, TimeSpan.FromMinutes(1));

                _log.Debug(String.Format("Started service: {0} on host: {1}", serviceName, host));

                return Ok(String.Format("Service: {0} ({1}) state is: {2}", sc.DisplayName, sc.ServiceName, sc.Status.ToString()));
            }
            catch (System.ServiceProcess.TimeoutException)
            {
                _log.Error(String.Format("Timeout stoping service: {0} on host: {1}", serviceName, host));
                return InternalServerError();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}