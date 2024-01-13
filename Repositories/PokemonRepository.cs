using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_pokemon_review.Data;
using dotnet_pokemon_review.Interfaces;
using dotnet_pokemon_review.Models;

namespace dotnet_pokemon_review.Repositories
{
    public class PokemonRepository : IPokemonRepository
    {
        private readonly DataContext _context;
        private readonly ILogger<PokemonRepository> _logger;

        public PokemonRepository(DataContext context, ILogger<PokemonRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public ICollection<Pokemon> GetPokemons()
        {
            return _context.Pokemons.OrderBy(p => p.Id).ToList();
        }
    }
}