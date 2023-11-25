using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ViewModels
{
    public class EmployeeViewModel
    {
        public int Id { get; set; }
        public string Emp_Name { get; set; }
        public string Emp_Addr { get; set; }
        public string PhoneNO { get; set; }
        public DateTime DateOfBirth { get; set; }
    }

    public class EmployeeInsertModel
    {
        public string Emp_Name { get; set; }
        public string Emp_Addr { get; set; }
        public string PhoneNO { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
    public class EmployeeUpdateModel : EmployeeInsertModel
    {
        public int Id { get ; set; }
    }
}
