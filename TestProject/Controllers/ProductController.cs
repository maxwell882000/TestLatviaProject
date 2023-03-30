using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TestProject.Domain.Products;
using TestProject.Domain.Products.Profiles;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TestProject.Controllers
{
    [Authorize(Roles = ("ADMIN, USER"))]
    public class ProductController : Controller
    {
        IProductRepository repository;
        IMapper mapper;
        public ProductController(IProductRepository repository,
         IProductProfile profile)
        {
            this.repository = repository;
            this.mapper = profile.GetMapper();
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            var list = this.repository.GetAll().ToList();
            return View(this.mapper.Map<List<ProductShow>>(list.OrderBy(e => e.Id)));
        }

    }
}

