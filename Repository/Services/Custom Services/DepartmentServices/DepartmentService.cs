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

namespace Infrastructure.Services.Custom_Services.DepartmentServices
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IRepository<Department> _repository;

        public DepartmentService(IRepository<Department> repository)
        {
            _repository = repository;
        }
        public async Task<bool> Add(DeparmentInsertModel DepartmentInsertModel)
        {
            if (DepartmentInsertModel == null)
            {
                Department department = new()
                {
                    Dep_Name = DepartmentInsertModel.Dep_Name,
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now
                };
                var result = await _repository.Insert(department);
                return result;
            }
            else
                return false;
        }

        public async Task<bool> Delete(int id)
        {
            if (id != null)
            {
                Department department = await _repository.Get(id);
                if (department != null)
                {
                    _ = _repository.Delete(department);
                    return true;
                }
                else
                    return false;
            }
            else
                return false;
        }

        public Task<Department> Find(Expression<Func<Department, bool>> match)
        {
            return _repository.Find(match);
        }

        public async Task<ICollection<DeparmentViewModel>> GetAll()
        {
            ICollection<DeparmentViewModel> employeeViewModels = new List<DeparmentViewModel>();

            ICollection<Department> departments = await _repository.GetAll();
            foreach (Department emp in departments)
            {
                DeparmentViewModel employeeViewModel = new()
                {
                    Id = emp.Id,
                    Dep_Name = emp.Dep_Name
                };
                employeeViewModels.Add(employeeViewModel);

            }
            if (departments == null)
            {
                return null;
            }
            return employeeViewModels;
        }

        public async Task<DeparmentViewModel> GetById(int id)
        {
            var department = await _repository.Get(id);
            if (department == null)
            {
                return null;
            }
            else
            {
                DeparmentViewModel viewModel = new()
                {
                    Id = department.Id,
                    Dep_Name = department.Dep_Name,  
                };
                return viewModel;
            }
        }

        public async Task<bool> Update(DeparmentUpdateModel DeparmentUpdateModel)
        {
            Department department = await _repository.Get(DeparmentUpdateModel.Id);
            if (department != null)
            {
                department.Dep_Name = DeparmentUpdateModel.Dep_Name;
                
                department.CreatedDate = department.CreatedDate;
                department.UpdatedDate = DateTime.Now;

                var result = await _repository.Update(department);
                return result;
            }
            else
            {
                return false;
            }
        }
    }
}
