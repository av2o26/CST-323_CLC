using Microsoft.AspNetCore.Mvc;

namespace CST_323_CLC.Controllers
{
    public class DogsController : Controller
    {
        public IActionResult DogList()
        {
            return View();
        }
    }
}
