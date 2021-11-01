using System;
using System.Collections.Generic;
using System.Globalization;
using JOIEnergy.Domain;
using Microsoft.AspNetCore.Mvc;

namespace JOIEnergy.Controllers
{
    [Route("health-check")]
    public class HealthCheckController : Controller
    {
        private readonly List<HealthPing> _healthPings;

        public HealthCheckController(
            List<HealthPing> healthPings)
        {
            _healthPings = healthPings;
        }

        [HttpGet]
        public OkObjectResult OkHealth()
        {
            return new OkObjectResult(new
            {
                status = "all good",
                moment = DateTime.Now.ToString(CultureInfo.InvariantCulture)
            });
        }

        [HttpPost]
        [Route("ping")]
        public OkResult Ping([FromBody] HealthPing healthPing)
        {
            _healthPings.Add(healthPing);
            return new OkResult();
        }

        [HttpGet]
        [Route("ping")]
        public ObjectResult GetPings()
        {
            return new OkObjectResult(_healthPings);
        }
    }
}