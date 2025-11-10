using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DTOs
{
    public class DetalleModificadorDTO : BaseDTO
    {

        public int DetallePedidoId { get; set; }
        public int ModificadorId { get; set; }
        public int ProductoId { get; set; }
    }
}
