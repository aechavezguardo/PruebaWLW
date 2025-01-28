import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { InvoiceService } from './invoice.service';

@Component({
  selector: 'app-invoice',
  standalone: false,  
  templateUrl: './invoice.component.html',
  styleUrl: './invoice.component.scss'
})
export class InvoiceComponent {

  clientes: any[] = [];
  productos: any[] = [];
  invoiceForm: FormGroup;
  invoiceDetailForm: FormGroup;

  constructor(private fb: FormBuilder, private invoiceService: InvoiceService) {
    this.invoiceForm = this.fb.group({
      Id: [null],
      FechaEmisionFactura: [null, Validators.required],
      IdCliente: [null, Validators.required],
      NumeroFactura: [null, Validators.required],
      NumeroTotalArticulos: [null, Validators.required],
      SubTotalFacturas: [null, Validators.required],
      TotalImpuestos: [null, Validators.required],
      TotalFactura: [null, Validators.required]
    });

    this.invoiceDetailForm = this.fb.group({
      Id: [null],
      IdFactura: [null, Validators.required],
      IdProducto: [null, Validators.required],
      CantidadDeProducto: [null, Validators.required],
      PrecioUnitarioProducto: [null, Validators.required],
      SubtotalProducto: [null, Validators.required],
      Notas: [null]
    });
  }

  ngOnInit(): void {
    this.loadClientes();
    this.loadProductos();
  }

  loadClientes() {
    this.invoiceService.getClientes().subscribe(
      data => {
        this.clientes = data;
      },
      error => {
        console.error('Error al cargar clientes', error);
      }
    );
  }

  openNewInvoiceDialog(){
    
  }

  loadProductos() {
    this.invoiceService.getProductos().subscribe(
      data => {
        this.productos = data;
      },
      error => {
        console.error('Error al cargar productos', error);
      }
    );
  }

  saveInvoice() {
    this.invoiceService.saveInvoice(this.invoiceForm.value).subscribe(
      response => {
        console.log('Factura guardada', response);
      },
      error => {
        console.error('Error al guardar la factura', error);
      }
    );
  }

  saveInvoiceDetail() {
    this.invoiceDetailForm.patchValue({ IdFactura: this.invoiceForm.value.Id });
    this.invoiceService.saveInvoiceDetail(this.invoiceDetailForm.value).subscribe(
      response => {
        console.log('Detalle de factura guardado', response);
      },
      error => {
        console.error('Error al guardar el detalle de la factura', error);
      }
    );
  }
}
