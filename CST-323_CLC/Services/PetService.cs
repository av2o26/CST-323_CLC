using CST_323_CLC.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System.Collections.Generic;

namespace CST_323_CLC.Services
{
    public class PetService
    {
        private readonly IMongoCollection<PetModel> pets;

        public PetService(IOptions<PetDatabaseSettings> petDbSettings)
        {
            MongoClient mongoClient = new MongoClient(petDbSettings.Value.ConnectionString);
            IMongoDatabase mongoDatabase = mongoClient.GetDatabase(petDbSettings.Value.DatabaseName);
            pets = mongoDatabase.GetCollection<PetModel>(petDbSettings.Value.CollectionName);
        }

        public List<PetModel> GetPets()
        {
            return pets.Find(pet => true).ToList();
        }

        public PetModel FindPet(string id)
        {
            PetModel foundPet = new PetModel();

            List<PetModel> pets = GetPets();

            foreach(PetModel pet in pets)
            {
                if(pet.Id == id)
                {
                    foundPet = pet;
                }
            }

            return foundPet;
        }

        public PetModel CreatePet(PetModel pet)
        {
            pets.InsertOneAsync(pet);
            return pet;
        }

        public void UpdatePet(string id, PetModel pet)
        {
            pets.ReplaceOneAsync(pet => pet.Id == id, pet);
        }

        public void DeletePet(string id)
        {
            pets.DeleteOneAsync(pet => pet.Id == id);
        }
    }
}
