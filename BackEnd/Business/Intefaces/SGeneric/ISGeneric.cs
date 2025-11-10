using Entity.DTOs;
using Entity.Model.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Intefaces.SGeneric
{
    public interface ISGeneric<TModel, TDTO>
        where TModel : EntityBase  // El Modelo de la base de datos
        where TDTO : BaseDTO       // El DTO que usa la API
    {
        Task<TDTO> CreateService(TDTO dto);
        Task<bool> DeleteService(int id);
        Task<List<TDTO>> GetAllService();
        Task<TDTO?> GetByIdService(int id);
        Task<TDTO> UpdateService(TDTO dto);
    }
}
