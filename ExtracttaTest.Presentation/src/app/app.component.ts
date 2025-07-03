import { Component, inject, OnInit } from '@angular/core';
import { SeguroService } from './core/services/seguro.service';
import { SeguradoService } from './core/services/segurado.service';
import { VeiculoService } from './core/services/veiculo.service';
import { MediaAritmeticaModel } from './core/models/commons/media-aritmetica.model';
import { SeguradoModel } from './core/models/segurado.model';
import { VeiculoModel } from './core/models/veiculo.model';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  standalone: false,
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit {
  title = 'ExtracttaTest.Presentation';
  private _seguroService = inject(SeguroService);
  private _seguradoService = inject(SeguradoService);
  private _veiculoService = inject(VeiculoService);

  protected listMediaSegurado: MediaAritmeticaModel[] = [];
  protected listMediaVeiculo: MediaAritmeticaModel[] = [];
  protected listMediaGeral: MediaAritmeticaModel[] = [];


  protected listSegurado: SeguradoModel[] = [];
  protected listVeiculo: VeiculoModel[] = [];


  ngOnInit(): void {
    this._seguroService.request<MediaAritmeticaModel[]>("GET", "mediaAritmetica", undefined, { filter: "segurado" }).subscribe((response: MediaAritmeticaModel[]) => {
      this.listMediaSegurado = response
      console.log(this.listMediaSegurado)
    })
    this._seguroService.request<MediaAritmeticaModel[]>("GET", "mediaAritmetica", undefined, { filter: "veiculo" }).subscribe((response: MediaAritmeticaModel[]) => {
      this.listMediaVeiculo = response
      console.log(this.listMediaVeiculo)
    })
    this._seguroService.request<MediaAritmeticaModel[]>("GET", "mediaAritmetica").subscribe((response: MediaAritmeticaModel[]) => {
      this.listMediaGeral = response
      console.log(this.listMediaGeral)
    })

    this._seguradoService.list().subscribe((response: SeguradoModel[]) => {
      this.listSegurado = response
    })

    this._veiculoService.list().subscribe((response: VeiculoModel[]) => {
      this.listVeiculo = response
    })
  }
}
