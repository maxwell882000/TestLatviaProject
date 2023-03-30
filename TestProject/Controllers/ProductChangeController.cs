using System.Text.Json;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

using Microsoft.AspNetCore.Mvc;
using TestProject.Domain.ProductAudits;
using TestProject.Domain.Products;
// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TestProject.Controllers
{
    [Authorize(Roles = ("ADMIN"))]
    public class ProductChangeController : Controller
    {
        IProductRepository productRepository;
        IProductAuditRepository productAuditRepository;
        public ProductChangeController(IProductRepository productRepository,
        IProductAuditRepository productAuditRepository)
        {
            this.productRepository = productRepository;
            this.productAuditRepository = productAuditRepository;
        }
        public IActionResult Edit(long Id)
        {
            return View(this.productRepository.GetAll().First(e => e.Id == Id));
        }

        private void AddHistory(string New, string Old)
        {
            this.productAuditRepository.Add(new ProductAudit()
            {
                ChangedBy = User.Identity.Name,
                DataOld = Old,
                DateNew = New
            });
        }

        [HttpPost]
        public IActionResult Edit(Product Product)
        {
            var data = this.productRepository.GetById(Product.Id);
            var DataOld = JsonSerializer.Serialize(data);
            this.productRepository.changeState(data, EntityState.Detached);
            this.productRepository.Update(Product);
            this.AddHistory(JsonSerializer.Serialize(Product), DataOld);
            this.productRepository.Commit();
            return RedirectToAction("Edit");
        }

        [HttpPost]
        public IActionResult Create(Product Product)
        {
            this.productRepository.Add(Product);
            this.AddHistory(JsonSerializer.Serialize(Product), "");
            this.productRepository.Commit();
            return RedirectToAction("Create");
        }

        public IActionResult Create()
        {
            return View();
        }
    }
}

