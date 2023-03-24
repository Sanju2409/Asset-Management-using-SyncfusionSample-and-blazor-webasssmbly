using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SyncfusionSample.Data;
using Volo.Abp.Application.Services;

namespace SyncfusionSample.Products
{
	public class ProductAppService : ApplicationService, IProductAppService
	{
		private readonly SampleDataService _sampleBookDataService;

		public ProductAppService(SampleDataService sampleBookDataService)
		{
			_sampleBookDataService = sampleBookDataService;
		}

		public async Task<List<ProductDto>> GetListAsync()
		{
			return await Task.Run(() => _sampleBookDataService.GetProducts());
		}

		public async Task<ProductDto> GetAsync(Guid id)
		{
			var book = await Task.Run(() => _sampleBookDataService.GetProduct(id));

			return book;
		}

		public async Task<ProductDto> CreateAsync(CreateUpdateProductDto input)
		{
			var newBook = new ProductDto
			{
				Id = GuidGenerator.Create(),
				Name = input.Name,
				Description= input.Description,
				Price = input.Price
			};

			newBook = await Task.Run(() => _sampleBookDataService.CreateProduct(newBook));

			return newBook;
		}

		public async Task<ProductDto> UpdateAsync(Guid id, CreateUpdateProductDto input)
		{
			var book = await Task.Run(() => _sampleBookDataService.GetProduct(id));

			book.Name = input.Name;
			book.Description = input.Description;
			book.Price = input.Price;
			

			book = await Task.Run(() => _sampleBookDataService.UpdateProduct(book));

			return book;
		}

		public async Task DeleteAsync(Guid id)
		{
			var book = await Task.Run(() => _sampleBookDataService.GetProduct(id));

			await Task.Run(() => _sampleBookDataService.DeleteProduct(book));
		}
	}
}