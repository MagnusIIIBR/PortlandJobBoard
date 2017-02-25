﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using JobBoardMVC.Models;

namespace JobBoardMVC.Data
{
    public class JobBoardMVCDbContext : IdentityDbContext<ApplicationUser>
    {
        public JobBoardMVCDbContext(DbContextOptions<JobBoardMVCDbContext> options)
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

        public DbSet<User> User { get; set; }

        public DbSet<Place> Place { get; set; }

        public DbSet<Job> Job { get; set; }

        public DbSet<Company> Company { get; set; }
    }
}
