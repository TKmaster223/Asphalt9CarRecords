using Asphalt9CarRecords.Models; // Using the Models namespace
using Asphalt9CarRecords.Models.DTOs; // Using the DTOs namespace
using AutoMapper; // Using AutoMapper for object mapping

public class MappingProfile : Profile // Defining the mapping profile
{
    public MappingProfile()
    {
        CreateMap<Car, CarDto>() // Mapping Car to CarDto
            .ForMember(dest => dest.CarClassName, opt => opt.MapFrom(src => src.CarClass.Name)); // Mapping CarClass.Name to CarDto.CarClassName
        CreateMap<CarDto, Car>() // Mapping CarDto to Car
            .ForMember(dest => dest.CarClass, opt => opt.Ignore()); // Ignoring CarClass in Car mapping
    }
}
