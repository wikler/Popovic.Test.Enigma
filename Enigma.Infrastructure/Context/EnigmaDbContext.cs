using Enigma.Domain.Models;

using Microsoft.EntityFrameworkCore;

namespace Enigma.Infrastructure.Context
{
	public class EnigmaDbContext : DbContext
	{
		public EnigmaDbContext(DbContextOptions<EnigmaDbContext> options) : base(options) { }

		public DbSet<Product> Product { get; set; }
		public DbSet<Tenant> Tenant { get; set; }
	}
}
