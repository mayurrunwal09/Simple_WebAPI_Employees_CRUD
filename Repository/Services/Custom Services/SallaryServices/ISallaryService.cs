using Domain.Model;
using Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services.Custom_Services.SallaryServices
{
    public interface ISallaryService
    {
        Task<ICollection<SallaryViewModel>> GetAll();
        Task<SallaryViewModel> GetById(int id);
        Task<bool> Add(SallaryInsertModel SallaryInsertModel);
        Task<bool> Update(SallaryUpdateModel SallaryUpdateModel);
        Task<bool> Delete(int id);
        Task<Sallary>  Find(Expression<Func<Sallary, bool>> match);
    }
}
