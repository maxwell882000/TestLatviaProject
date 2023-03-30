using System;
using TestProject.Domain.Products;

namespace TestProject.Seeds
{
    public class ProductSeed : IProductSeed
    {
        IProductRepository product;

        public ProductSeed(IProductRepository product)
        {
            this.product = product;
        }

        public async Task seed()
        {
            this.product.AddRange(new List<Product>() {
                new Product() {
                    Title = "HDD 1TB",
                    Quantity = 55,
                    Price = 74.09
                },
                   new Product() {
                    Title = "HDD SSD 512GB",
                    Quantity = 102,
                    Price = 190.99
                },
                      new Product() {
                    Title = "RAM DDR4 16GB",
                    Quantity = 47,
                    Price = 80.32
                },
            });
            this.product.Commit();
        }
    }
}

