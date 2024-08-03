using Enigma.Application.DTOs;
using Enigma.Application.Interfaces;
using Enigma.Domain.Models;

namespace Enigma.Application.Services
{
	public class ProductService : IProductService
	{
		public bool IsProductSuported(string productCode)
		{
			return _products.Where(w => w.Code == productCode).Single().IsSuported; //
		}

		public ProductSettingsResponse GetProductSettings(string productCode)
		{
			ProductSettings productSettings = _productSettings.Where(w => w.ProductCode == productCode).Single();

			ProductSettingsResponse productSettingsResponse = new ProductSettingsResponse();
			productSettingsResponse.ProductCode = productSettings.ProductCode;
			productSettingsResponse.Hashed = productSettings.Hashed;
			productSettingsResponse.NotChanged = productSettings.NotChanged;

			return productSettingsResponse;
		}

		private readonly List<Product> _products = new List<Product>()
		  {
				new() { Id = new Guid("0f8fad5b-d9cb-469f-a165-70867728910e"), Code = "500", Name = "ProductA", IsSuported = true},
				new() { Id = new Guid("0f8fad5b-d9cb-469f-a165-70867728911e"), Code = "600", Name = "ProductB", IsSuported = true},
				new() { Id = new Guid("0f8fad5b-d9cb-469f-a165-70867728912e"), Code = "700", Name = "ProductC", IsSuported = false}
		  };

		private readonly List<ProductSettings> _productSettings = new List<ProductSettings>()
		  {
				new() { ProductCode = "500", Hashed = ["Account_number"], NotChanged = [
					 "Account_number",
					 "Balance",
					 "Currency",
					 "Amount",
					 "Date",
					 "Category",
					 "Registration_number",
					 "Company_type"]},
				new() { ProductCode = "600", Hashed = ["Balance"], NotChanged = [
					 "Transaction_id",
					 "Amount"]}
		  };
	}
}
