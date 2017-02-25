using JobBoardMVC.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


namespace JobBoardMVC.Models
{
    public class SeedData
    {
        public static void InitializeDb(string jsonData, IServiceProvider serviceProvider)
        {
            using (var context = new JobBoardMVCDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<JobBoardMVCDbContext>>()))
            {
                if (context.Job.Any())
                {
                    return;   // DB has been seeded
                }

                List<Job> jobs = JsonConvert.DeserializeObject<List<Job>>(jsonData);

                context.AddRange(jobs);
                context.SaveChanges();
            }
        }
    }
}
