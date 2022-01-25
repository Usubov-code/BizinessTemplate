using BizinessTemplate.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BizinessTemplate.Data
{
    public class AppDbContext:IdentityDbContext
    {

        public AppDbContext(DbContextOptions options):base(options)
        {

        }


        public DbSet<Service> Services { get; set; }
        public DbSet<CustomUser> CustomUsers { get; set; }
    }
}
