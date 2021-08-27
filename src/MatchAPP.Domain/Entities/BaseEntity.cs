using System;
using System.ComponentModel.DataAnnotations;

namespace MatchAPP.Domain.Entities
{
    public abstract class BaseEntity
    {
        [Key]
        public int ID { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
