﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enigma.Domain.Models
{
    public class Transaction
    {
        public Guid Id { get; set; }

        public string? TransactionId { get; set; }

        public decimal Amount { get; set; }

        public DateTime Date { get; set; }

        public string? Description { get; set; }

        public string? Category { get; set; }

        public Guid ClientId { get; set; }

        public virtual Client? Client { get; set; }
    }
}
