using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MatchAPP.Domain.Entities
{
    // Todo: Check changing naming to Odd instead of MatchOdd
    public class MatchOdd : BaseEntity
    {
        [Required]
        public int MatchId { get; set; }
        [Required]
        public Match Match { get; set; }
        [MaxLength(3)]
        public string Specifier { get; set; }
        [Required]
        public double Odd { get; set; }
    }

}
