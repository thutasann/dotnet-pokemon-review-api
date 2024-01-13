namespace dotnet_pokemon_review.Models
{
    public class Reviewer
    {
        public int Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required ICollection<Review> Reviews { get; set; }
    }
}