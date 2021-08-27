using AutoMapper;

namespace MatchAPP.Domain.Mapper
{
    /// <summary>
    /// Setup all mappers here
    /// </summary>
    public static class AutomapperSetup
    {
        public static IMapperConfigurationExpression AddMappings(
            this IMapperConfigurationExpression configurationExpression)
        {  
            MatchMapper.Set(configurationExpression);
            MatchOddMapper.Set(configurationExpression);

            return configurationExpression;
        }
    }
}
