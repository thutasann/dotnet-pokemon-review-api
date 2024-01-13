namespace dotnet_pokemon_review.Models
{
    public class Country
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required ICollection<Owner> Owners { get; set; }
    }
}