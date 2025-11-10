using Data.Intefaces.IGeneric;
using Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Intefaces
{
    public interface IUserRepository : IGeneric<Usuario>
    {
        Task<Usuario> GetByCredencialesAsync(string Email, string Password);
    }
}
