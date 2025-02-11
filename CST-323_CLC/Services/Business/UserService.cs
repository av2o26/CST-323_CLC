using CST_323_CLC.Models;
using CST_323_CLC.Services.Data_Access;

namespace CST_323_CLC.Services.Business
{
    public class UserService : IUserService
    {
        private readonly IUserDAO userDao;

        public UserService(IUserDAO userDao)
        {
            this.userDao = userDao;
        }

        public UserModel GetByUsername(string username)
        {
            userDao.GetUserByUsername(username);
            return userDao.GetUserByUsername(username);
        }

        public UserModel AddUser(UserModel user)
        {
            return userDao.CreateUser(user);
        }

        /// <summary>
        /// Verify the password to a username
        /// </summary>
        /// <param name="user"></param>
        /// <param name="username"></param>
        /// <returns></returns>
        public bool VerifyInformation(UserModel user, string username)
        {
            if(user.Username != username)
                return false;

            return true;
        }
    }
}
