namespace Enigma.Domain.Models
{
	public class ProductSettings
	{
		public string? ProductCode { get; set; }

		public List<string>? Hashed { get; set; } = default;

		public List<string>? NotChanged { get; set; }
	}
}
