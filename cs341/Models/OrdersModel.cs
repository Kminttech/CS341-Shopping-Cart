using System;
using System.Collections.Generic;

namespace cs341.Models
{
    public class OrdersModel
    {
        public Dictionary<string, List<CartEntry>> Orders { get; set; }
    }
}
