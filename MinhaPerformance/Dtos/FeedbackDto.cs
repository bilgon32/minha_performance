using System;
using MinhaPerformance.Models;

namespace MinhaPerformance.Dtos
{
    public class FeedbackDto : DtoBase
    {
        public string Tipo { get; set; }
        public bool Ativo { get; set; }
        public List<CriterioDto> Criterios { get; set; }
    }
}

