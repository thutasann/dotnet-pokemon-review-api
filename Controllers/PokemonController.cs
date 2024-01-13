using dotnet_pokemon_review.Data;
using dotnet_pokemon_review.Interfaces;
using dotnet_pokemon_review.Models;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_pokemon_review.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokemonController : ControllerBase
    {
        private readonly IPokemonRepository _pokemonRepository;
        private readonly DataContext _context;
        private readonly ILogger<PokemonController> _logger;


        public PokemonController(IPokemonRepository pokemonRepository, DataContext context, ILogger<PokemonController> logger)
        {
            _pokemonRepository = pokemonRepository;
            _context = context;
            _logger = logger;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Pokemon>))]
        public IActionResult GetPokemons()
        {
            var pokemons =  _pokemonRepository.GetPokemons();
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(pokemons);
        }
    }
}