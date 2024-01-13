namespace dotnet_pokemon_review.Models
{
    public class Owner
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Gym { get; set; }
        public required Country Country { get; set; }

        /// <summary>
        /// Many-Many with Pokemon
        /// </summary>
        public required ICollection<PokemonOwner> PokemonOwners { get; set; }
    }
}