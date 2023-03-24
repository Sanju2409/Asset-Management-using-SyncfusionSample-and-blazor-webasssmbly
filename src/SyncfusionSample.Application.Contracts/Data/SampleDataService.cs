using System;
using System.Collections.Generic;
using System.Linq;
using SyncfusionSample.Products;
using Volo.Abp.DependencyInjection;

namespace SyncfusionSample.Data
{
	public class SampleDataService : ISingletonDependency
	{
		private List<ProductDto> DataSource = new List<ProductDto>
		{
			new ProductDto
			{
				Id = Guid.NewGuid(),
				Name = "Leonardo Da Vinci",
				Description="cgv b",
				Price = 33.99F
			},
			new ProductDto
			{
				Id = Guid.NewGuid(),
				Name = "Da Vinci",
				Description="cgvdd",
				Price = 33.99F
			},
			
		};

		public List<ProductDto> GetProducts()
		{
			return DataSource;
		}

		public ProductDto GetProduct(Guid id)
		{
			return DataSource.SingleOrDefault(x => x.Id == id);
		}

		public ProductDto CreateProduct(ProductDto input)
		{
			DataSource.Add(new ProductDto
			{
				Id = input.Id,
				Name = input.Name,
				Description = input.Description,
				Price = input.Price,
				
			});

			return input;
		}

		public ProductDto UpdateProduct(ProductDto input)
		{
			DeleteProduct(input);
			CreateProduct(input);

			return input;
		}

		public void DeleteProduct(ProductDto input)
		{
			DataSource.Remove(input);
		}
	}
}