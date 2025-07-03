import { BaseModel } from "./base/base.model";

export interface VeiculoModel extends BaseModel {
  valor: number;
  marcaModelo: string;
}
