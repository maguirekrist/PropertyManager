using AutoMapper;

namespace PropertyManager.Models.AutoMapper;

public class PropertyProfile : Profile
{
    public PropertyProfile()
    {
        CreateMap<Property, PropertyViewModel>();
    }
}