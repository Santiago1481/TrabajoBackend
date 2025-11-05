using Business.Intefaces.SGeneric;
using Entity.DTOs;
using Entity.Model.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Implements.LogicaGenerica
{
    public abstract class SGenerico<TModel, TDTO> : ISGeneric<TModel, TDTO>
         where TModel : EntityBase
         where TDTO : BaseDTO
    {
        
        public abstract Task<TDTO> CreateService(TDTO dto);
        public abstract Task<bool> DeleteService(int id);
        public abstract Task<List<TDTO>> GetAllService();
        public abstract Task<TDTO?> GetByIdService(int id);
        public abstract Task<TDTO> UpdateService(TDTO dto);
    }
}
