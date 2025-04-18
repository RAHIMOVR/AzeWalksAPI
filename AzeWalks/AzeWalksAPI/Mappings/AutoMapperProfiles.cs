using AutoMapper;
using AzeWalksAPI.Models.Domain;
using AzeWalksAPI.Models.DTO;

namespace AzeWalksAPI.Mappings
{
    public class AutoMapperProfiles: Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Region, RegionDto>().ReverseMap();
            CreateMap<AddRegionDto, Region>().ReverseMap();
            CreateMap<UpdateRegionDto, Region>().ReverseMap();        
        }
    }
}
