using System;
using TestProject.DatabaseContexts;
using TestProject.Domain.Common;
using TestProject.Domain.Products;

namespace TestProject.Domain.ProductAudits
{
    public class ProductAuditRepository : GenericRepository<PostgresContext, ProductAudit>, IProductAuditRepository
    {
        public ProductAuditRepository(PostgresContext context, ILogger<GenericRepository<PostgresContext, ProductAudit>> logger) : base(context, logger)
        {
        }


    }
}

