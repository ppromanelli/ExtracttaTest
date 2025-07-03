import { BaseModel } from "./base/base.model";
import { VeiculoModel } from "./veiculo.model";

export interface SeguroModel extends BaseModel {
  seguradoId: number;
  veiculoId: number;
  valorSeguro: number;
  veiculo: VeiculoModel;
  seguro: SeguroModel;
}
