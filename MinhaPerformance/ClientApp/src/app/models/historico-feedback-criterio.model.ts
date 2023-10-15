import { BaseModel } from "./base.model";
import { Criterio } from "./criterio.model";

export class HistoricoFeedbackCriterio extends BaseModel {
  public historicoFeedbackId: string = "";
  public criterioId: string = "";
  public criterio?: Criterio;
  public valor: string = "";

  constructor(init?: Partial<HistoricoFeedbackCriterio>) {
    super();
    if (init) Object.assign(this, init);
  }
}
