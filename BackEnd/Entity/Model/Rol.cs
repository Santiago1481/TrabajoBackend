using Entity.Model.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Model
{
    public class Rol : EntityBase
    {

        public required string NombreRol { get; set; }

        
        public ICollection<RolUser> RolUsers { get; set; } = new List<RolUser>();

        public ICollection<Pedidos> Pedidos { get; set; } = new List<Pedidos>();
    }
}
