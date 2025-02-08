using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.ComponentModel.DataAnnotations;

namespace CST_323_CLC.Models
{
    public class PetModel
    {
        // Properties
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("name")]
        [Required]
        public string Name { get; set; }

        [BsonElement("species")]
        [Required]
        public string Species { get; set; }

        [BsonElement("breed")]
        [Required]
        public string Breed { get; set; }

        [BsonElement("description")]
        [Required]
        public string Description { get; set; }

        [BsonElement("price")]
        [DataType(DataType.Currency)]
        [Required]
        public decimal Price { get; set; }

        [BsonElement("isAdopted")]
        [Display(Name = "Available?")]
        [Required]
        public bool AdoptionStatus { get; set; }
    }
}
