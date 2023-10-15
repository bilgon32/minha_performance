using System;
namespace MinhaPerformance.Models
{
	public class Feedback : ModelBase
	{
		public virtual string Tipo { get; set; }
		public virtual bool Ativo { get; set; }
		public virtual List<Criterio> Criterios { get; set; }
		public virtual List<HistoricoFeedback> HistoricoFeedbacks { get; set; }
	}
}

