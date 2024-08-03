using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enigma.Domain.Models
{
    public class FinancialDocument
    {
        public Guid Id { get; set; }

        public Guid TenantId { get; set; }

        public Guid ClientId { get; set; }

        public virtual Tenant? Tenant { get; set; }

        public virtual Client? Client { get; set; }  
    }
}
