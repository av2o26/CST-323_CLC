using CST_323_CLC.Models;
using CST_323_CLC.Services.Business;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using System.Drawing;

namespace CST_323_CLC.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IHttpContextAccessor _context;

        public UserController(IUserService userService, IHttpContextAccessor context)
        {
            _userService = userService;
            _context = context;
        }

        /// <summary>
        /// GET: Go to registration page
        /// </summary>
        /// <returns>Register View</returns>
        public ActionResult Register()
        {
            return View();
        }

        /// <summary>
        /// POST: Register a user
        /// </summary>
        /// <param name="user"></param>
        /// <returns>Login View</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(UserModel user)
        {
            ModelState.Remove("Id");
            if (ModelState.IsValid)
            {
                _userService.AddUser(user);
                return RedirectToAction("Login");
            }
            else
                return View(user);
        }

        /// <summary>
        /// GET: Go to login page
        /// </summary>
        /// <returns>Login View</returns>
        public ActionResult Login()
        {
            return View();
        }

        /// <summary>
        /// POST: Log into an account
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(UserModel user)
        {
            if (_userService.VerifyInformation(user.Username, user.Password))
            {
                _context.HttpContext.Session.SetString("user", user.Username);
                return RedirectToAction("Index", "Pet");
            }

            return View();
        }
    }
}
