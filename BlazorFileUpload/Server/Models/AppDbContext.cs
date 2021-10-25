﻿
using BlazorFileUpload.Shared;
using Microsoft.EntityFrameworkCore;

namespace BlazorFileUpload.Server.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {

        }

        public DbSet<Employee> Employees { get; set; }
  

     
    }
}
