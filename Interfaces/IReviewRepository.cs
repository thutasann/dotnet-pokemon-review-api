using dotnet_pokemon_review.Models;

namespace dotnet_pokemon_review.Interfaces
{
    public interface IReviewRepository
    {
        ICollection<Review> GetReviews();
        Review? GetReview(int reviewId);
        ICollection<Review> GetReviewsOfAPokemon(int pokeId);
        bool ReviewExists(int reviewId);
    }
}