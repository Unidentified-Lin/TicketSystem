using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using AutoMapper;
using TicketSystemRepo.Interfaces;
using TicketSystem.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace TicketSystem.Services
{
    public class GenericService<T> : IService<T> where T : class
    {
        private readonly IUnitOfWorks _unitOfWorks;
        private readonly IMapper _mapper;
        public GenericService(IUnitOfWorks unitOfWorks, IMapper mapper)
        {
            _unitOfWorks = unitOfWorks;
            _mapper = mapper;
        }
        public virtual List<TViewModel> GetListToViewModel<TViewModel>(Expression<Func<T, bool>> filter = null, params Expression<Func<T, object>>[] includes)
        {
            var data = _unitOfWorks.Repository<T>().Entity();
            if (includes != null)
            {
                foreach (var item in includes)
                {
                    data.Include(item);
                }
            }
            if (filter != null)
            {
                data = data.Where(filter);
            }
            return _mapper.Map<List<TViewModel>>(data);
        }

        public virtual TViewModel GetSpecificDetailToViewModel<TViewModel>(Expression<Func<T, bool>> filter, params Expression<Func<T, object>>[] includes)
        {
            var data = _unitOfWorks.Repository<T>().Entity();
            if (includes != null)
            {
                foreach (var item in includes)
                {
                    data.Include(item);
                }
            }
            if (filter != null)
            {
                data = data.Where(filter);
            }
            return _mapper.Map<TViewModel>(data.FirstOrDefault());
        }

        public virtual void CreateViewModelToDatabase<TViewModel>(TViewModel viewModel)
        {
            try
            {
                var entity = _mapper.Map<T>(viewModel);
                _unitOfWorks.Repository<T>().Insert(entity);
                _unitOfWorks.SaveChange();
            }
            catch (Exception ex)
            {
                //log exception
            }
        }

        public virtual void UpdateViewModelToDatabase<TViewModel>(TViewModel viewModel, object id)
        {
            try
            {
                var entity = _unitOfWorks.Repository<T>().GetById(id);
                if (entity is null)
                {
                    return;
                }
                _mapper.Map(viewModel, entity);
                _unitOfWorks.Repository<T>().Update(entity);
                _unitOfWorks.SaveChange();
            }
            catch (Exception ex)
            {
                //log exception
            }
        }

        public virtual void Delete(Expression<Func<T, bool>> filter)
        {
            try
            {
                var entity = _unitOfWorks.Repository<T>().Entity().Where(filter).FirstOrDefault();
                if (entity is null)
                {
                    return;
                }
                _unitOfWorks.Repository<T>().Delete(entity);
                _unitOfWorks.SaveChange();
            }
            catch (Exception ex)
            {
                //log exception
            }
        }
    }
}
