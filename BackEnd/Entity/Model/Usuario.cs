using Entity.Model.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Model
{
    public class Usuario : EntityBase
    {

        public required string Username { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }


        public ICollection<RolUser> RolUsers { get; set; } = new List<RolUser>();

    }
}