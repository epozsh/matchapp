using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MatchAPP.Domain.Entities
{
    public class MatchOdd
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public int MatchId { get; set; }
        [Required]
        public Match Match { get; set; }
        public double Odd { get; set; }
    }

}
