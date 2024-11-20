using Final_Project.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Project.Core.Dtos.DepartmentDtos
{
    public class AddEmplyeeToDepartment
    {
        public int DepartmentId { get; set; }

        public int EmployeeId { get; set; }
    }
}
