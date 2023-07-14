using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace net7_demo_api.Controllers.v1
{
    [ApiVersion("1.0")]
    [Route("api/[controller]")]
    public class UserController : BaseApiController
    {
        private readonly ILogger<UserController> _logger;

        public UserController(ILogger<UserController> logger)
        {
            _logger = logger;
        }

        
    }
}