using System;
using System.ComponentModel.DataAnnotations;

namespace MinhaPerformance.Models
{
    public abstract class ModelBase
    {
        [Key]
        public string Id { get; set; }
        public DateTime DataCriacao { get; set; }
    }
}

