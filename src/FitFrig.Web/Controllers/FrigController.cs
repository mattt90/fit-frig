using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FitFrig.Web.Controllers
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