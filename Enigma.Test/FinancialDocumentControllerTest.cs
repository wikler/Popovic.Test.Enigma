using Enigma.Application.DTOs;
using Enigma.Application.Interfaces;
using Enigma.WebApi.Controllers;

using Microsoft.AspNetCore.Mvc;

using Moq;

namespace Enigma.Test
{
	[TestClass]
	public class FinancialDocumentControllerTest
	{
		private Mock<IProductService> _mockProductService;
		private Mock<ITenantService> _mockTenantService;
		private Mock<IClientService> _mockClientService;
		private Mock<IFinancialDocumentService> _mockFinancialDocumentService;
		private FinancialDocumentController _controller;

		[TestInitialize]
		public void Setup()
		{
			_mockProductService = new Mock<IProductService>();
			_mockTenantService = new Mock<ITenantService>();
			_mockClientService = new Mock<IClientService>();
			_mockFinancialDocumentService = new Mock<IFinancialDocumentService>();

			_controller = new FinancialDocumentController(
				 _mockProductService.Object,
				 _mockTenantService.Object,
				 _mockClientService.Object,
				 _mockFinancialDocumentService.Object);
		}

		[TestMethod]
		public void GetFinancialDocument_ProductNotSuported_Returns_403()
		{
			_mockProductService.Setup(s => s.IsProductSuported(It.IsAny<string>())).Returns(false);

			var request = new FinancialDocumentRequest
			{
				Product_code = "1",
				Tenant_id = Guid.NewGuid(),
				Document_id = Guid.NewGuid()
			};

			var result = _controller.GetFinancialDocument(request);

			Assert.IsInstanceOfType(result, typeof(StatusCodeResult));
			var statusCodedResult = result as StatusCodeResult;
			Assert.AreEqual(403, statusCodedResult.StatusCode);

		}

		[TestMethod]
		public void GetFinancialDocument_TenantNotWhitelisted_403()
		{
			_mockTenantService.Setup(s => s.IsTenantWhitelisted(It.IsAny<Guid>())).Returns(false);

			var request = new FinancialDocumentRequest
			{
				Product_code = "1",
				Tenant_id = Guid.NewGuid(),
				Document_id = Guid.NewGuid()
			};

			var result = _controller.GetFinancialDocument(request);

			Assert.IsInstanceOfType(result, typeof(StatusCodeResult));
			var statusCodedResult = result as StatusCodeResult;
			Assert.AreEqual(403, statusCodedResult.StatusCode);
		}
	}
}
