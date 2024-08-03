namespace Enigma.WebApi.Configuration;


public static class RegisterDependenciesExtensions
{
	//public static IServiceCollection RegisterRepositoryDependencies(this IServiceCollection seviceCollection)
	//{
	//	var itype = typeof(IGenericRepository<>);

	//	var assembly = typeof(IInfrastructureMarker).Assembly;

	//	var types = assembly
	//		.GetTypes()
	//		.Where(p => itype.IsAssignableFrom(p));

	//	if (types is null)
	//	{
	//		return seviceCollection;
	//	}

	//	object[] parameters = new object[] { services };

	//	foreach (var type in types)
	//	{
	//		type.GetMethod(nameof(IDependencyInjectionSelfRegistration.Register), BindingFlags.Static | BindingFlags.Public)!.Invoke(null, parameters);
	//	}


	//	return seviceCollection;
	//}
}
