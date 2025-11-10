using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DTOs
{
    public class ProductosDTO : BaseDTO
    {

        public required string NombreProducto { get; set; }
        public decimal Precio { get; set; }
    }
}
