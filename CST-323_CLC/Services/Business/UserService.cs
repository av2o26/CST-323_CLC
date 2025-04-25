using CST_323_CLC.Models;
using CST_323_CLC.Services.Data_Access;
using Microsoft.Extensions.Logging;

namespace CST_323_CLC.Services.Business
{
    public class UserService : IUserService
    {
        // Services
        private readonly IUserDAO _userDao;
        private readonly ILogger<UserService> _logger;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="userDao"></param>
        /// <param name="logger"></param>
        public UserService(IUserDAO userDao, ILogger<UserService> logger)
        {
            _userDao = userDao;
            _logger = logger;
        }

        /// <summary>
        /// Create a user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public UserModel AddUser(UserModel user)
        {
            _logger.LogInformation("UserService.AddUser() called for username: {Username}", user.Username);
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
            _logger.LogInformation("UserService.VerifyInformation() called for username: {Username}", username);
            return _userDao.CheckUsernameAndPass(username, password);
        }
    }
}
