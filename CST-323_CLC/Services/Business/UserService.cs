using CST_323_CLC.Models;
using CST_323_CLC.Services.Data_Access;

namespace CST_323_CLC.Services.Business
{
    public class UserService : IUserService
    {
        private readonly IUserDAO _userDao;

        public UserService(IUserDAO userDao)
        {
            _userDao = userDao;
        }

        /// <summary>
        /// Create a user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public UserModel AddUser(UserModel user)
        {
            return _userDao.CreateUser(user);
        }

        /// <summary>
        /// Verify a user's credentials
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool VerifyInformation(string username, string password)
        {
            return _userDao.CheckUsernameAndPass(username, password);
        }
    }
}
