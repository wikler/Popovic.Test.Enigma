using System.Linq.Expressions;

using Enigma.Domain.Interfaces;
using Enigma.Infrastructure.Context;

namespace Enigma.Infrastructure.Repositories;

public abstract class GenericRepository<T> : IGenericRepository<T> where T : class
{
	private readonly EnigmaDbContext _context;

	public GenericRepository(EnigmaDbContext context)
	{
		_context = context;
	}

	public IEnumerable<T> Find(Expression<Func<T, bool>> expression)
	{
		return _context.Set<T>().Where(expression);
	}

	public List<T> GetAll()
	{
		return _context.Set<T>().ToList();
	}

	public T? GetById(Guid id)
	{
		return _context.Set<T>().Find(id);
	}
}
