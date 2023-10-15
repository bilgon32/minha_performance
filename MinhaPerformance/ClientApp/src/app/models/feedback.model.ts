import { BaseModel } from "./base.model";
import { Criterio } from "./criterio.model";

export class Feedback extends BaseModel {
  public tipo: string = "";
  public ativo: boolean = true;
  public criterios: Criterio[] = [];
}
