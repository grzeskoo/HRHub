using System;
using System.Collections.Generic;
using System.Text;
using HRHub_API.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HRHub_API.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<reg_eu_Sector> reg_eu_Sector { get; set; }
        public DbSet<reg_eu_Termination> reg_eu_Termination { get; set; }

         

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
