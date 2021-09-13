using Microsoft.AspNetCore.Mvc;

namespace CustomerViewerAPI.Controllers
{
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        public IActionResult Index()
        {
            /*return View();*/
        }
    }
}
