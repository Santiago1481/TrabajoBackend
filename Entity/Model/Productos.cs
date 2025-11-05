using Entity.Model.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Model
{
    public class Productos : EntityBase 

    {

        public required string NombreProducto { get; set; }
        public decimal Precio { get; set; }

        public int IdPedido { get; set; }
        public  Pedidos Pedido { get; set; }
        // Relación uno a muchos con DetalleModificador
        public ICollection<DetalleModificador> DetalleModificadores { get; set; } = new List<DetalleModificador>();
    }
}
