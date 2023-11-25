using Domain.Model;
using Domain.ViewModels;
using Infrastructure.Context;
using Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services.Custom_Services.SallaryServices
{
    public class SallaryService : ISallaryService
    {
        private readonly IRepository<Sallary> _repository;

        public SallaryService(IRepository<Sallary> repository)
        {
            _repository = repository;
        }
        public async Task<bool> Add(SallaryInsertModel SallaryInsertModel)
        {
            if (SallaryInsertModel == null)
            {
                Sallary sallary = new()
                {
                    Sal = SallaryInsertModel.Sallary,
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now
                };
                var result = await _repository.Insert(sallary);
                return result;
            }
            else
                return false;
        }

        public async Task<bool> Delete(int id)
        {
            if (id != null)
            {
                Sallary sallary = await _repository.Get(id);
                if (sallary != null)
                {
                    _ = _repository.Delete(sallary);
                    return true;
                }
                else
                    return false;
            }
            else
                return false;
        }
        

        public Task<Sallary> Find(Expression<Func<Sallary, bool>> match)
        {
            return _repository.Find(match);
        }

        public async Task<ICollection<SallaryViewModel>> GetAll()
        {
            ICollection<SallaryViewModel> employeeViewModels = new List<SallaryViewModel>();

            ICollection<Sallary> sallaries = await _repository.GetAll();
            foreach (Sallary sal in sallaries)
            {
                SallaryViewModel sallaryViewModel = new()
                {
                    Id = sal.Id,
                    Sallary = sal.Sal,
                };
                employeeViewModels.Add(sallaryViewModel);

            }
            if (sallaries == null)
            {
                return null;
            }
            return employeeViewModels;
        }

        public async Task<SallaryViewModel> GetById(int id)
        {
            var sallary = await _repository.Get(id);
            if (sallary == null)
            {
                return null;
            }
            else
            {
                SallaryViewModel viewModel = new()
                {
                    Id = sallary.Id,
                    Sallary = sallary.Sal
                };
                return viewModel;
            }
        }

        public async Task<bool> Update(SallaryUpdateModel SallaryUpdateModel)
        {
            Sallary sallary = await _repository.Get(SallaryUpdateModel.Id);
            if (sallary != null)
            {
                sallary.Sal = SallaryUpdateModel.Sallary;
                
                sallary.CreatedDate = sallary.CreatedDate;
                sallary.UpdatedDate = DateTime.Now;

                var result = await _repository.Update(sallary);
                return result;
            }
            else
            {
                return false;
            }
        }
    }
}
