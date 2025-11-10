using AutoMapper;
using Data.Intefaces.IGeneric;
using Entity.DTOs;
using Entity.Model.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Implements.LogicaGenerica
{
    public class SModeloGenerico<TModel, TDTO>: SGenerico<TModel, TDTO>
         where TModel : EntityBase
         where TDTO : BaseDTO
    {
        protected readonly IGeneric<TModel> _genericRepository;
        protected readonly IMapper _mapper;

        public SModeloGenerico(IGeneric<TModel> Repository, IMapper mapper)
        {
            _genericRepository = Repository;
            _mapper = mapper;
        }

        public override async Task<TDTO> CreateService(TDTO dto)
        {
            var model = _mapper.Map<TModel>(dto);
            var createdModel = await _genericRepository.Create(model);
            return _mapper.Map<TDTO>(createdModel);
        }



        public override async Task<bool> DeleteService(int id)
        {
            return await _genericRepository.Delete(id);
        }



        public override async Task<List<TDTO>> GetAllService()
        {
            var models = await _genericRepository.GetAll();
            return _mapper.Map<List<TDTO>>(models);
        }


        public override async Task<TDTO?> GetByIdService(int id)
        {
            var model = await _genericRepository.GetById(id);
            return model == null ? null : _mapper.Map<TDTO>(model);
        }


        public override async Task<TDTO> UpdateService(TDTO dto)
        {
            var model = _mapper.Map<TModel>(dto);
            var updatedModel = await _genericRepository.Update(model);
            return _mapper.Map<TDTO>(updatedModel);
        }

    }
}