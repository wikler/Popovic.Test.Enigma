using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enigma.Application.DTOs
{
    public class ProductSettingsResponse
    {
        public string? ProductCode { get; set; }

        public List<string>? Hashed { get; set; }

        public List<string>? NotChanged { get; set; }
    }
}
