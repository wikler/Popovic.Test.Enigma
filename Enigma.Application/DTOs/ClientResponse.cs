namespace Enigma.Application.DTOs
{
	public class ClientResponse
	{
		public ClientResponse()
		{
			Transactions = new List<TransactionResponse>();
		}

		public string? Account_number { get; set; }

		public decimal Balance { get; set; }

		public string? Currency { get; set; }

		public virtual List<TransactionResponse>? Transactions { get; set; }

		public virtual CompanyResponse Company { get; set; }

	}
}
