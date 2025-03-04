using CST_323_CLC.Models;

namespace CST_323_CLC.Services.Business
{
    public interface IPetService
    {
        public List<PetModel> GetAll();

        public PetModel GetById(string id);

        public PetModel Create(PetModel pet);

        public void Update(string id, PetModel pet);

        public void Delete(string id);
    }
}
