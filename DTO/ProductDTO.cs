﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ProductDTO
    {
        public int Id { get; set; }

        public int? CategoryId { get; set; }

        public string CategoryName { get; set; } = null;

        public string? Name { get; set; }

        public string? Image { get; set; }

        public int? Price { get; set; }
    }
}
