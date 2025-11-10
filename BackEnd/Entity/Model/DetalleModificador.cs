using Entity.Model.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Model
{
    public class DetalleModificador : EntityBase
    {

        public int ModificadorId { get; set; }
        public required Modificadores Modificador { get; set; }

        public int ProductoId { get; set; }
        public required Productos Producto { get; set; }
    }
}
