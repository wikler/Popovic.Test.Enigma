﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enigma.Domain.Models
{
    public class Product
    {
        public Guid Id { get; set; }

        public string? Name { get; set; }

        public string? Code { get; set; }

        public bool IsSuported { get; set; }
    }
}
