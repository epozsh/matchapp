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
            cfg.CreateMap<MatchOdd, MatchOddApiModel>();

            // Mapping from Api model to Entity 
            cfg.CreateMap<MatchOddApiModel, MatchOdd>();
            cfg.CreateMap<MatchOddAddApiModel, MatchOdd>();
        }
    }
}
