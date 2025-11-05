using Data.Intefaces.IGeneric;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Implement.LogicaGenerica
{
    public abstract class Generico<T> : IGeneric<T> where T : class
    {
        public abstract Task<T> Create(T entity);
        public abstract Task<bool> Delete(int id);
        public abstract Task<List<T>> GetAll();
        public abstract Task<T?> GetById(int id);
        public abstract Task<T> Update(T entity);
    }
}
