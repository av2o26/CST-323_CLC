using CST_323_CLC.Models;
using CST_323_CLC.Services.Data_Access;

namespace CST_323_CLC.Services.Business
{
    public class PetService : IPetService
    {
        private readonly IPetDAO petDao;

        public PetService(IPetDAO petDao)
        {
            this.petDao = petDao;
        }

        public List<PetModel> GetAll()
        {
            return petDao.GetPets();
        }

        public PetModel GetById(string id)
        {
            return petDao.GetPetById(id);
        }

        public PetModel Create(PetModel pet)
        {
            return petDao.CreatePet(pet);
        }

        public void Update(string id, PetModel pet)
        {
            petDao.UpdatePet(id, pet);
        }

        public void Delete(string id)
        {
            petDao.DeletePet(id);
        }
    }
}
