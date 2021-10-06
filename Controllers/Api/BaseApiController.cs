using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Controllers.Api
{
    // No longer used - shown for reference only if using full controllers instead of Endpoints for APIs
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]/[action]")]
    [ApiController]
    public class BaseApiController : ControllerBase
    { }
}
