using CST_323_CLC.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace CST_323_CLC.Services
{
    public class UserService
    {
        private readonly IMongoCollection<UserModel> users;

        public UserService(IOptions<UserDatabaseSettings> userDbSettings)
        {
            MongoClient mongoClient = new MongoClient(userDbSettings.Value.ConnectionString);
            IMongoDatabase mongoDatabase = mongoClient.GetDatabase(userDbSettings.Value.DatabaseName);
            users = mongoDatabase.GetCollection<UserModel>(userDbSettings.Value.CollectionName);
        }

        public List<UserModel> GetUsers()
        {
            return users.Find(user => true).ToList();
        }

        public UserModel FindUser(string id)
        {
            UserModel foundUser = new UserModel();

            List<UserModel> users = GetUsers();

            foreach (UserModel user in users)
            {
                if (user.Id == id)
                {
                    foundUser = user;
                }
            }

            return foundUser;
        }

        public UserModel CreateUser(UserModel user)
        {
            users.InsertOneAsync(user);
            return user;
        }

        public void UpdateUser(string id, UserModel user)
        {
            users.ReplaceOneAsync(user => user.Id == id, user);
        }

        public void DeleteUser(string id)
        {
            users.DeleteOneAsync(user => user.Id == id);
        }
    }
}
