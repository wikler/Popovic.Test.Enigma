using Enigma.Application.DTOs;
using Enigma.Application.Interfaces;
using Enigma.Domain.Models;

namespace Enigma.Application.Services
{
	public class ClientService : IClientService
	{
		private readonly ITransactionService _transactionService;

		public ClientService(ITransactionService transactionService)
		{
			_transactionService = transactionService;
		}

		public ClientInfoResponse GetClientInfo(Guid tenantId, Guid documentId)
		{
			Client client = _clients.Where(w => w.TenantId == tenantId && w.FinancialDocumentId == documentId).Single();

			ClientInfoResponse clientInfoResponse = new ClientInfoResponse();
			clientInfoResponse.Id = client.Id;
			clientInfoResponse.VAT = client.VAT;

			return clientInfoResponse;
		}

		public bool IsClientWhitelisted(Guid tenantId, Guid clientId)
		{
			return _clients.Where(w => w.TenantId == tenantId && w.Id == clientId).Single().IsWhitelisted;
		}

		public CompanyResponse GetCompanyInfo(string? clientVAT)
		{
			Company company = _companies.Where(w => w.VAT == clientVAT).Single();

			CompanyResponse companyInfoResponse = new CompanyResponse();
			companyInfoResponse.Registration_number = company.RegistrationNumber;
			companyInfoResponse.Company_type = company.CompanyType;
			return companyInfoResponse;
		}

		public ClientResponse GetClient(Guid clientId)
		{
			Client client = _clients.Where(w => w.Id == clientId).Single();

			ClientResponse clientResponse = new ClientResponse();

			clientResponse.Account_number = client.AccountNumber;
			clientResponse.Balance = client.Balance;
			clientResponse.Currency = client.Currency;
			clientResponse.Transactions = _transactionService.GetClientTransactions(clientId);

			Company company = _companies.Where(w => w.VAT == client.VAT).Single();
			CompanyResponse companyResponse = new CompanyResponse();
			companyResponse.Registration_number = company.RegistrationNumber;
			companyResponse.Company_type = company.CompanyType;

			clientResponse.Company = companyResponse;

			return clientResponse;
		}

		private readonly List<Client> _clients = new List<Client>()
		  {
				new ()
				{
					 Id = new Guid("0f8fad5b-d9cb-469f-a165-70867728940e"),
					 Name = "ClientA",
					 AccountNumber = "985-569896-88",
					 Balance = 4213.15m,
					 Currency = "EUR",
					 VAT = "VAT20123",
					 IsWhitelisted = true,
					 FinancialDocumentId  = new Guid("0f8fad5b-d9cb-469f-a165-70867728933e"),
					 TenantId = new Guid("0f8fad5b-d9cb-469f-a165-70867728923e")
				},
				new ()
				{
					 Id = new Guid("0f8fad5b-d9cb-469f-a165-70867728941e"),
					 Name = "ClientB",
					 AccountNumber = "710-485336-41",
					 Balance = 5990.92m,
					 Currency = "EUR",
					 VAT = "VAT21899",
					 IsWhitelisted = true,
					 FinancialDocumentId = new Guid("0f8fad5b-d9cb-469f-a165-70867728934e"),
					 TenantId = new Guid("0f8fad5b-d9cb-469f-a165-70867728924e")
				},
				new ()
				{
					 Id = new Guid("0f8fad5b-d9cb-469f-a165-70867728942e"),
					 Name = "ClientC",
					 AccountNumber = "566-133557-99",
					 Balance = 1205.41m,
					 Currency = "EUR",
					 VAT = "VAT22881",
					 IsWhitelisted = false,
					 FinancialDocumentId = new Guid("0f8fad5b-d9cb-469f-a165-70867728935e"),
					 TenantId = new Guid("0f8fad5b-d9cb-469f-a165-70867728924e")
				}
		  };

		private readonly List<Company> _companies = new List<Company>()
		  {
				new()
				{
					 Id = new Guid("0f8fad5b-d9cb-469f-a165-70867728955e"),
					 Name = "CompanyA",
					 RegistrationNumber = "895472835631218",
					 CompanyType = "medium", VAT = "VAT20123"
				},
				new()
				{
					 Id = new Guid("0f8fad5b-d9cb-469f-a165-70867728956e"),
					 Name = "CompanyB",
					 RegistrationNumber = "895472835631219",
					 CompanyType = "large",
					 VAT = "VAT21899"
				},
				new()
				{
					 Id = new Guid("0f8fad5b-d9cb-469f-a165-70867728957e"),
					 Name = "CompanyC",
					 RegistrationNumber = "895472835631220",
					 CompanyType = "small",
					 VAT = "VAT22881"
				}
		  };
	}
}
