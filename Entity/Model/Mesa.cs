using Entity.Model.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Model
{
    public class Mesa : EntityBase
    {

        public required string NumeroMesa { get; set; }

        public ICollection<Pedidos> Pedidos { get; set; } = new List<Pedidos>();
    }
}
