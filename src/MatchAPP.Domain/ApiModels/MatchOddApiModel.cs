using MatchAPP.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace MatchAPP.Domain.ApiModels
{
    public class MatchOddApiModel
    {
        public int ID { get; set; }
        public int MatchId { get; set; }
        public string Match { get; set; } // TeamA - TeamB
        public string Specifier { get; set; }
        public double Odd { get; set; }
    }

    public class MatchOddAddApiModel
    {
        [Required]
        public int MatchId { get; set; }
        [MaxLength(3)]
        public string Specifier { get; set; }
        [Required]
        public double Odd { get; set; }
    }

    public class MatchOddUpdateApiModel : MatchOddAddApiModel
    {
        public int ID { get; set; }
    }
}
