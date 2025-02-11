using CST_323_CLC.Models;

namespace CST_323_CLC.Services.Business
{
    public interface IUserService
    {
        public UserModel GetByUsername(string username);

        public UserModel AddUser(UserModel user);

        public bool VerifyInformation(UserModel user, string username);
    }
}
