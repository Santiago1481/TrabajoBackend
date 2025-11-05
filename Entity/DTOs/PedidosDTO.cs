using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DTOs
{
    public class PedidosDTO : BaseDTO
    {

        public DateTime FechaHoraPedido { get; set; }
        public required string Estado { get; set; }
        public int MesaId { get; set; }
        public int EmpleadoId { get; set; }
    }
}
