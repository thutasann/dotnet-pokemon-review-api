namespace dotnet_pokemon_review.Models
{
    public class Review
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public required string Text { get; set; }
        public required Reviewer Reviewer { get; set; }
        public required Pokemon Pokemon { get; set; }
    }
}