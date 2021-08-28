using AutoMapper;
using MatchAPP.Domain.ApiModels;
using MatchAPP.Domain.Entities;

namespace MatchAPP.Domain.Mapper
{
    public class MatchOddMapper
    {
        public static void Set(IMapperConfigurationExpression cfg)
        {
            // Mapping from Entity to Api model
            cfg.CreateMap<MatchOdd, MatchOddApiModel>()
               .ForMember(dest => dest.Match, src => src.MapFrom(s => $"{s.Match.TeamA}-{s.Match.TeamB}"));

            // Mapping from Api model to Entity 
            cfg.CreateMap<MatchOddApiModel, MatchOdd>();
            cfg.CreateMap<MatchOddAddApiModel, MatchOdd>();
        }
    }
}
