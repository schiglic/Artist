using AutoMapper;
using Artist.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Artist
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // Маппінг між класами ArtistModel та ArtistDto
            CreateMap<ArtistModel, ArtistDto>();
            CreateMap<ArtistDto, ArtistModel>();
        }
    }
}
