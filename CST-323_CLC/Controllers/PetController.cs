using CST_323_CLC.Models;
using CST_323_CLC.Services.Business;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;


namespace CST_323_CLC.Controllers
{
    public class PetController : Controller
    {
        private readonly IPetService _petService;
        private readonly IHttpContextAccessor _context;
        private readonly ILogger<PetController> _logger;

        public PetController(IPetService petService, IHttpContextAccessor context, ILogger<PetController> logger)
        {
            _petService = petService;
            _context = context;
            _logger = logger;
        }

        /// <summary>
        /// GET: Display list of pets
        /// </summary>
        /// <returns>List View</returns>
        public ActionResult Index()
        {
            _logger.LogInformation("Entering PetController.Index()");
            _logger.LogInformation("Hello from PetController.Index()");
            if (_context.HttpContext.Session.GetString("user") == null)
            {
                _logger.LogWarning("Exiting PetController.Index()");
                return RedirectToAction("Login", "User");
            }

            _logger.LogInformation("Exiting PetController.Index()");
            return View(_petService.GetAll());
        }

        /// <summary>
        /// GET: Let user create a pet
        /// </summary>
        /// <returns>Create View</returns>
        public ActionResult Create()
        {
            _logger.LogInformation("Entering PetController.Create()");
            _logger.LogInformation("Hello from PetController.Create()");
            if (_context.HttpContext.Session.GetString("user") == null)
            {
                _logger.LogWarning("Redirecting from PetController.Create() to UserController.Login()");
                return RedirectToAction("Login", "User");
            }

            _logger.LogInformation("Exiting PetController.Create()");
            return View();
        }

        /// <summary>
        /// POST: Insert pet into database
        /// </summary>
        /// <param name="pet"></param>
        /// <returns>List View</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PetModel pet)
        {
            _logger.LogInformation("Entering PetController.Create(PetModel)");
            _logger.LogInformation("Hello from PetController.Create(PetModel)");
            ModelState.Remove("Id");
            if (ModelState.IsValid)
            {
                _logger.LogInformation("Exiting PetController.Create(PetModel)");
                _petService.Create(pet);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                _logger.LogWarning("Redirecting to PetController.Create(PetModel) view");
                return View(pet);
            }
        }

        /// <summary>
        /// GET: Let user edit a pet's information
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Edit View</returns>
        public ActionResult Edit(string id)
        {
            _logger.LogInformation("Entering PetController.Edit()");
            if (_context.HttpContext.Session.GetString("user") == null)
            {
                _logger.LogWarning("Redirecting to UserController.Login() from PetController.Edit()");
                return RedirectToAction("Login", "User");
            }

            PetModel pet = _petService.GetById(id);
            _logger.LogInformation("Redirecting to PetController.Edit View");
            return View(pet);
        }

        /// <summary>
        /// POST: Change a pet's information in the database
        /// </summary>
        /// <param name="id"></param>
        /// <param name="pet"></param>
        /// <returns>List View</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string id, PetModel pet)
        {
            _logger.LogInformation("Edit POST called for Pet ID: {PetId}", id);
        
            if (ModelState.IsValid)
            {
                _logger.LogInformation("Model state is valid. Updating pet.");
                _petService.Update(id, pet);
                _logger.LogInformation("Pet updated successfully.");
                return RedirectToAction(nameof(Index));
            }
            else
            {
                _logger.LogWarning("Model state is invalid. Returning view with validation errors.");
                return View(pet);
            }
        }
        
        /// <summary>
        /// GET: Let user remove a pet
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Delete View</returns>
        public ActionResult Delete(string id)
        {
            _logger.LogInformation("Delete GET called for Pet ID: {PetId}", id);
        
            if (_context.HttpContext.Session.GetString("user") == null)
            {
                _logger.LogWarning("User not logged in. Redirecting to Login.");
                return RedirectToAction("Login", "User");
            }
        
            PetModel pet = _petService.GetById(id);
            _logger.LogInformation("Pet retrieved for deletion.");
            return View(pet);
        }
        
        /// <summary>
        /// POST: Remove a pet from the database
        /// </summary>
        /// <param name="id"></param>
        /// <returns>List View</returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult ConfirmDelete(string id)
        {
            _logger.LogInformation("ConfirmDelete POST called for Pet ID: {PetId}", id);
        
            try
            {
                _petService.Delete(id);
                _logger.LogInformation("Pet deleted successfully.");
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting pet with ID: {PetId}", id);
                return View();
            }
        }
    }
}
