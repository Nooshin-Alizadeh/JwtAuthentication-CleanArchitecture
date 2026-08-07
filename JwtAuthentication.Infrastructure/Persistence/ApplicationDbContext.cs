using JwtAuthentication.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace JwtAuthentication.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext//DbContext is EF Core's bridge
    {
        /*
         C# Objects
      |
      |
      ↓
Entity Framework Core
      |
      |
      ↓
SQL Server Tables
         */
        public ApplicationDbContext(
       DbContextOptions<ApplicationDbContext> options)
       : base(options)
        {

        }


        public DbSet<User> Users { get; set; }
    }
}
