using CST_323_CLC.Services;
using Microsoft.AspNetCore.Mvc;

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

         
    }
}
