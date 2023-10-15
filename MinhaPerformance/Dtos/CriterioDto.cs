using System;
using MinhaPerformance.Models;

namespace MinhaPerformance.Dtos
{
	public class CriterioDto : DtoBase
	{
        public string Titulo { get; set; }
        public bool Quantitativo { get; set; }
        public string FeedbackId { get; set; }
    }
}

