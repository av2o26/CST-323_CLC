using CST_323_CLC.Models;

namespace CST_323_CLC.Services.Data_Access
{
    public interface IPetDAO
    {
        public List<PetModel> GetPets();

        public PetModel GetPetById(string id);

        public PetModel CreatePet(PetModel pet);

        public void UpdatePet(string id, PetModel pet);

        public void DeletePet(string id);
    }
}
