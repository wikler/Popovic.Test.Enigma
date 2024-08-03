using System.Security.Cryptography;
using System.Text;

using Enigma.Application.Interfaces;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Enigma.Application.Services
{
	public class AnonymizeDataService : IAnonymizeDataService
	{
		private readonly IProductService _productService;

		public AnonymizeDataService(IProductService productService)
		{
			_productService = productService;
		}

		public string AnonymizeData(string jsonData, string? productCode)
		{
			JObject? jsonObject = JsonConvert.DeserializeObject<JObject>(jsonData);

			if (jsonObject is null)
			{
				return "";
			}

			if (productCode is null)
			{
				return "";
			}

			Anonymize(jsonObject, productCode);
			return JsonConvert.SerializeObject(jsonObject, Formatting.Indented);
		}

		private void Anonymize(JObject jsonObj, string productCode)
		{
			foreach (var property in jsonObj.Properties())
			{
				Validate(productCode, property);
			}
		}

		private void Validate(string productCode, JProperty property)
		{
			if (property.Value.Type == JTokenType.Object)
			{
				Anonymize((JObject)property.Value, productCode);
			}
			else if (property.Value.Type == JTokenType.Array)
			{
				foreach (var item in (JArray)property.Value)
				{
					Anonymize((JObject)item, productCode);
				}
			}
			else
			{
				var pc = _productService.GetProductSettings(productCode);
				List<string> propertiesToHash = pc.Hashed;
				List<string> propertiesNotToChange = pc.NotChanged;
				var fieldName = property.Name;
				if (propertiesToHash.Contains(fieldName))
				{
					property.Value = HashValue(property.Value.ToString());
				}
				if (!propertiesNotToChange.Contains(fieldName) && !propertiesToHash.Contains(fieldName))
				{
					property.Value = "#####";
				}
			}
		}

		private static string HashValue(string value)
		{
			using (var sha256 = SHA256.Create())
			{
				var bytes = Encoding.UTF8.GetBytes(value);
				var hash = sha256.ComputeHash(bytes);
				return BitConverter.ToString(hash).Replace("-", "").ToLower();
			}
		}
	}
}
