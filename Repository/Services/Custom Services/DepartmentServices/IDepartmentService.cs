using Domain.Model;
using Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services.Custom_Services.DepartmentServices
{
    public interface IDepartmentService
    {
        Task<ICollection<DeparmentViewModel>> GetAll();
        Task<DeparmentViewModel> GetById(int id);
        Task<bool> Add(DeparmentInsertModel DepartmentInsertModel);
        Task<bool> Update(DeparmentUpdateModel DepartmentUpdateModel);
        Task<bool> Delete(int id);
        Task<Department>  Find(Expression<Func<Department, bool>> match);
    }
}
