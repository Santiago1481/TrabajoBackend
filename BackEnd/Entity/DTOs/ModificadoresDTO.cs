using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DTOs
{
    public class ModificadoresDTO : BaseDTO
    {
        public required string Nombre { get; set; }
        public decimal PrecioAdicional { get; set; }
    }
}
