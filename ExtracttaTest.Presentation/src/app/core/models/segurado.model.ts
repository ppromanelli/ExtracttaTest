import { BaseModel } from "./base/base.model";

export interface SeguradoModel extends BaseModel {
  nome: string;
  cpf: string;
  idade: number;
}
