using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Fit.Frig.Web.Controllers
{
    [Authorize]
    public class FrigController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}