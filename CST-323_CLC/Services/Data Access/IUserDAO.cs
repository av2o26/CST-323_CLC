using CST_323_CLC.Models;

namespace CST_323_CLC.Services.Data_Access
{
    public interface IUserDAO
    {
        public UserModel GetUserByUsername(string username);

        public UserModel CreateUser(UserModel user);
    }
}
