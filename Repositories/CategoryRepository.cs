using dotnet_pokemon_review.Data;
using dotnet_pokemon_review.Interfaces;
using dotnet_pokemon_review.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace dotnet_pokemon_review.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DataContext _context;
        private readonly IDistributedCache _distributedCache;

        public CategoryRepository(DataContext context, IDistributedCache distributedCache)
        {
            _context = context;
            _distributedCache = distributedCache;
        }

        public bool CategoryExists(int categoryId)
        {
            return _context.Categories.Any(c => c.Id == categoryId);
        }

        public ICollection<Category> GetCategories()
        {
            return _context.Categories.ToList();
        }

        public async Task<Category?> GetCategory(int id)
        {
            string key = $"category-{id}";
            string? cachedCategory = await _distributedCache.GetStringAsync(
                key
            );

            Console.WriteLine(string.IsNullOrEmpty(cachedCategory));

            Category? category;
            if (string.IsNullOrEmpty(cachedCategory))
            {
                category = await _context.Categories.Where(e => e.Id == id).FirstOrDefaultAsync();

                if (category is null)
                {
                    return category;
                }
                await _distributedCache.SetStringAsync(
                    key,
                    JsonConvert.SerializeObject(category)
                );

                return category;
            }

            category = JsonConvert.DeserializeObject<Category>(
                cachedCategory,
                new JsonSerializerSettings
                {
                    ConstructorHandling = ConstructorHandling.AllowNonPublicDefaultConstructor
                }
            );

            return category;

        }

        public ICollection<Pokemon> GetPokemonByCategory(int categoryId)
        {
            return _context.PokemonCategories.Where(pc => pc.CategoryId == categoryId).Select(c => c.Pokemon).ToList();
        }

        public bool CreateCategory(Category category)
        {
            _context.Add(category);
            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0;
        }

        public bool UpdateCategory(Category category)
        {
            _context.Update(category);
            return Save();
        }
    }
}