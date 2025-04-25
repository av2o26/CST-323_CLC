using CST_323_CLC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CST_323_CLC.Controllers
{
    public class HomeController : Controller
    {
        // Service
        private readonly ILogger<HomeController> _logger;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="logger"></param>
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Display the home page
        /// </summary>
        /// <returns>Home View</returns>
        public IActionResult Index()
        {
            _logger.LogInformation("HomeController.Index() called");
            return View();
        }

        /// <summary>
        /// Display the error page
        /// </summary>
        /// <returns>Error View</returns>
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            _logger.LogError("HomeController.Error() called due to an unhandled error.");
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
