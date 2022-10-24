import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";

@Injectable({
  providedIn: 'root'
})
export class ProductoService {

  constructor(private httpclient: HttpClient) { }

  apiUrl = "https://appproyectosebaschavarry.azurewebsites.net/"

  getProductoID(idProducto: any): Observable<any> {
    return this.httpclient.get(`${this.apiUrl}/producto/${idProducto}`,);
  }

  getAll(): Observable<any> {
    return this.httpclient.get(`${this.apiUrl}/producto`);

  }

  create(producto: any): Observable<any> {
    return this.httpclient.post(`${this.apiUrl}/producto`, producto);
  }

  update(producto: any): Observable<any> {
    return this.httpclient.put(`${this.apiUrl}/producto`, producto);
  }

  delete(idProducto: any): Observable<any> {
    return this.httpclient.delete(`${this.apiUrl}/producto/${idProducto}`,);
  }

  getCategoria(): Observable<any> {
    return this.httpclient.get(`${this.apiUrl}/categoria`);
  }

  getProveedor(): Observable<any> {
    return this.httpclient.get(`${this.apiUrl}/proveedor`);
  }
}
