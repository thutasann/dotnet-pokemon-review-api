using dotnet_pokemon_review.Models;

namespace dotnet_pokemon_review.Interfaces
{
    public interface ICategoryRepository
    {
        ICollection<Category> GetCategories();

        /// <summary>
        /// Get Single Category using `Redis`
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Category?> GetCategory(int id);
        ICollection<Pokemon> GetPokemonByCategory(int categoryId);
        bool CategoryExists(int categoryId);
        bool CreateCategory(Category category);
        bool Save();
    }
}