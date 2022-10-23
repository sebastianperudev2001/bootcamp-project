import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";
import { environment } from "../../environments/environment";

@Injectable({
  providedIn: 'root'
})
export class ProductoService {

  constructor(private httpclient: HttpClient) { }

  getProductoID(idProducto: any): Observable<any> {
    return this.httpclient.get(`${environment.apiUrl}/producto/${idProducto}`,);
  }

  getAll(): Observable<any> {
    return this.httpclient.get(`${environment.apiUrl}/producto`);
  }

  create(producto: any): Observable<any> {
    return this.httpclient.post(`${environment.apiUrl}/producto`, producto);
  }

  update(producto: any): Observable<any> {
    return this.httpclient.put(`${environment.apiUrl}/producto`, producto);
  }

  delete(idProducto: any): Observable<any> {
    return this.httpclient.delete(`${environment.apiUrl}/producto/${idProducto}`,);
  }

  getCategoria(): Observable<any> {
    return this.httpclient.get(`${environment.apiUrl}/categoria`);
  }

  getProveedor(): Observable<any> {
    return this.httpclient.get(`${environment.apiUrl}/proveedor`);
  }
}
