using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Entidades
{
    public class Pedido
    {
        
        public string IdentidadCliente { get; set; }
        public string NombreCliente { get; set; }
        public DateTime Fecha { get; set; }
        public string Producto { get; set; }
        public decimal Precio { get; set; }

        public Pedido(string identidadCliente, string nombreCliente, DateTime fecha, string producto, decimal precio)
        {
            IdentidadCliente = identidadCliente;
            NombreCliente = nombreCliente;
            Fecha = fecha;
            Producto = producto;
            Precio = precio;
        }

        public Pedido()
        {
        }


    }
}
