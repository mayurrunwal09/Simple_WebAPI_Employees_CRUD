using Domain.BaseEntityClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class Department : BaseEntity
    {
        public string Dep_Name { get; set; }
        public ICollection<Sallary> Sallaries { get; set; }
    }
}
