using AutoMapper;
using MatchAPP.Domain.ApiModels;
using MatchAPP.Domain.Entities;

namespace MatchAPP.Domain.Mapper
{
    public static class MatchMapper
    {
        public static void Set(IMapperConfigurationExpression cfg)
        {
            // Mapping from Entity to Api model
            cfg.CreateMap<Match, MatchApiModel>()
               .ForMember(dest => dest.Odds, src => src.MapFrom(s => s.MatchOdds)); ;

            // Mapping from Api model to Entity 
            cfg.CreateMap<MatchApiModel, Match>();
            cfg.CreateMap<MatchAddApiModel, Match>();
            cfg.CreateMap<MatchUpdateApiModel, Match>();
        }
    }
}


