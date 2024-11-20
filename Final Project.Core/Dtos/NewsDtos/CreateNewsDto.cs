using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Project.Core.Dtos.NewsDtos
{
    public class CreateNewsDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime News_Date { get; set; }

        public int CollegeId { get; set; }

    }
}
