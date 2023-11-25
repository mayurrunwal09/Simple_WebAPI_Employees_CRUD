using Domain.BaseEntityClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class Sallary : BaseEntity
    {
        public string Sal { get; set; }
        public int Emp_ID { get; set; }
        public Employee Employee { get; set; }
        public int Dep_ID { get; set; }       
        public Department Department { get; set; }
    }
}
