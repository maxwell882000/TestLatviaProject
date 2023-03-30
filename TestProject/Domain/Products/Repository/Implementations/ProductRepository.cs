using System;
using TestProject.DatabaseContexts;
using TestProject.Domain.Common;

namespace TestProject.Domain.Products
{
    public class ProductRepository : GenericRepository<PostgresContext, Product>, IProductRepository
    {
        public ProductRepository(PostgresContext context, ILogger<GenericRepository<PostgresContext, Product>> logger) : base(context, logger)
        {
        }
    }
}

