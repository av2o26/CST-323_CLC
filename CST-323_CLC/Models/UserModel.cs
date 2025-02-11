using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace CST_323_CLC.Models
{
    public class UserModel
    {
        // Properties
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("fName")]
        [DisplayName("First Name:")]
        [Required]
        public string? FirstName { get; set; }

        [BsonElement("lName")]
        [DisplayName("Last Name:")]
        [Required]
        public string? LastName { get; set; }

        [BsonElement("phone")]
        [DisplayName("Phone Number:")]
        [DataType(DataType.PhoneNumber)]
        [Required]
        public int Phone { get; set; }

        [BsonElement("email")]
        [DisplayName("Email Address:")]
        [DataType(DataType.EmailAddress)]
        [Required]
        public string? Email { get; set; }

        [BsonElement("username")]
        [DisplayName("Username:")]
        [Required]
        public string? Username { get; set; }

        [BsonElement("password")]
        [DisplayName("Password:")]
        [DataType(DataType.Password)]
        [Required]
        public string? Password { get; set; }
    }
}
