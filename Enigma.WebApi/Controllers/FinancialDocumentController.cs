using Enigma.Application.DTOs;
using Enigma.Application.Interfaces;

using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Enigma.WebApi.Controllers
{
	[Route("api/[controller]")]

	[ApiController]
	public class FinancialDocumentController : ControllerBase
	{
		private readonly IProductService _productService;
		private readonly ITenantService _tenantService;
		private readonly IClientService _clientService;
		private readonly IFinancialDocumentService _financialDocumentService;

		public FinancialDocumentController(
			 IProductService productService,
			 ITenantService tenantService,
			 IClientService clientService,
			 IFinancialDocumentService financialDocumentService)
		{
			_productService = productService;
			_tenantService = tenantService;
			_clientService = clientService;
			_financialDocumentService = financialDocumentService;
		}

		// POST api/<FinancialDocumentController>
		[HttpPost("GetFinancialDocument")]
		[ProducesResponseType(StatusCodes.Status403Forbidden)]
		public async Task<ActionResult<string>> GetFinancialDocument([FromBody] FinancialDocumentRequest request)
		{
			if (!_productService.IsProductSuported(request.Product_code))
			{
				return Forbid();
			}

			if (!_tenantService.IsTenantWhitelisted(request.Tenant_id))
			{
				return Forbid();
			}

			ClientInfoResponse clientResponse = _clientService.GetClientInfo(request.Tenant_id, request.Document_id);
			if (clientResponse == null || !_clientService.IsClientWhitelisted(request.Tenant_id, clientResponse.Id))
			{
				return Forbid();
			}

			CompanyResponse companyResponse = _clientService.GetCompanyInfo(clientResponse.VAT);
			if (companyResponse.Company_type == Infrastructure.Enums.CompanyType.small.ToString())
			{
				return Forbid();
			}

			string response = _financialDocumentService.GetFinancialDocument(request.Tenant_id, request.Document_id, request.Product_code);

			return Ok(response);
		}
	}
}
