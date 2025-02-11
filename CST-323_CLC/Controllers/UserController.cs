using Microsoft.AspNetCore.Mvc;

namespace CST_323_CLC.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }
    }
}
