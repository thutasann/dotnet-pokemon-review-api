namespace dotnet_pokemon_review.Models
{
    public class Category
    {
        public int Id { get; set; }
        public required string Name { get; set; }

        /// <summary>
        /// Many-Many with Pokemon
        /// </summary>
        public required ICollection<PokemonCategory> PokemonCategories { get; set; }
    }
}