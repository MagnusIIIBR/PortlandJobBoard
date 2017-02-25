using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobBoardMVC.Models
{
    public class Company
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string PhoneNumber { get; set; }
        public string Website { get; set; }
    }
}
