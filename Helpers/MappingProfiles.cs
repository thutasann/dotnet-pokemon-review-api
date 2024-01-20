using AutoMapper;
using dotnet_pokemon_review.Dto;
using dotnet_pokemon_review.Models;

namespace PokemonReviewApp.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Pokemon, PokemonDto>();
            CreateMap<PokemonDto, Pokemon>(); // PokemonDto -> Pokemon

            CreateMap<Category, CategoryDto>();
            CreateMap<CategoryDto, Category>(); // CategoryDto -> Category

            CreateMap<Country, CountryDto>();
            CreateMap<CountryDto, Country>(); // CountryDto -> Country

            CreateMap<Owner, OwnerDto>();
            CreateMap<OwnerDto, Owner>(); // OwnerDto -> Owner

            CreateMap<Review, ReviewDto>();
            CreateMap<Reviewer, ReviewerDto>();
        }
    }
}