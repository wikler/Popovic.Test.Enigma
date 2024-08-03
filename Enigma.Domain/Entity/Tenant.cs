using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enigma.Domain.Models
{
    public class Tenant
    {
        public Tenant()
        {
            FinancialDocuments = new List<FinancialDocument>();
        }

        public Guid Id { get; set; }

        public string? Name { get; set; }

        public bool IsWhitelisted { get; set; }

        public virtual List<FinancialDocument> FinancialDocuments { get; set;}
    }
}
