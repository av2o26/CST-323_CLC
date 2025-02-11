using CST_323_CLC.Models;
using CST_323_CLC.Services.Business;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CST_323_CLC.Controllers
{
    public class PetController : Controller
    {
        private readonly IPetService petService;

        public PetController(IPetService petService)
        {
            this.petService = petService;
        }

        /// <summary>
        /// GET: Display list of pets
        /// </summary>
        /// <returns>List View</returns>
        public ActionResult Index()
        {
            return View(petService.GetAll());
        }

        /// <summary>
        /// GET: Display details of a specific pet
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Detail View</returns>
        public ActionResult Details(string id)
        {
            PetModel pet = petService.GetById(id);
            return View(pet);
        }

        /// <summary>
        /// GET: Let user create a pet
        /// </summary>
        /// <returns>Create View</returns>
        public ActionResult Create()
        {
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
                petService.Create(pet);
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
            PetModel pet = petService.GetById(id);
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
                petService.Update(id, pet);
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
            PetModel pet = petService.GetById(id);
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
                petService.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

    }
}
