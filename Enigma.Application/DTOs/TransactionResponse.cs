using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enigma.Application.DTOs
{
    public class TransactionResponse
    {
        public string? Transaction_id { get; set; }

        public decimal Amount { get; set; }

        public String? Date { get; set; }

        public string? Description { get; set; }

        public string? Category { get; set; }
    }
}
