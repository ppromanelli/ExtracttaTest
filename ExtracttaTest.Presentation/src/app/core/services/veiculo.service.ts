import { Injectable } from "@angular/core";
import { VeiculoModel } from "../models/veiculo.model";
import { BaseService } from "./base/base.service";

@Injectable({
  providedIn: "root"
})
export class VeiculoService extends BaseService<VeiculoModel> {
  protected override RESOURCE: string = "veiculo";
  constructor() {
    super()
  }


  calculaValorSeguro(valorVeiculo: number) {
    this.request("POST", "calculaSeguro", undefined, { valor: valorVeiculo }).subscribe((response) => {
      console.log(response)
    })
  }
}
