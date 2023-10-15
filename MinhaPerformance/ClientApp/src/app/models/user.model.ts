import { BaseModel } from "./base.model";

export class User extends BaseModel {
  public userName: string = "";
  public email: string = "";
  public pictureURL: string = "";
}
