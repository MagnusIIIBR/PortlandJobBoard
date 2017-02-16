using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TechAcademyJobBoard.Models;
using TechAcademyJobBoard.Models.JsonJobModel;
using TechAcademyJobBoard.Models.CompanyModel;
using TechAcademyJobBoard.Models.PlaceModel;
using TechAcademyJobBoard.Models.JobModel;
using TechAcademyJobBoard.Models.UserModel;

namespace TechAcademyJobBoard.Data
{
    public class TAJobBoardDbContext : IdentityDbContext<ApplicationUser>
    {
        public TAJobBoardDbContext(DbContextOptions<TAJobBoardDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }

        public DbSet<JsonJob> JsonJob { get; set; }

        public DbSet<Company> Company { get; set; }

        public DbSet<Place> Place { get; set; }

        public DbSet<Job> Job { get; set; }

        public DbSet<User> User { get; set; }
    }
}
