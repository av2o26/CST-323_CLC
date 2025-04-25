using CST_323_CLC.Models;
using CST_323_CLC.Services.Data_Access;
using Microsoft.Extensions.Logging;

namespace CST_323_CLC.Services.Business
{
    public class PetService : IPetService
    {
        // Services
        private readonly IPetDAO _petDao;
        private readonly ILogger<PetService> _logger;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="petDao"></param>
        /// <param name="logger"></param>
        public PetService(IPetDAO petDao, ILogger<PetService> logger)
        {
            _petDao = petDao;
            _logger = logger;
        }

        /// <summary>
        /// Get all pets
        /// </summary>
        /// <returns>List of pets</returns>
        public List<PetModel> GetAll()
        {
            _logger.LogInformation("PetService.GetAll() called");
            return _petDao.GetPets();
        }

        /// <summary>
        /// Get a specific pet
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Pet</returns>
        public PetModel GetById(string id)
        {
            _logger.LogInformation("PetService.GetById() called with ID: {PetId}", id);
            return _petDao.GetPetById(id);
        }

        /// <summary>
        /// Create a pet
        /// </summary>
        /// <param name="pet"></param>
        /// <returns>Pet</returns>
        public PetModel Create(PetModel pet)
        {
            _logger.LogInformation("PetService.Create() called for pet: {PetName}", pet.Name);
            return _petDao.CreatePet(pet);
        }

        /// <summary>
        /// Update a pet
        /// </summary>
        /// <param name="id"></param>
        /// <param name="pet"></param>
        public void Update(string id, PetModel pet)
        {
            _logger.LogInformation("PetService.Update() called for Pet ID: {PetId}", id);
            _petDao.UpdatePet(id, pet);
        }

        /// <summary>
        /// Delete a pet
        /// </summary>
        /// <param name="id"></param>
        public void Delete(string id)
        {
            _logger.LogInformation("PetService.Delete() called for Pet ID: {PetId}", id);
            _petDao.DeletePet(id);
        }
    }
}
