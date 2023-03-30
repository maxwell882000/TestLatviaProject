using System;
using AutoMapper;

namespace TestProject.Domain.Products.Profiles
{
    public class ProductProfile : IProductProfile
    {
        private readonly int VAT;
        public ProductProfile(int VAT)
        {
            this.VAT = VAT;
        }
        public ProductProfile(
                     IConfiguration configuration)
        {
            this.VAT = configuration.GetValue<int>("Product:VAT");
        }
        public IMapper GetMapper()
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Product, ProductShow>()
                  .ForMember(e => e.TotalPriceWithVTO, src =>
                  src.MapFrom(e => e.Price * e.Quantity * (1 + VAT)));
            });
            configuration.CompileMappings();
            return configuration.CreateMapper();
        }
    }
}

