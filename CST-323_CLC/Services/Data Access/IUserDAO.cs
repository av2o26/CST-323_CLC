using CST_323_CLC.Models;

namespace CST_323_CLC.Services.Data_Access
{
    public interface IUserDAO
    {
        public UserModel CreateUser(UserModel user);

        public bool CheckUsernameAndPass(string username, string password);
    }
}
