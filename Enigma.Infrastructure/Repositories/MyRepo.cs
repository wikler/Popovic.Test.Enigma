using Enigma.Domain.Models;
using Enigma.Infrastructure.Context;

namespace Enigma.Infrastructure.Repositories;

public class MyRepo : GenericRepository<Product>
{
	public MyRepo(EnigmaDbContext context) : base(context)
	{
	}
}