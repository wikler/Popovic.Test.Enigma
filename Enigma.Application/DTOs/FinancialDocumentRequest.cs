using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enigma.Application.DTOs
{
    public class FinancialDocumentRequest
    {
        public string? Product_code { get; set; }

        public Guid Tenant_id { get; set; }

        public Guid Document_id { get; set; }
    }
}
