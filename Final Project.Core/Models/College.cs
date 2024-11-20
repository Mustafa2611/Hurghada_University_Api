using FinalProject.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Final_Project.Core.Models
{
    public class College
    {
        public int CollegeId { get; set; }

        public string College_Name {  get; set; }

        public string College_Description {  get; set; }

        public string Contact_Information {  get; set; }

        public ICollection<Department>? Departments { get; set; } = new List<Department>();

        [JsonIgnore]
        public ICollection<Event>? Events {  get; set; } = new List<Event>();
        [JsonIgnore]
        public ICollection<News>? News { get; set; } = new List<News>();
    }
}
