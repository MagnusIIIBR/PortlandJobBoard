using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobBoardMVC.Models
{
    public class JobLocationViewModel
    {
        public List<Job> jobs;
        public SelectList locations;
        public string jobLocation { get; set; }
    }
}
