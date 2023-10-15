using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace MinhaPerformance.Models
{
	public class HistoricoFeedbackCriterio : ModelBase
	{
		public virtual HistoricoFeedback? HistoricoFeedback { get; set; }
		public virtual Criterio? Criterio { get; set; }
		public virtual string Valor { get; set; }

    }
}

