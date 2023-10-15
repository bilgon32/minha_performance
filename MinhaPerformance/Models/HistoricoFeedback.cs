using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace MinhaPerformance.Models
{
    public class HistoricoFeedback : ModelBase
    {
        [ForeignKey("FeedbackId")]
        public virtual Feedback Feedback { get; set; }
        [ForeignKey("ReceptorId")]
        public virtual ApplicationUser Receptor { get; set; }
        [ForeignKey("ProvedorId")]
        public virtual ApplicationUser Provedor { get; set; }
        public virtual List<HistoricoFeedbackCriterio> HistoricoFeedbackCriterios { get; set; }

        public virtual DateTime? VisualizadoEm { get; set; }
    }
}

