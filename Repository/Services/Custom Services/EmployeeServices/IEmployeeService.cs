using Domain.Model;
using Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services.Custom_Services.EmployeeServices
{
    public interface IEmployeeService
    {
        Task<ICollection<EmployeeViewModel>> GetAll();
        Task<EmployeeViewModel> GetById(int id);
        Task<bool> Insert(EmployeeInsertModel EmployeeInsertModel);
        Task<bool> Update(EmployeeUpdateModel EmployeeUpdateModel);
        Task<bool> Delete(int id);
        Task<Employee> Find(Expression<Func<Employee, bool>> match);
    }
}
