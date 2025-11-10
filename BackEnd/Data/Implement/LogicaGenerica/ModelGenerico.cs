using Entity.Context;
using Entity.Model.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Implement.LogicaGenerica
{
    public class ModelGenerico<T> : Generico<T> where T : EntityBase
    {
        protected readonly ApplicationDbContext _context; 
        protected readonly DbSet<T> _dbSet;
        public ModelGenerico(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }
        public override async Task<T> Create(T entity)
        {
            _dbSet.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }   
        public override async Task<bool> Delete(int id)
        {
            var entity = await GetById(id);
            if (entity == null) return false;
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
        public override async Task<List<T>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }
        public override async Task<T?> GetById(int id)
        {
            return await _dbSet.FirstOrDefaultAsync(e => e.Id == id);
        }
        public override async Task<T> Update(T entity)
        {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }


    }
}
