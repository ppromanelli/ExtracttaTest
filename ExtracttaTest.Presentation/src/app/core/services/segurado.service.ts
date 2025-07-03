import { Injectable } from "@angular/core";
import { SeguradoModel } from "../models/segurado.model";
import { BaseService } from "./base/base.service";

@Injectable({
  providedIn: "root"
})
export class SeguradoService extends BaseService<SeguradoModel> {
  protected override RESOURCE: string = "segurado";
  constructor() {
    super()
  }
}
