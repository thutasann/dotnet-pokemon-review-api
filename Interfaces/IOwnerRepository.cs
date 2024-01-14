using dotnet_pokemon_review.Models;
namespace dotnet_pokemon_review.Interfaces
{
    public interface IOwnerRepository
    {
        ICollection<Owner> GetOwners();
        Owner? GetOwner(int ownerId);
        ICollection<Owner> GetOwnerOfAPokeMon(int pokeId);
        ICollection<Pokemon> GetPokemonByOwner(int ownerId);
        bool OwnerExists(int ownerId);
    }
}