import { Injectable } from "@angular/core";
import { SeguradoModel } from "../models/segurado.model";
import { BaseService } from "./base/base.service";

@Injectable({
  providedIn: "root"
})
export class SeguroService extends BaseService<SeguradoModel> {
  protected override RESOURCE: string = "seguro";
  constructor() {
    super()
  }

  calculaMediaAritmetica(filter?: string) {
    this.request("GET", "mediaAritmetica", undefined, { filter });
  }
}
