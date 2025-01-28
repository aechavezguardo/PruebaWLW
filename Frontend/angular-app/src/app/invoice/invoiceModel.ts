export interface Invoice {
    Id: number;
    FechaEmisionFactura: Date;
    IdCliente: number;
    NumeroFactura: number;
    NumeroTotalArticulos: number;
    SubTotalFacturas: number;
    TotalImpuestos: number;
    TotalFactura: number;
  }

  export interface InvoiceDetail {
    Id: number;
    IdFactura: number;
    IdProducto: number;
    CantidadDeProducto: number;
    PrecioUnitarioProducto: number;
    SubtotalProducto: number;
    Notas: string;
  }