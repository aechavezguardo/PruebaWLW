import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class FacturaService {
  private apiUrl = 'http://localhost:5000/api/facturas';

  constructor(private http: HttpClient) {}

  getClientes(): Observable<any[]> {
    return this.http.get<any[]>(`${this.apiUrl}/clientes`);
  }

  guardarFactura(factura: any): Observable<any> {
    return this.http.post(`${this.apiUrl}/guardar`, factura);
  }
}