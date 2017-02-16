using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechAcademyJobBoard.Data;
using TechAcademyJobBoard.Models.JsonJobObjectModel;
//using TechAcademyJobBoard.Models.JsonJobModel;

namespace TechAcademyJobBoard.Models.SeedDataModel
{
    public class SeedData
    {
        // also calling seed data in the configure method of startup.cs

        public static void InitializeDb(string jsonData, IServiceProvider serviceProvider)
        {
            using (var context = new TAJobBoardDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<TAJobBoardDbContext>>()))
            {
                
                List<JsonJobObject> jobs = JsonConvert.DeserializeObject<List<JsonJobObject>>(jsonData);

                context.AddRange(jobs);
                context.SaveChanges();

            }
        }
    }
}
