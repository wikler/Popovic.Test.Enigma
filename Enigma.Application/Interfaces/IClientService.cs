using Enigma.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enigma.Application.Interfaces
{
    public interface IClientService
    {
        ClientInfoResponse GetClientInfo(Guid tenantId, Guid documentId);
        bool IsClientWhitelisted(Guid tenantId, Guid clientId);
        CompanyResponse GetCompanyInfo(string? clientVAT);
        ClientResponse GetClient(Guid clientId);
    }
}
