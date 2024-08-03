using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Enigma.Domain.Models
{
    public class Client
    {
        public Client()
        {
            Transactions = new List<Transaction>();
        }

        public Guid Id { get; set; }

        public string? Name { get; set; }

        public string? AccountNumber { get; set; }

        public decimal Balance { get; set; }

        public string? Currency { get; set; }

        public string? VAT { get; set; }

        public bool IsWhitelisted { get; set; }

        public Guid FinancialDocumentId { get; set; }

        public Guid TenantId { get; set; }

        public virtual FinancialDocument? FinancialDocument { get; set; }

        public virtual List<Transaction> Transactions { get; set; }
    }
}
