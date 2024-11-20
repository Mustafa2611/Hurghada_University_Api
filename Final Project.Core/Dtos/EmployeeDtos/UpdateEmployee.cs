using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Project.Core.Dtos.EmployeeDots
{

    public class EmployeeUpdateDto : EmployeeCreateDto
    {
        public int EmployeeId { get; set; }
        public int DepartmentId { get; set; }
    }
}
