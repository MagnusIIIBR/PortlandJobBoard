using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobBoardMVC.Models
{
    public class User
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Languages { get; set; }
        public string Experience { get; set; }
    }
}
