using Entity.Model.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Model
{
    public class Modificadores : EntityBase
    {
        public required string Nombre { get; set; }
        public decimal PrecioAdicional { get; set; }

        // Relación uno a muchos con DetalleModificador
        public ICollection<DetalleModificador> DetalleModificadores { get; set; }
    }
}
