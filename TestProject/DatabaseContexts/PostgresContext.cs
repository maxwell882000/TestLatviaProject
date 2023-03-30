using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TestProject.Domain.ProductAudits;
using TestProject.Domain.Products;
using TestProject.Domain.Users;

namespace TestProject.DatabaseContexts
{
    public class PostgresContext : IdentityDbContext<User, Role, string>
    {

        public DbSet<Product> Products { get; set; }

        public DbSet<ProductAudit> ProductAudits { get; set; }


        public PostgresContext(DbContextOptions<PostgresContext> options)
          : base(options)
        {
        }
    }
}

