using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enigma.Application.Interfaces
{
    public interface IFinancialDocumentService
    {
        string GetFinancialDocument(Guid tenantId, Guid documentId, string productCode);

    }
}
