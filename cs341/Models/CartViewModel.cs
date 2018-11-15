using System;
using System.Collections.Generic;

namespace cs341.Models
{
    public class CartViewModel
    {
        public List<Item> Items { get; set; }
        public List<CartEntry> Entries { get; set; }
        public decimal Discount { get; set; }
    }
}
