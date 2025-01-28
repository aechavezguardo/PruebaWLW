namespace BackEnd.Models
{
    public class TblDetalleFactura
    {
        public int Id { get; set; }
        public int IdFactura { get; set; }
        public int IdProducto { get; set; }
        public int CantidadDeProducto { get; set; }
        public decimal PrecioUnitarioProducto { get; set; }
        public decimal SubtotalProducto { get; set; }
        public string Notas { get; set; }
        public TblFactura Factura { get; set; }
        public CatProducto Producto { get; set; }
    }
}
