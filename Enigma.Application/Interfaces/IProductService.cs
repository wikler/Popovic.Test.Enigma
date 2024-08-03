using Enigma.Application.DTOs;

namespace Enigma.Application.Interfaces
{
	public interface IProductService
	{
		bool IsProductSuported(string productCode);
		ProductSettingsResponse GetProductSettings(string productCode);
	}
}
