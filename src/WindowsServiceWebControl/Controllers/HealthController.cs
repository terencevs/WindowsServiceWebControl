using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace WindowsServiceWebControl.Controllers
{
    [RoutePrefix("health")]
    public class HealthController : ApiController
    {
        private static Logger _log = LogManager.GetCurrentClassLogger();

        [Route("ping")]
        public IHttpActionResult GetPing()
        {
            _log.Debug("Recieved Ping Request");
            return Ok("PONG");
        }
    }
}
