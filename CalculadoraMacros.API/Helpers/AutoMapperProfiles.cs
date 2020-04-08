
using System.Linq;
using AutoMapper;
using CalculadoraMacros.API.Dtos;
using CalculadoraMacros.API.Models;

namespace CalculadoraMacros.API.Helpers
{
    public class AutoMapperProfiles:Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<UserForDisplayDto, User>();
            CreateMap<UserForRegisterDto, User>();
            CreateMap<UserForDisplayDto, User>();
            CreateMap<UserForLoginDto, User>();
            CreateMap<MeasurementDto, Measurement>();
        }
    }
}