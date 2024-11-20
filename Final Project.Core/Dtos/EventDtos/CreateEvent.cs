using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Project.Core.Dtos.EventDtos
{
    public class CreateEvent
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Event_Start_Date { get; set; }

        public int CollegeId { get; set; }
    }
}
