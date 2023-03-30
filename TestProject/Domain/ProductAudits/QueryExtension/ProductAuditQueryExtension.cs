using LinqKit;

namespace TestProject.Domain.ProductAudits
{
    public static class ProductAuditQueryExtension
    {
        public static IQueryable<ProductAudit> Filter(this IQueryable<ProductAudit> query, DateTime? from = null, DateTime? to = null)
        {
            var predicate = PredicateBuilder.New<ProductAudit>();
            if (from != null)
            {
                predicate.And(e => e.CreatedAt >= from);
            }
            if (to != null)
            {
                predicate.And(e => e.CreatedAt <= to);
            }
            return query.Where(predicate);
        }
    }
}

