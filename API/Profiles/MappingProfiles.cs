using Core.Entities;
using API.Dtos;
using AutoMapper;
namespace API.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile() {
        CreateMap<Place, PlacesDto>()
            .ForMember(dest => dest.Nombre,opt => opt.MapFrom(src => src.Name_Place))
            .ForMember(dest => dest.Id,opt => opt.MapFrom(src => src.Id_Place))
            .ReverseMap();


        CreateMap<Area, AreasDto>()
            .ForMember(dest => dest.Nombre,opt => opt.MapFrom(src => src.Name_Area))
            .ForMember(dest => dest.Id,opt => opt.MapFrom(src => src.Id_Area))
            .ReverseMap();

        CreateMap<Area, AreaDto>()
            .ForMember(dest => dest.Nombre,opt => opt.MapFrom(src => src.Name_Area))
            .ForMember(dest => dest.Id,opt => opt.MapFrom(src => src.Id_Area))
            .ForMember(dest => dest.Incidente,opt => opt.MapFrom(src => src.Description_Incidence))
            .ForMember(dest => dest.Descripcion,opt => opt.MapFrom(src => src.Description_Area))
            .ForMember(dest => dest.Lugares,opt => opt.MapFrom(src => src.Places))            
            .ReverseMap();

        
    }
} 