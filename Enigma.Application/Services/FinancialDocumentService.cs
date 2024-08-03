using Enigma.Application.DTOs;
using Enigma.Application.Interfaces;
using Enigma.Domain.Models;

using Newtonsoft.Json;

namespace Enigma.Application.Services
{
	public class FinancialDocumentService : IFinancialDocumentService
	{
		private readonly IClientService _clientService;
		private readonly IAnonymizeDataService _anonymizeDataService;

		public FinancialDocumentService(IClientService clientService, IAnonymizeDataService anonymizeDataService)
		{
			_clientService = clientService;
			_anonymizeDataService = anonymizeDataService;
		}

		public string GetFinancialDocument(Guid tenantId, Guid documentId, string productCode)
		{
			Guid clientId = _financialDocuments.Where(w => w.TenantId == tenantId && w.Id == documentId).Single().ClientId;
			ClientResponse clientResponse = _clientService.GetClient(clientId);
			string jsonData = JsonConvert.SerializeObject(clientResponse, Formatting.Indented);
			string response = _anonymizeDataService.AnonymizeData(jsonData, productCode);
			return response;
		}

		private readonly List<FinancialDocument> _financialDocuments = new List<FinancialDocument>()
		{
			new()
			{
					Id = new Guid("0f8fad5b-d9cb-469f-a165-70867728933e"),
					TenantId = new Guid("0f8fad5b-d9cb-469f-a165-70867728923e"),
					ClientId = new Guid("0f8fad5b-d9cb-469f-a165-70867728940e"),
			},
			new()
			{
					Id = new Guid("0f8fad5b-d9cb-469f-a165-70867728934e"),
					TenantId = new Guid("0f8fad5b-d9cb-469f-a165-70867728924e"),
					ClientId = new Guid("0f8fad5b-d9cb-469f-a165-70867728941e")
			},
			new()
			{
					Id = new Guid("0f8fad5b-d9cb-469f-a165-70867728935e"),
					TenantId = new Guid("0f8fad5b-d9cb-469f-a165-70867728924e"),
					ClientId = new Guid("0f8fad5b-d9cb-469f-a165-70867728942e")
			},
		};
	}
}
