using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using vezeeta_core.Data.Models;

namespace vezeeta_core.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext()
        {
        }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }
        public DbSet<booking> bookings { get; set; }
        public DbSet<patient>patients { get; set; }
        public DbSet<doctor> doctors { get; set; }
        public DbSet<appointment> Appointments { get; set; }
        public DbSet<admin_functions> admin_function { get; set; }
        public DbSet<DiscoundCodeCoupon> DiscoundCodeCoupons { get; set; }


    }
  
}
