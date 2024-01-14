using dotnet_pokemon_review.Models;

namespace dotnet_pokemon_review.Dto
{
    public class PokemonDto
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public DateTime BirthDate { get; set; }
    }
}