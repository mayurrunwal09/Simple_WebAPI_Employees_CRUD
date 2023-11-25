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

namespace Infrastructure.Services.Custom_Services.EmployeeServices
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IRepository<Employee> _repository;

        public EmployeeService(IRepository<Employee> repository)
        {
            _repository = repository;
        }

        public async Task<bool> Insert(EmployeeInsertModel EmployeeInsertModel)
        {     
            Employee employee = new()
            {
                Emp_Name = EmployeeInsertModel.Emp_Name,
                Emp_Addr = EmployeeInsertModel.Emp_Addr,
                PhoneNO = EmployeeInsertModel.PhoneNO,
                DateOfBirth = EmployeeInsertModel.DateOfBirth,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now
            };
            var result = await _repository.Insert(employee);
            return result;      
        }

        public async Task<bool> Delete(int id)
        {
            if (id != null)
            {
                Employee employee = await _repository.Get(id);
                if (employee != null)
                {
                    _ = _repository.Delete(employee);
                    return true;
                }
                else
                    return false;
            }
            else
                return false;
        }

        public Task<Employee> Find(Expression<Func<Employee, bool>> match)
        {
            return _repository.Find(match);
        }

        public async Task<ICollection<EmployeeViewModel>> GetAll()
        {
            ICollection<EmployeeViewModel> employeeViewModels = new List<EmployeeViewModel>(); 

            ICollection<Employee> employee = await _repository.GetAll();
            foreach(Employee emp in employee)
            {
                EmployeeViewModel employeeViewModel = new()
                {
                    Emp_Name = emp.Emp_Name,
                    Emp_Addr = emp.Emp_Addr,
                    PhoneNO = emp.PhoneNO,
                    DateOfBirth = emp.DateOfBirth,
                };
                employeeViewModels.Add(employeeViewModel);

            }
            if (employee == null)
            {
                return null;
            }
            return employeeViewModels;
        }

        public async Task<EmployeeViewModel> GetById(int id)
        {
            var employee = await _repository.Get(id);
            if (employee == null)
            {
                return null;
            }
            else
            {
                EmployeeViewModel viewModel = new()
                {
                    Emp_Name = employee.Emp_Name,
                    Emp_Addr = employee.Emp_Addr,
                    PhoneNO = employee.PhoneNO,
                    DateOfBirth = employee.DateOfBirth,
            };
                return viewModel;
            }
                
        }

        public async Task<bool> Update(EmployeeUpdateModel EmployeeUpdateModel)
        {
            Employee employee = await _repository.Get(EmployeeUpdateModel.Id);
            if (employee != null)
            {
                employee.Emp_Name = EmployeeUpdateModel.Emp_Name;
                employee.Emp_Addr = EmployeeUpdateModel.Emp_Addr;
                employee.PhoneNO = EmployeeUpdateModel.PhoneNO;
                employee.DateOfBirth = EmployeeUpdateModel.DateOfBirth;
                employee.CreatedDate = employee.CreatedDate;
                employee.UpdatedDate = DateTime.Now;

                var result = await _repository.Update(employee);
                return result;
            }
            else
            {
                return false;
            }
        }
    }
}
