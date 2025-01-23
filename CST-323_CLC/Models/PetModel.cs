namespace CST_323_CLC.Models
{
    public class PetModel
    {
        // Properties
        public String Species { get; set; }
        public String Breed { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }
        public double Price { get; set; }
        public bool AdoptionStatus { get; set; }

        /// <summary>
        /// Default Constructor
        /// </summary>
        public PetModel() {}

        /// <summary>
        /// Parameterized Constructor
        /// </summary>
        /// <param name="species"></param>
        /// <param name="breed"></param>
        /// <param name="name"></param>
        /// <param name="description"></param>
        /// <param name="price"></param>
        /// <param name="adoptionStatus"></param>
        public PetModel(string species, string breed, string name, string description, double price, bool adoptionStatus)
        {
            Species = species;
            Breed = breed;
            Name = name;
            Description = description;
            Price = price;
            AdoptionStatus = adoptionStatus;
        }
    }
}
