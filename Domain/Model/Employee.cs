using Domain.BaseEntityClass;
using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class Employee : BaseEntity
    {
        public string Emp_Name { get; set; }
        public string Emp_Addr { get; set;}
        public string PhoneNO { get; set; }
        public DateTime DateOfBirth { get; set; }

        public ICollection<Sallary> Sallaries { get; set;}
    }
}
