using dotnet_pokemon_review.Models;

namespace dotnet_pokemon_review.Dto
{
    public class OwnerDto
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Gym { get; set; }
    }
}