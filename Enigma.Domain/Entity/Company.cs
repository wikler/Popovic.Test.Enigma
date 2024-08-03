using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enigma.Domain.Models
{
    public class Company
    {
        public Guid Id { get; set; }

        public string? Name { get; set; }

        public string? RegistrationNumber { get; set; }

        public string? CompanyType { get; set; }

        public string? VAT { get; set; }

    }
}
