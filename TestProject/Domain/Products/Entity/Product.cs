using System;
using TestProject.Domain.Common;
using System.Configuration;
using AutoMapper;

namespace TestProject.Domain.Products
{


    public class Product : IEntity
    {
        public long Id { get; set; }

        public string Title { get; set; }

        public int Quantity { get; set; }

        public double Price { get; set; }

        public Product()
        {
        }
    }
}

