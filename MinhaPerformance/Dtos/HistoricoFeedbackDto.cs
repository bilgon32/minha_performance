using System;
using MinhaPerformance.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace MinhaPerformance.Dtos
{
	public class HistoricoFeedbackDto : DtoBase
	{
        public FeedbackDto Feedback { get; set; }
        public ApplicationUserDto Receptor { get; set; }
        public ApplicationUserDto Provedor { get; set; }
        public List<HistoricoFeedbackCriterioDto> HistoricoFeedbackCriterios { get; set; }

        public virtual DateTime? VisualizadoEm { get; set; }
    }
}

