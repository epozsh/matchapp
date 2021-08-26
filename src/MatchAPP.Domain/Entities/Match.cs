using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MatchAPP.Domain.Entities
{
    public class Match
    {
        public Match()
        {
            MatchOdds = new List<MatchOdd>();

        }

        [Key]
        public int ID { get; set; }
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

        public IList<MatchOdd> MatchOdds { get; set; }
    }
       

    public enum SportType
    {
        Football = 1,
        Basketball = 2
    }
}
