using Microsoft.AspNetCore.Mvc;

namespace CruiseManager.Modules.Boats.Api.Controllers
{
    [Route("boats-module")]
    internal class HomeController : ControllerBase
    {
        [HttpGet]
        public ActionResult<string> Get() => "Boats API";
    }
}
