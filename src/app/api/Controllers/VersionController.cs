using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace api.Controllers
{
    [Route("api/[controller]")]
    public class VersionController : Controller
    {
        private const string VersionIdentifier = "Version";
        private const string LastRevisionIdentifier = "LastRevision";

        private ILogger _logger;
        private IHostingEnvironment _hostEnv;
        private IConfiguration _config;

        public VersionController(ILogger<VersionController> logger, IHostingEnvironment env, IConfiguration config)
        {
            _logger = logger;
            _hostEnv = env;
            _config = config;
        }

        [HttpGet]
        public Dictionary<string, string> Get()
        {
            var version = _config[VersionIdentifier];
            var lastCommit = _config[LastRevisionIdentifier];

            if ((version == null || lastCommit == null) && !_hostEnv.IsDevelopment())
            {
                _logger.LogWarning("If not in Dev mode, check version file.");
            }

            return new Dictionary<string, string>{
                {"Version", version},
                {"LastRevision:", lastCommit}
            };
        }
    }
}