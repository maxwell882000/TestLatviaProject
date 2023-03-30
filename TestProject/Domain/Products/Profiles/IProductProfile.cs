using System;
using AutoMapper;

namespace TestProject.Domain.Products.Profiles
{
	public interface IProductProfile
	{
		public IMapper GetMapper();
	}
}

