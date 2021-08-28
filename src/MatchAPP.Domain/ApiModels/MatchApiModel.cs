using MatchAPP.Domain.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MatchAPP.Domain.ApiModels
{
    public class MatchApiModel
    {
        public int ID { get; set; }
        public string Description { get; set; }
        public string MatchDate { get; set; }
        public string MatchTime { get; set; }
        public string TeamA { get; set; }
        public string TeamB { get; set; }
        public string Sport { get; set; }

        public IList<MatchOddApiModel> Odds { get; set; }

        public MatchApiModel()
        {
            Odds = new List<MatchOddApiModel>();
        }
    }

    public class MatchAddApiModel
    {
        public string Description { get; set; }
        [Required]
        public string MatchDate { get; set; }
        [Required]
        public string MatchTime { get; set; }
        [MaxLength(10)]
        [Required]
        public string TeamA { get; set; }
        [MaxLength(10)]
        [Required]
        public string TeamB { get; set; }
        [Required]
        public SportType Sport { get; set; }
    }

    public class MatchUpdateApiModel : MatchAddApiModel
    {
        public int ID { get; set; }
    }

}
