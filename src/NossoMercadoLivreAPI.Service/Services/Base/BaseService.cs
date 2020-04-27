using AutoMapper;
using FluentValidation;
using System;
using System.Collections.Generic;
using NossoMercadoLivreAPI.Domain.Entities.Base;
using NossoMercadoLivreAPI.Domain.Interfaces.Repositories;
using NossoMercadoLivreAPI.Domain.Interfaces.Services;
using NossoMercadoLivreAPI.Domain.Interfaces.UnitOfWork;
using NossoMercadoLivreAPI.Domain.Request.Base;
using NossoMercadoLivreAPI.Domain.Response.Base;
using NossoMercadoLivreAPI.Infra.Resources;
using System.Threading.Tasks;

namespace NossoMercadoLivreAPI.Service.Services.Base
{
    public class BaseService<T, R, E> : IService<T, R, E> where T : BaseRequest
                                                          where R : BaseResponse
                                                          where E : BaseEntity
    {
        private readonly IRepository<E> _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public BaseService(IRepository<E> repository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public virtual async Task<R> InsertAsync<V>(T entity) where V : AbstractValidator<T>
        {
            try
            {
                await ValidateAsync(entity, Activator.CreateInstance<V>());
                
                await _unitOfWork.BeginAsync();
                E entitySave = _mapper.Map<E>(entity);
                await _repository.InsertAsync(entitySave);
                await _unitOfWork.CommitAsync();

                return _mapper.Map<R>(entitySave);
            }
            catch (ValidationException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                await _unitOfWork.RollBackAsync();
                throw ex;
            }
        }

        public virtual async Task<R> UpdateAsync<V>(T entity) where V : AbstractValidator<T>
        {
            try
            {
                await ValidateAsync(entity, Activator.CreateInstance<V>());

                await _unitOfWork.BeginAsync();
                E entityUpdate = _mapper.Map<E>(entity);
                await _repository.UpdateAsync(entityUpdate);
                await _unitOfWork.CommitAsync();

                return _mapper.Map<R>(entityUpdate);
            }
            catch (ValidationException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                await _unitOfWork.RollBackAsync();
                throw ex;
            }
        }

        public virtual async Task RemoveAsync(long id)
        {
            if (id == 0)
                throw new Exception(MessagesAPI.ID_INVALID);

            try
            {
                await _unitOfWork.BeginAsync();
                await _repository.RemoveAsync(id);
                await _unitOfWork.CommitAsync();
            }
            catch (Exception ex)
            {
                await _unitOfWork.RollBackAsync();
                throw ex;
            }
        }

        public virtual async Task<List<R>> GetAllAsync()
        {
            return _mapper.Map<List<R>>(await _repository.GetAllAsync());
        } 

        public virtual async Task<R> GetByIdAsync(long id)
        {
            if (id == 0)
                throw new Exception(MessagesAPI.ID_INVALID);

            return _mapper.Map<R>(await _repository.GetOneByFilterWithIncludesAsync(g => g.Id == id));
        }

        protected async Task ValidateAsync(T entity, AbstractValidator<T> validator)
        {
            if (entity is null)
                throw new ValidationException(MessagesAPI.OBJECT_INVALID);

            await validator.ValidateAndThrowAsync(entity);
        }
    }
}
