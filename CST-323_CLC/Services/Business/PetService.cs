using CST_323_CLC.Models;
using CST_323_CLC.Services.Data_Access;

namespace CST_323_CLC.Services.Business
{
    public class PetService : IPetService
    {
        private readonly IPetDAO _petDao;

        public PetService(IPetDAO petDao)
        {
            _petDao = petDao;
        }

        /// <summary>
        /// Get all pets
        /// </summary>
        /// <returns>List of pets</returns>
        public List<PetModel> GetAll()
        {
            return _petDao.GetPets();
        }

        /// <summary>
        /// Get a specific pet
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Pet</returns>
        public PetModel GetById(string id)
        {
            return _petDao.GetPetById(id);
        }

        /// <summary>
        /// Create a pet
        /// </summary>
        /// <param name="pet"></param>
        /// <returns>Pet</returns>
        public PetModel Create(PetModel pet)
        {
            return _petDao.CreatePet(pet);
        }

        /// <summary>
        /// Update a pet
        /// </summary>
        /// <param name="id"></param>
        /// <param name="pet"></param>
        public void Update(string id, PetModel pet)
        {
            _petDao.UpdatePet(id, pet);
        }

        /// <summary>
        /// Delete a pet
        /// </summary>
        /// <param name="id"></param>
        public void Delete(string id)
        {
            _petDao.DeletePet(id);
        }
    }
}
