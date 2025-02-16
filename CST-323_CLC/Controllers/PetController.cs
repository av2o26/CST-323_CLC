using CST_323_CLC.Models;
using CST_323_CLC.Services.Business;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CST_323_CLC.Controllers
{
    public class PetController : Controller
    {
        private readonly IPetService _petService;
        private readonly IHttpContextAccessor _context;

        public PetController(IPetService petService, IHttpContextAccessor context)
        {
            _petService = petService;
            _context = context;
        }

        /// <summary>
        /// GET: Display list of pets
        /// </summary>
        /// <returns>List View</returns>
        public ActionResult Index()
        {
            if (_context.HttpContext.Session.GetString("user") == null)
                return RedirectToAction("Login", "User");

            return View(_petService.GetAll());
        }

        /// <summary>
        /// GET: Let user create a pet
        /// </summary>
        /// <returns>Create View</returns>
        public ActionResult Create()
        {
            if (_context.HttpContext.Session.GetString("user") == null)
                return RedirectToAction("Login", "User");

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
            ModelState.Remove("Id");
            if (ModelState.IsValid)
            {
                _petService.Create(pet);
                return RedirectToAction(nameof(Index));
            }
            else
                return View(pet);
        }

        /// <summary>
        /// GET: Let user edit a pet's information
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Edit View</returns>
        public ActionResult Edit(string id)
        {
            if (_context.HttpContext.Session.GetString("user") == null)
                return RedirectToAction("Login", "User");

            PetModel pet = _petService.GetById(id);
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
            if (ModelState.IsValid)
            {
                _petService.Update(id, pet);
                return RedirectToAction(nameof(Index));
            }
            else
                return View(pet);
        }

        /// <summary>
        /// GET: Let user remove a pet
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Delete View</returns>
        public ActionResult Delete(string id)
        {
            if (_context.HttpContext.Session.GetString("user") == null)
                return RedirectToAction("Login", "User");

            PetModel pet = _petService.GetById(id);
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
            try
            {
                _petService.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

    }
}
