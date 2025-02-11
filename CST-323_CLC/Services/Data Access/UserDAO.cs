using CST_323_CLC.Models;
using CST_323_CLC.Services.Utilities;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System.Drawing;

namespace CST_323_CLC.Services.Data_Access
{
    public class UserDAO : IUserDAO
    {
        private readonly IMongoCollection<UserModel> users;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="userDbSettings"></param>
        public UserDAO(IOptions<UserDatabaseSettings> userDbSettings)
        {
            MongoClient mongoClient = new MongoClient(userDbSettings.Value.ConnectionString);
            IMongoDatabase mongoDatabase = mongoClient.GetDatabase(userDbSettings.Value.DatabaseName);
            users = mongoDatabase.GetCollection<UserModel>(userDbSettings.Value.CollectionName);
        }

        /// <summary>
        /// Get a specific pet with its id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>One pet</returns>
        public UserModel GetUserByUsername(string username)
        {
            return users.Find(username).FirstOrDefault();
        }

        /// <summary>
        /// Add a user to the database
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public UserModel CreateUser(UserModel user)
        {
            users.InsertOne(user);
            return user;
        }
    }
}
