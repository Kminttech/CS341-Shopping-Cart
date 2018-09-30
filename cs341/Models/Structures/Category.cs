using System;
using System.Collections.Generic;
using cs341.Structures;

namespace cs341.Structures
{
    public class Category
    {
        int Id { get; set; }
        string Name { get; set; }
        List<Item> Items { get; set; }
    }
}
