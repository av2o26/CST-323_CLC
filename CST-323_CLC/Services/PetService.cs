using CST_323_CLC.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace CST_323_CLC.Services
{
    public class PetService
    {
        private readonly IMongoCollection<PetModel> pets;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="petDbSettings"></param>
        public PetService(IOptions<PetDatabaseSettings> petDbSettings)
        {
            MongoClient mongoClient = new MongoClient(petDbSettings.Value.ConnectionString);
            IMongoDatabase mongoDatabase = mongoClient.GetDatabase(petDbSettings.Value.DatabaseName);
            pets = mongoDatabase.GetCollection<PetModel>(petDbSettings.Value.CollectionName);
        }

        /// <summary>
        /// Get the list of pets from the database
        /// </summary>
        /// <returns>List of pets</returns>
        public List<PetModel> GetPets()
        {
            return pets.Find(pet => true).ToList();
        }

        /// <summary>
        /// Get a specific pet with its id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>One pet</returns>
        public PetModel GetPetById(string id)
        {
            return pets.Find(pet => pet.Id == id).FirstOrDefault();
        }

        /// <summary>
        /// Add a pet to the database
        /// </summary>
        /// <param name="pet"></param>
        /// <returns></returns>
        public PetModel CreatePet(PetModel pet)
        {
            pets.InsertOne(pet);
            return pet;
        }

        /// <summary>
        /// Update a pet's information in the database
        /// </summary>
        /// <param name="id"></param>
        /// <param name="pet"></param>
        public void UpdatePet(string id, PetModel pet)
        {
            pets.ReplaceOne(pet => pet.Id == id, pet);
        }

        /// <summary>
        /// Remove a pet from the database
        /// </summary>
        /// <param name="id"></param>
        public void DeletePet(string id)
        {
            pets.DeleteOne(pet => pet.Id == id);
        }
    }
}
