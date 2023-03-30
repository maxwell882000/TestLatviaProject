using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TestProject.Domain.ProductAudits;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TestProject.Controllers
{
    [Authorize(Roles = ("ADMIN"))]
    public class ProductAuditController : ControllerBase
    {
        IProductAuditRepository productAudit;
        public ProductAuditController(IProductAuditRepository productAudit)
        {
            this.productAudit = productAudit;
        }
        [HttpGet]
        public IActionResult GetListOfChanges(DateTime? from, DateTime? to)
        {
            return Ok(this.productAudit.GetAll().Filter(from: from, to: to));
        }
    }
}

