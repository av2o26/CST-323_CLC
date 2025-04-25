using CST_323_CLC.Models;
using CST_323_CLC.Services.Utilities;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Logging;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Drawing;

namespace CST_323_CLC.Services.Data_Access
{
    public class UserDAO : IUserDAO
    {
        // Services
        private readonly IMongoCollection<UserModel> users;
        private readonly ILogger<UserDAO> _logger;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="userDbSettings"></param>
        public UserDAO(IOptions<UserDatabaseSettings> userDbSettings, ILogger<UserDAO> logger)
        {
            _logger = logger;
            MongoClient mongoClient = new MongoClient(userDbSettings.Value.ConnectionString);
            IMongoDatabase mongoDatabase = mongoClient.GetDatabase(userDbSettings.Value.DatabaseName);
            users = mongoDatabase.GetCollection<UserModel>(userDbSettings.Value.CollectionName);

            _logger.LogInformation("UserDAO initialized with DB: {Database}, Collection: {Collection}",
                userDbSettings.Value.DatabaseName, userDbSettings.Value.CollectionName);
        }

        /// <summary>
        /// Add a user to the database
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public UserModel CreateUser(UserModel user)
        {
            _logger.LogInformation("Inserting new user: {Username}", user.Username);
            users.InsertOne(user);
            return user;
        }

        /// <summary>
        /// Match a username and password with one in the database
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool CheckUsernameAndPass(string username, string password)
        {
            _logger.LogInformation("Verifying login for username: {Username}", username);

            var result = users.Find(user => user.Username == username && user.Password == password).FirstOrDefault();

            bool success = result != null;

            if (success)
                _logger.LogInformation("User authenticated: {Username}", username);
            else
                _logger.LogWarning("Authentication failed for username: {Username}", username);

            return success;
        }
    }
}
