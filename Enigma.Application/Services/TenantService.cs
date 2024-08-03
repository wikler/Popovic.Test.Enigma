using Enigma.Application.Interfaces;
using Enigma.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enigma.Application.Services
{
    public class TenantService : ITenantService
    {
        public bool IsTenantWhitelisted(Guid TenantId)
        {
            return _tenants.Where(w => w.Id == TenantId).Single().IsWhitelisted;
        }

        private readonly List<Tenant> _tenants = new List<Tenant>()
        {
            new(){ Id = new Guid("0f8fad5b-d9cb-469f-a165-70867728923e"), Name = "TenantA", IsWhitelisted = true },
            new(){ Id = new Guid("0f8fad5b-d9cb-469f-a165-70867728924e"), Name = "TenantB", IsWhitelisted = true },
            new(){ Id = new Guid("0f8fad5b-d9cb-469f-a165-70867728925e"), Name = "TenantC", IsWhitelisted = false }
        };
    }
}
