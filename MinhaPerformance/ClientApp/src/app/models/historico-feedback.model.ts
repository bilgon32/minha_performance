import { BaseModel } from "./base.model";
import { Feedback } from "./feedback.model";
import { HistoricoFeedbackCriterio } from "./historico-feedback-criterio.model";
import { User } from "./user.model";

export class HistoricoFeedback extends BaseModel {
  public feedbackId: string = "";
  public feedback?: Feedback;
  public receptorId: string = "";
  public receptor?: User;
  public provedorId: string = "";
  public provedor?: User;
  public historicoFeedbackCriterios: HistoricoFeedbackCriterio[] = [];
  public visualizadoEm?: Date;

  constructor(init?: Partial<HistoricoFeedback>) {
    super();
  }
}
