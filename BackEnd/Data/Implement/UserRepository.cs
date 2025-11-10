using Data.Implement.LogicaGenerica;
using Data.Intefaces;
using Entity.Context;
using Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Implement
{
    public class UserRepository : ModelGenerico<Usuario>, IUserRepository
    {
        private readonly ApplicationDbContext _context;
        public UserRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Usuario> GetByCredencialesAsync(string Email, string Password)
        {
            return _context.Usuarios.FirstOrDefault(u => u.Email == Email && u.Password == Password);
        }
    }
}
