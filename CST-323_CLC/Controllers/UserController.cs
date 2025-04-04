using CST_323_CLC.Models;
using CST_323_CLC.Services.Business;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using System.Drawing;
using Microsoft.Extensions.Logging;

namespace CST_323_CLC.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IHttpContextAccessor _context;
        private readonly ILogger<UserController> _logger;

        public UserController(IUserService userService, IHttpContextAccessor context, ILogger<UserController> logger)
        {
            _userService = userService;
            _context = context;
            _logger = logger;
        }

        /// <summary>
        /// GET: Go to registration page
        /// </summary>
        /// <returns>Register View</returns>
        public ActionResult Register()
        {
            _logger.LogInformation("GET UserController.Register called");
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
            _logger.LogInformation("POST UserController.Register called");

            ModelState.Remove("Id");
            if (ModelState.IsValid)
            {
                _logger.LogInformation("Model is valid. Registering user: {Username}", user.Username);
                _userService.AddUser(user);
                _logger.LogInformation("User registered successfully");
                return RedirectToAction("Login");
            }
            else
            {
                _logger.LogWarning("Model state invalid. Returning to Register view.");
                return View(user);
            }
        }

        /// <summary>
        /// GET: Go to login page
        /// </summary>
        /// <returns>Login View</returns>
        public ActionResult Login()
        {
            _logger.LogInformation("GET UserController.Login called");
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
            _logger.LogInformation("POST UserController.Login called for username: {Username}", user.Username);

            if (_userService.VerifyInformation(user.Username, user.Password))
            {
                _logger.LogInformation("Login successful for user: {Username}", user.Username);
                _context.HttpContext.Session.SetString("user", user.Username);
                return RedirectToAction("Index", "Pet");
            }

            _logger.LogWarning("Login failed for user: {Username}", user.Username);
            return View();
        }
    }
}
