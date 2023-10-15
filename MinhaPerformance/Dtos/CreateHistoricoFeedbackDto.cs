using System;
namespace MinhaPerformance.Dtos
{
	public class CreateHistoricoFeedbackDto : DtoBase
	{
        public string FeedbackId { get; set; }
        public string ReceptorId { get; set; }
        public string ProvedorId { get; set; }
        public List<CreateHistoricoFeedbackCriterioDto> HistoricoFeedbackCriterios { get; set; }
    }
}

