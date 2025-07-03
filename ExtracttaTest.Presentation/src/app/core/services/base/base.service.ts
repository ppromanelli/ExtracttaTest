import { Observable, take } from "rxjs";
import { BaseModel } from "../../models/base/base.model";
import { inject } from "@angular/core";
import { HttpClient } from "@angular/common/http";

export abstract class BaseService<TModel extends BaseModel> {
  protected BASE_URL = "https://localhost:5001";
  protected abstract readonly RESOURCE: string;
  private _http = inject(HttpClient);
  constructor() {
  }

  list(): Observable<TModel[]> {
    return this._http.get<TModel[]>(this.getUrl()).pipe(take(1));
  }
  get(id: number): Observable<TModel> {
    return this._http.get<TModel>(this.getUrl(id)).pipe(take(1));
  }
  create(body: Partial<TModel>): Observable<TModel> {
    return this._http.post<TModel>(this.getUrl(), body).pipe(take(1));
  }
  request<T>(method: string, resource?: string, id?: number, data?: any, headers: any = {}): Observable<T> {
    let finalUrl: string = this.getUrl(id)
    let body: any = null;
    if (data && method.toUpperCase() == "GET") {
      finalUrl += `/${resource}?${this.objectToQueryString(data)}`;
    }
    else {
      finalUrl += `/${resource}`;
      body = data;
    }
    return this._http.request<T>(
      method.toUpperCase(),
      `${finalUrl}`,
      { body: body, headers }).pipe(take(1));
  }

  private getUrl(id?: number) {
    return `${this.BASE_URL}/${this.RESOURCE}${id ? "/" + id : ""}`
  }
  private objectToQueryString(obj: any): string {
    const str = [];
    for (const p in obj)
      if (obj.hasOwnProperty(p)) {
        if (typeof (obj[p]) === "object") {
          str.push(encodeURIComponent(p) + "=" + encodeURIComponent(JSON.stringify(obj[p])));
        } else {
          str.push(encodeURIComponent(p) + "=" + encodeURIComponent(obj[p]));
        }
      }
    return str.join("&");
  }
}
