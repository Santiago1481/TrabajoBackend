using Entity.Model.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Model
{
    public class Pedidos : EntityBase
    {

        public DateTime FechaHoraPedido { get; set; }
        public required string Estado { get; set; }

        public int MesaId { get; set; }
        public required Mesa Mesa { get; set; }

        public int EmpleadoId { get; set; }
        public required Rol Rol { get; set; }

        public ICollection<Productos> Productos { get; set; } = new List<Productos>();
    }
}
