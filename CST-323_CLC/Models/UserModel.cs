using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.ComponentModel.DataAnnotations;

namespace CST_323_CLC.Models
{
    public class UserModel
    {

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("fName")]
        [Required]
        public string FirstName { get; set; }

        [BsonElement("lName")]
        [Required]
        public string LastName { get; set; }

        [BsonElement("phone")]
        [Required]
        public int Phone { get; set; }

        [BsonElement("email")]
        [Required]
        public string Email { get; set; }

        [BsonElement("username")]
        [Required]
        public string Username { get; set; }

        [BsonElement("password")]
        [Required]
        public string Password { get; set; }
    }
}
