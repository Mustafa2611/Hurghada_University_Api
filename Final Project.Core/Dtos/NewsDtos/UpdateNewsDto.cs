using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Project.Core.Dtos.NewsDtos
{
    public class UpdateNewsDto
    {
        public int NewsId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime News_Date { get; set; }

        public int CollegeId { get; set; }

    }
}
