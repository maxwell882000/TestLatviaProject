using AutoMapper;
using Microsoft.Extensions.Configuration;
using TestProject.Domain.Products;
using TestProject.Domain.Products.Profiles;

namespace ProductTotalTest;

public class ProductTotalTest 
{
    IMapper mapper;

    public ProductTotalTest()
    {
        this.mapper = new ProductProfile(9).GetMapper();
    }

    [Fact]
    public void TotalPriceWithVat()
    {
        // VAT = 9
        var productShow = this.mapper.Map<ProductShow>(new Product()
        {
            Price = 10,
            Quantity = 10,
        });
        Assert.True(productShow.TotalPriceWithVTO == 1000);
    }
}
