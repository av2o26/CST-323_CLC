using CST_323_CLC.Models;
using CST_323_CLC.Services;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;

namespace CST_323_CLC.Controllers
{
    public class PetController : Controller
    {
        private readonly PetService petService;

        public PetController(PetService petService)
        {
            this.petService = petService;
        }

        public IActionResult Index()
        {
            return View(petService.GetPets());
        }

        public IActionResult DeletePet(string id)
        {
            petService.DeletePet(id);
            return RedirectToAction("Index");
        }

        public IActionResult EditPet(string id)
        {
            return View(petService.FindPet(id));
        }

        public IActionResult UpdatePet(PetModel pet)
        {
            petService.UpdatePet(pet.Id, pet);

            return RedirectToAction("Index");
        }

        public IActionResult CreatePet()
        {
            return View(new PetModel());
        }

        public IActionResult AddPet(PetModel pet)
        {
            pet.Id = ObjectId.GenerateNewId().ToString();

            petService.CreatePet(pet);

            return RedirectToAction("Index");
        }

    }
}
