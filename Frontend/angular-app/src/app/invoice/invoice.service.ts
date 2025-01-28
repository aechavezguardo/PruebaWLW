import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Invoice, InvoiceDetail } from './invoiceModel';

@Injectable({
  providedIn: 'root'
})
export class InvoiceService {
  private apiUrl = 'https://localhost:7128/api/Facturas';

  constructor(private http: HttpClient) {}

  saveInvoice(invoice: Invoice) {
    return this.http.post<Invoice>(`${this.apiUrl}/InsertFactura`, invoice);
  }

  saveInvoiceDetail(invoiceDetail: InvoiceDetail) {
    return this.http.post<InvoiceDetail>(`${this.apiUrl}/InsertFacturaDetalle`, invoiceDetail);
  }

  getClientes() {
    return this.http.get<any[]>('https://localhost:7128/api/Clientes/GetClientes');
  }
  
  getProductos() {
    return this.http.get<any[]>('https://localhost:7128/api/Clientes/GetProductos');
  }
}