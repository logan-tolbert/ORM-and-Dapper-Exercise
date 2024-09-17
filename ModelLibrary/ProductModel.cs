﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLibrary
{
    public class ProductModel
    {
        public int ProductId { get; set; }
        public string? Name { get; set; }
        public decimal Price { get; set; }
        public int CategoryId {  get; set; }
        public int OnSale { get; set; }
        public string? StockLevel { get; set; }


    }
}
