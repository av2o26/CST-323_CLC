using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace CST_323_CLC.Models
{
    public class PetModel
    {
        // Propeties
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
        [Required]
        public double Price { get; set; }

        [BsonElement("isAdopted")]
        [Required]
        public bool AdoptionStatus { get; set; }
    }
}
