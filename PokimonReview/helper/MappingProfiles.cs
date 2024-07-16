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
            CreateMap<CategoryDto,Category>();
            CreateMap<Country, CountryDto>();
            CreateMap<Owner, OwnerDto>();
            CreateMap<Review,ReviewDto>();
            CreateMap<Reviewer,ReviewerDto>();
        }
    }
}
