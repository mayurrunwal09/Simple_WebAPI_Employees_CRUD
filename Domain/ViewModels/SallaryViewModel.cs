using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ViewModels
{
    public class SallaryViewModel
    {
        public int Id { get; set; }
        public string Sallary { get; set; }
    }

    public class SallaryInsertModel
    {
        public string Sallary { get; set; }
    }
    public class SallaryUpdateModel : SallaryInsertModel
    {
       public int Id { get; set; }
    }
}
