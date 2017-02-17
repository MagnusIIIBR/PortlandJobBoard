using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TechAcademyJobBoard.Models
{
    public class Job
    {
        public int ID { get; set; }
        public string Company { get; set; }
        public string JobTitle { get; set; }
        public string Location { get; set; }
        public bool FullTime { get; set; }
        public bool PartTime { get; set; }
        public bool Contract { get; set; }
    }
}
