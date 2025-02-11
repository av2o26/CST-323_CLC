using CST_323_CLC.Models;

namespace CST_323_CLC.Services.Business
{
    public interface IUserService
    {
        public UserModel AddUser(UserModel user);

        public bool VerifyInformation(string username, string password);
    }
}
