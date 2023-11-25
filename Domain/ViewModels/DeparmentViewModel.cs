using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ViewModels
{
    public class DeparmentViewModel
    {
        public int Id { get; set; }
        public string Dep_Name { get; set; }
    }

    public class DeparmentInsertModel
    {
        public string Dep_Name { get; set; }
    }

    public class DeparmentUpdateModel : DeparmentInsertModel
    {
        public int Id { get; set; }
    }
}
