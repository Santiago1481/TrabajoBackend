using Entity.Model.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Model
{
    public class RolUser : EntityBase
    {
        public int idUsuario { get; set; }
        public Usuario Usuario { get; set; }
        public int idRol { get; set; }
        public Rol Rol { get; set; }
    }
}
