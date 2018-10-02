using System;
using System.Collections.Generic;
using cs341.Structures;

namespace cs341.Structures
{
    public class Promotion
    {
        int Id { get; set; }
        string Name { get; set; }
        string Code { get; set; }
        decimal PercentOff { get; set; }
        List<Item> SaleItems { get; set; }
    }
}
