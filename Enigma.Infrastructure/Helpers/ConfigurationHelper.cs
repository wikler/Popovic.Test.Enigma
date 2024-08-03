using Microsoft.Extensions.Configuration;

namespace Enigma.Infrastructure.Helpers
{
	public static class ConfigurationHelper
	{
		public static IConfiguration config = default!;
		public static void Initialize(IConfiguration configuration)
		{
			config = configuration;
		}
	}
}
