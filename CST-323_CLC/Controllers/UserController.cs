using CST_323_CLC.Models;
using CST_323_CLC.Services.Business;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;

namespace CST_323_CLC.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        public IActionResult Register()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(UserModel user)
        {
            string username = userService.GetByUsername(user.Username).ToString();
            userService.VerifyInformation(user, username);

            return View();
        }
    }
}
