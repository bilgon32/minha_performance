using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace MinhaPerformance.Models
{
	public class Criterio : ModelBase
	{
		public virtual string Titulo { get; set; }
		public virtual bool Quantitativo { get; set; }
        [ForeignKey("FeedbackId")]
        public virtual Feedback Feedback { get; set; }
		public virtual List<HistoricoFeedbackCriterio> HistoricoFeedbackCriterios { get; set; }
	}
}

