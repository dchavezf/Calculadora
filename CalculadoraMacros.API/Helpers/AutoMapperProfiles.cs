
using System.Linq;
using AutoMapper;
using CalculadoraMacros.API.Dtos;
using CalculadoraMacros.API.Models;

namespace CalculadoraMacros.API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<UserForDisplayDto, User>();
            CreateMap<UserForRegisterDto, User>();
            CreateMap<UserForDisplayDto, User>();
            CreateMap<UserForLoginDto, User>();

            CreateMap<FunnelNormalDto, FunnelMasterDto>();
            CreateMap<FunnelNormalPlusBodyDto, FunnelMasterDto>();

            //CreateMap<FunnelMasterDto, Measurement>();
            CreateMap<Measurement, MeasurementDto>();
            CreateMap<MeasurementKpiresult, MeasurementKPIDto>()
                .ForMember(dest => dest.MetricName, opt => opt.MapFrom(src => src.Metric.Name))
                .ForMember(dest => dest.UofM, opt => opt.MapFrom(src => src.Metric.UnitOfMeasure.MetricUmcode))
                .ForMember(dest => dest.MetricClassificationName,
                    opt => opt.MapFrom(src => src.MetricClassification.Name))
                .ForMember(dest => dest.KPIColor,
                    opt => opt.MapFrom(src => src.MetricClassification.KpiColor.Code))
            ;
        }
    }
}