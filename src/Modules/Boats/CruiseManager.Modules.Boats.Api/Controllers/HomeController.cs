using Microsoft.AspNetCore.Mvc;

namespace CruiseManager.Modules.Boats.Api.Controllers
{
    [Route(BoatsModule.BasePath)]
    internal class HomeController : BaseController
    {
        [HttpGet]
        public ActionResult<string> Get() => "Boats API";
    }
}
