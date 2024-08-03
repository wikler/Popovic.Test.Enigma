using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enigma.Application.Interfaces
{
    public interface ITenantService
    {
        bool IsTenantWhitelisted(Guid TenantId);
    }
}
