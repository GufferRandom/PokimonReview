using AutoMapper;
using PokimonReview.Dto;
using PokimonReview.Models;

namespace PokimonReview.helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles() { 
        CreateMap<Pokemon,PokemonDto>();
        CreateMap<Category,CategoryDto>();
            CreateMap<Country, CountryDto>();
            CreateMap<Owner, OwnerDto>();
        }
    }
}
