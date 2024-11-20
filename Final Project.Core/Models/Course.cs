using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Final_Project.Core.Models
{
    public class Course
    {
        public int CourseId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public int DepartmentId { get; set; }
        [JsonIgnore]
        public Department Department { get; set; }
    }
}
