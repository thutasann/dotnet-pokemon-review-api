namespace dotnet_pokemon_review.Models
{
    public class Pokemon
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public required ICollection<Review> Reviews { get; set; }

        /// <summary>
        /// Many-Many with Owner
        /// </summary>
        public required ICollection<PokemonOwner> PokemonOwners { get; set; }

        /// <summary>
        /// Many-Many with Category
        /// </summary>
        public required ICollection<PokemonCategory> PokemonCategories { get; set; }
    }
}