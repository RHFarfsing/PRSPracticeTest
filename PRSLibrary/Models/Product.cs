﻿using System;
using System.Collections.Generic;
using System.Text;

namespace PRSLibrary.Models {
    public class Product {
        public int Id { get; set; }
        public string PartNbr { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Unit { get; set; }
        public int VendorId { get; set; }
        public virtual Vendor Vendor { get; set; }
        public List<RequestLine> requestLines { get; set; }
        public override string ToString() => $"{Id}|{PartNbr}|{Name}|{Unit}|{VendorId}";
        public Product() { }
    }
}
