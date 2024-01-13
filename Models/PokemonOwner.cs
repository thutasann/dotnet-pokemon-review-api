namespace dotnet_pokemon_review.Models
{
    /// <summary>
    /// Many-Many Between Pokemon and Owner
    /// </summary>
    public class PokemonOwner
    {
        public int PokemonId { get; set; }
        public int OwnerId { get; set; }
        public required Pokemon Pokemon { get; set; }
        public required Owner Owner { get; set; }
    }
}