using Enigma.Application.Interfaces;
using Enigma.Application.Services;

namespace Enigma.WebApi
{
	public class Program
	{
		public static void Main(string[] args)
		{
			// IConfiguration configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();



			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.

			builder.Services.AddControllers();

			// builder.Services.RegisterRepositoryDependencies();

			builder.Services.AddScoped<IProductService, ProductService>();
			builder.Services.AddScoped<ITenantService, TenantService>();
			builder.Services.AddScoped<IClientService, ClientService>();

			builder.Services.AddScoped<ITransactionService, TransactionService>();
			builder.Services.AddScoped<IFinancialDocumentService, FinancialDocumentService>();
			builder.Services.AddScoped<IAnonymizeDataService, AnonymizeDataService>();


			// ConfigurationHelper.Initialize(configuration);
			// builder.Services.AddAuthentication().AddCookie();

			// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();

			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			app.UseHttpsRedirection();

			app.MapControllers();

			app.Run();
		}
	}
}
