﻿using Final_Project.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Core.Models
{
    public class Event
    {
        public int EventId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Event_Start_Date { get; set; }
     
        public int CollegeId { get; set; }
        public College College { get; set; }
    }
}
