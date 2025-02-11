using CST_323_CLC.Models;
using CST_323_CLC.Services;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;

namespace CST_323_CLC.Controllers
{
    public class UserController : Controller
    {
        private readonly UserService userService;

        public UserController(UserService userService)
        {
            this.userService = userService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        public IActionResult AddUser(UserModel user)
        {
            user.Id = ObjectId.GenerateNewId().ToString();

            userService.CreateUser(user);

            return RedirectToAction("Index", "Login");
        }

        public IActionResult CheckCredentials(string username, string password)
        {
            UserModel foundUser = userService.FindUser(username);

            if (foundUser.Password == password)
            {
                return RedirectToAction("Index", "Pet");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
    }
}
